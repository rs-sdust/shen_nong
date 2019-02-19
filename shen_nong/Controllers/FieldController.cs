/****************************************************************
 * 
 * File name: FieldController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 地块控制器 api/v1/fields
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
    [RoutePrefix("api/v1/fields")]
    public class FieldController : ApiController
    {
        /// <summary>
        /// 新建地块
        /// </summary>
        /// <param name="field">地块</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Post(Field field)
        {
            if (field == null)
            {
                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
            }
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    if (conn.Insert<Field>(field) > 0)
                    {
                        var strSql = "SELECT MAX(id) FROM tb_field";
                        var res = conn.Query<int>(strSql);
                        var newField = conn.Get<Field>(res.First());
                        return new ResultContent(true, newField);
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
        /// 查询指定id地块
        /// </summary>
        /// <param name="id">地块编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Get(int id)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //查询
                    var field = conn.Get<Field>(id);
                    if (field != null)
                    {
                        return new ResultContent(false,field);
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
        /// 查询指定农场所有地块
        /// </summary>
        /// <param name="farm_id">农场编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent GetAll(int farm_id)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    var strSql = "SELECT * FROM tb_field WHERE farm_id = @farm_id";
                    //查询
                    var fields = conn.Query<Field>(strSql, new { farm_id = farm_id });
                    if (fields.Any<Field>())
                    {
                        
                        return new ResultContent(true, fields);
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
        /// 更新地块
        /// </summary>
        /// <param name="field">地块</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Put(Field field)
        {
            if (field == null)
            {
                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
            }
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //更新
                    if (conn.Update<Field>(field))
                    {
                        var updateField = conn.Get<Field>(field.id);
                        return new ResultContent(true, updateField);
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
        /// 删除指定地块
        /// </summary>
        /// <param name="id">地块编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Delete(int id)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //删除
                    if (conn.Delete(new Field() { id = id }))
                    {
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
