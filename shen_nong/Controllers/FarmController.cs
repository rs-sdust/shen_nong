/****************************************************************
 * 
 * File name: FarmController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 农场控制器 api/v1/farms
 * 
 ****************************************************************/
using Dapper;
using Dapper.Contrib.Extensions;
using shen_nong.Common;
using shen_nong.Models;
using SunGolden.DbUtils;
using System;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace shen_nong.Controllers
{
    [RoutePrefix("api/v1/farms")]
    public class FarmController : ApiController
    {
        /// <summary>
        /// 创建农场
        /// </summary>
        /// <param name="farm">农场</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Post(Farm farm)
        {
            if (farm == null)
            {
                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
            }
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    if (conn.Insert<Farm>(farm) > 0)
                    {
                        var strSql = "SELECT MAX(id) FROM tb_farm";
                        var res = conn.Query<int>(strSql);
                        var newFarm = conn.Get<Farm>(res.First());
                        var owener = conn.Get<User>(newFarm.owner);
                        owener.farm_id = newFarm.id;
                        conn.Update<User>(owener);
                        return new ResultContent(true, newFarm);
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
        /// 查询指定id农场信息
        /// </summary>
        /// <param name="id">农场编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Get(int id)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //查询
                    var farm = conn.Get<Farm>(id);
                    if (farm != null)
                    {
                        return new ResultContent(true,farm);
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
        /// 查询指定地址的农场信息
        /// </summary>
        /// <param name="prov">省名称</param>
        /// <param name="city">市名称</param>
        /// <param name="county">县名称</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Get(string prov,string city,string county)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //查询
                    string strSql = "SELECT * FROM tb_farm WHERE province = @province AND city = @city AND county = @county";
                    var farms = conn.Query<Farm>(strSql, new { province = prov, city = city, county = county });
                    if (farms.Any<Farm>())
                    {
                        return new ResultContent(true, farms);
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
        /// 更新农场
        /// </summary>
        /// <param name="farm">农场</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Put(Farm farm)
        {
            if (farm == null)
            {
                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
            }
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //更新
                    if (conn.Update<Farm>(farm))
                    {
                        var updateFarm = conn.Get<Farm>(farm.id);
                        return new ResultContent(true,updateFarm);
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
        /// 删除农场--暂时不提供接口
        /// </summary>
        /// <returns></returns>
        //public ResultContent Delete()
        //{

        //}
    }

}
