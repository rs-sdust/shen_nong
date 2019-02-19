/****************************************************************
 * 
 * File name: NewsController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 新闻资讯控制器 api/v1/news
 * 
 ****************************************************************/
using Dapper;
using shen_nong.Common;
using shen_nong.Models;
using SunGolden.DbUtils;
using System;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace shen_nong.Controllers
{
    [RoutePrefix("api/v1/news")]
    public class NewsController : ApiController
    {
        /// <summary>
        /// 获取新闻
        /// </summary>
        /// <param name="type">新闻类型</param>
        /// <param name="limit">获取个数</param>
        /// <param name="offset">开始位置</param>
        /// <returns></returns>
        [Route("")]
        public ResultContent Get(int type,int limit,int offset)
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    var strSql = "SELECT * FROM tb_news WHERE news_type = @news_type ORDER BY news_date LIMIT @limit OFFSET @offset";
                    var news = conn.Query<News>(strSql,new { news_type = type, limit = limit, offset = offset });
                    if (news.Any<News>())
                    {
                        return new ResultContent(true, news);
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
