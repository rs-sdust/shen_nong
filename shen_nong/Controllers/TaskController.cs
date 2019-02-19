/****************************************************************
 * 
 * File name: TaskController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 任务消息控制器 api/v1/tasks
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
    [RoutePrefix("api/v1/tasks")]
    public class TaskController : ApiController
    {
        /// <summary>
        /// 创建任务
        /// </summary>
        /// <param name="task">任务</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Post(Task task)
        {
            if (task == null)
            {
                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
            }
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    var strSql = "SELECT * FROM tb_user_task WHERE farm_id=@farm_id AND sender_id=@sender_id AND receiver_id=@receiver_id AND type_id=@type_id";
                    var res = conn.QueryFirstOrDefault<User>(strSql, new { farm_id = task.farm_id, sender_id=task.sender_id, receiver_id=task.receiver_id, type_id =task.type_id});
                    if (res != null)
                    {
                        return new ResultContent(false, MSG.GetInstance().ALREADY_EXISTS, null);
                    }
                    if (conn.Insert<Task>(task) > 0)
                    {
                        strSql = "SELECT MAX(id) FROM tb_user_task";
                        var max = conn.Query<int>(strSql);
                        var newTask = conn.Get<Task>(max.First());
                        return new ResultContent(true, newTask);
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
        /// 获取用户创建的任务
        /// </summary>
        /// <param name="sender_id">发送人编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent GetBySender(int sender_id,int limit,int offset)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    var strSql = "SELECT * FROM tb_user_task WHERE sender_id = @sender_id ORDER BY create_date LIMIT @limit OFFSET @offset";
                    //查询
                    var tasks = conn.Query<Task>(strSql, new { sender_id = sender_id , limit = limit , offset = offset });
                    if (tasks.Any<Task>())
                    {
                        return new ResultContent(true, tasks);
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
        /// 获取用户接收的任务
        /// </summary>
        /// <param name="receiver_id">接收人编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent GetByReceiver(int receiver_id,int limit,int offset)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    var strSql = "SELECT * FROM tb_user_task WHERE receiver_id = @receiver_id ORDER BY create_date LIMIT @limit OFFSET @offset";
                    //查询
                    var tasks = conn.Query<Task>(strSql, new { receiver_id = receiver_id, limit = limit, offset = offset });
                    if (tasks.Any<Task>())
                    {
                        return new ResultContent(true, tasks);
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
        /// 更新任务
        /// </summary>
        /// <param name="task">任务</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Put(Task task)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //更新
                    if (conn.Update<Task>(task))
                    {
                        var updateTask = conn.Get<Task>(task.id);
                        return new ResultContent(true, updateTask);
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
        /// 删除指定任务
        /// </summary>
        /// <param name="id">任务编号</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Delete(int id)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    //删除
                    if (conn.Delete(new Task() { id = id }))
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
