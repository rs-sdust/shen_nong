/****************************************************************
 * 
 * File name: AuthController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 授权控制器 api/v1/auth
 * 
 ****************************************************************/
using Dapper;
using Dapper.Contrib.Extensions;
using shen_nong.Common;
using shen_nong.Models;
using SunGolden.DbUtils;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace shen_nong.Controllers
{
    [RoutePrefix("api/v1/auth")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// 用户授权
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Get(string mobile)
        {
            using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
            {
                try
                {
                    //参数检查
                    if (mobile.Length != 11 || !Regex.IsMatch(mobile, @"^[0-9]*[0-9][0-9]*$"))
                    {
                        return new ResultContent(false, MSG.GetInstance().INVALID_MOBILE, null);
                    }
                    //查询用户
                    var strSql = "SELECT * FROM tb_user WHERE mobile=@mobile";
                    var res = conn.QueryFirstOrDefault<User>(strSql, new { mobile = mobile });
                    //用户不存在创建用户
                    if (res==null)
                    {
                        User newUser = new User() { name = mobile, mobile = mobile };
                        conn.Insert(newUser);
                        res = conn.QueryFirstOrDefault<User>(strSql, new { mobile = mobile });
                    }
                    //生成Token
                    String token = SunGolden.Encryption.DEncrypt.Encrypt(mobile + "," + DateTime.Now.AddDays(30));
                    return new ResultContent(true,new Auth(res,token));
                }
                catch (Exception ex)
                {
                    //TODO:记录日志
                    return new ResultContent(false, MSG.GetInstance().SERVER_ERROR, null);
                }
            }
        }
    }
}
