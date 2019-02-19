/****************************************************************
 * 
 * File name: UserController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 用户控制器 api/v1/users
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using shen_nong.Common;
using shen_nong.Models;
using SunGolden.DbUtils;
using System;
using System.Data;
using System.Web.Http;

namespace shen_nong.Controllers
{
    [RoutePrefix("api/v1/users")]
    public class UserController : ApiController
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        //public ResultContent Post()
        //{

        //}

        /// <summary>
        /// 查询指定id用户信息
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Get(int id)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {

                    //查询用户
                    var user = conn.Get<User>(id);
                    if (user != null)
                    {
                        return new ResultContent(true,user);
                    }
                    else
                    {
                        return new ResultContent(false, MSG.GetInstance().DATA_NOT_FOUND, null);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO:记录日志
                return new ResultContent(false, MSG.GetInstance().SERVER_ERROR, null);
            }
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Put(User user)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //查询用户
                    if (conn.Update<User>(user))
                    {
                        var updateUser = conn.Get<User>(user.id);
                        return new ResultContent(true, updateUser);
                    }
                    else
                    {
                        return new ResultContent(false, MSG.GetInstance().UNKNOWN_ERROR, null);
                    }
                }
            }
            catch(Exception ex)
            {
                //TODO:记录日志
                return new ResultContent(false, MSG.GetInstance().SERVER_ERROR, null);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        //public ResultContent Delete()
        //{

        //}
    }
}
