/****************************************************************
 * 
 * File name: FeedBackController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/28
 * 
 * Summary: 反馈信息控制器 api/v1/feedbacks
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
    [RoutePrefix("api/v1/feedbacks")]
    public class FeedBackController : ApiController
    {
        /// <summary>
        /// 提交意见反馈
        /// </summary>
        /// <param name="feedBack">意见反馈</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Post(FeedBack feedBack)
        {
            if (feedBack == null)
            {
                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
            }
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    if (conn.Insert<FeedBack>(feedBack) > 0)
                    {
                        //var strSql = "SELECT MAX(id) FROM tb_farm";
                        //var res = conn.Query<int>(strSql);
                        //var newFarm = conn.Get<Farm>(res.First());
                        return new ResultContent(true, null);
                    }
                    else
                    {
                        return new ResultContent(false, MSG.GetInstance().UNKNOWN_ERROR, null);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO:记录日志
                return new ResultContent(false, MSG.GetInstance().SERVER_ERROR, null);
            }
        }
    }
}
