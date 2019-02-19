/****************************************************************
 * 
 * File name: FieldLiveController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/28
 * 
 * Summary: 地块实况控制器 api/v1/fieldlives
 * 
 ****************************************************************/
using Dapper;
using Dapper.Contrib.Extensions;
using shen_nong.Common;
using shen_nong.Models;
using SunGolden.DbUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shen_nong.Controllers
{
    [RoutePrefix("api/v1/fieldlives")]
    public class FieldLiveController : ApiController
    {
        /// <summary>
        /// 提交地块实况信息
        /// </summary>
        /// <param name="fieldLive">地块实况</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Post(FieldLive fieldLive)
        {
            if (fieldLive == null)
            {
                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
            }
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    if (conn.Insert<FieldLive>(fieldLive) > 0)
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
        /// <summary>
        /// 获取地块实况信息
        /// </summary>
        /// <param name="farm_id">农场编号</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        [Route("")]
        public ResultContent Get(int farm_id,DateTime start,DateTime end)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //查询
                    string strSql = "SELECT * FROM tb_field_live WHERE farm_id = @farm_id AND collect_date BETWEEN @start AND @end";
                    var fieldLives = conn.Query<FieldLive>(strSql, new { farm_id = farm_id, start = start, end = end });
                    if (fieldLives.Any<FieldLive>())
                    {
                        return new ResultContent(true, fieldLives);
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
    }
}
