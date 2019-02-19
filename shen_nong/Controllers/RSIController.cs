/****************************************************************
 * 
 * File name: RSIController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 农情控制器 api/v1/rsis
 * 
 ****************************************************************/
using Dapper;
using Dapper.Contrib.Extensions;
using shen_nong.Common;
using shen_nong.Models;
using SunGolden.DbUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace shen_nong.Controllers
{
    [RoutePrefix("api/v1/rsis")]
    public class RSIController : ApiController
    {
        /// <summary>
        /// 获取指定农场的最新农情数据
        /// </summary>
        /// <param name="farm_id">农场编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Get(int farm_id)
        {
            try
            {
                using (System.Data.IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //查询农场所有地块
                    var strSql = "SELECT * FROM tb_field WHERE farm_id = @farm_id";
                    var fields = conn.Query<Field>(strSql, new { farm_id = farm_id });
                    if (!fields.Any<Field>())
                    {
                        return new ResultContent(false, MSG.GetInstance().DATA_NOT_FOUND, null);
                    }
                    else
                    {
                        //dic_rsi_type
                        var rsiTypes = conn.GetAll<dic_rsi_type>();
                        if (!rsiTypes.Any<dic_rsi_type>())
                        {
                            return new ResultContent(false, MSG.GetInstance().DATA_NOT_FOUND, null);
                        }
                        else
                        {
                            var rsis = new List<RSI>();
                            foreach (Field field in fields)
                            {
                                foreach (dic_rsi_type type in rsiTypes)
                                {
                                    var strSql1 = "SELECT * FROM tb_field_rsi WHERE field_id = @field_id AND type_id=@type_id ORDER BY product_date DESC LIMIT 1 OFFSET 0";
                                    var rsi = conn.QueryFirstOrDefault<RSI>(strSql1, new { field_id = field.id, type_id = type.id });
                                    if (rsi!=null)
                                    {
                                        rsis.Add(rsi);
                                    }
                                }
                            }
                            if (rsis.Count < 1)
                            {
                                return new ResultContent(false, MSG.GetInstance().DATA_NOT_FOUND, null);
                            }
                            return new ResultContent(true, rsis);
                        }
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
