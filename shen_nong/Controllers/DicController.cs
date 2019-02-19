/****************************************************************
 * 
 * File name: DicController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 数据字典控制器 api/v1/dics
 * 
 ****************************************************************/
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
    [RoutePrefix("api/v1/dics")]
    public class DicController : ApiController
    {
        /// <summary>
        /// 获取所有数据字典
        /// </summary>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Get()
        {
            try
            {
                using (IDbConnection conn = DbConnection.OpenConnection(ConnectionType.PostgreSQL))
                {
                    Dic dics = new Dic();
                    //crop_type
                    var crop = conn.GetAll<dic_crop_type>();
                    if (crop.Any<dic_crop_type>())
                    {
                        dics.dic_crop = crop.ToList<dic_crop_type>();
                    }
                    //disease_type
                    var disease = conn.GetAll<dic_disease_type>();
                    if (disease.Any<dic_disease_type>())
                    {
                        dics.dic_disease = disease.ToList<dic_disease_type>();
                    }
                    //growth_type
                    var growth = conn.GetAll<dic_growth_type>();
                    if (growth.Any<dic_growth_type>())
                    {
                        dics.dic_growth = growth.ToList<dic_growth_type>();
                    }
                    //dic_moisture_type
                    var moisture = conn.GetAll<dic_moisture_type>();
                    if (moisture.Any<dic_moisture_type>())
                    {
                        dics.dic_moisture = moisture.ToList<dic_moisture_type>();
                    }
                    //dic_news_type
                    var news = conn.GetAll<dic_news_type>();
                    if (news.Any<dic_news_type>())
                    {
                        dics.dic_news = news.ToList<dic_news_type>();
                    }
                    //dic_pest_type
                    var pest = conn.GetAll<dic_pest_type>();
                    if (pest.Any<dic_pest_type>())
                    {
                        dics.dic_pest = pest.ToList<dic_pest_type>();
                    }
                    //dic_phenophase
                    var phenophase = conn.GetAll<dic_phenophase>();
                    if (phenophase.Any<dic_phenophase>())
                    {
                        dics.dic_phenophase = phenophase.ToList<dic_phenophase>();
                    }
                    //dic_rsi_type
                    var rsi = conn.GetAll<dic_rsi_type>();
                    if (rsi.Any<dic_rsi_type>())
                    {
                        dics.dic_rsi = rsi.ToList<dic_rsi_type>();
                    }
                    return new ResultContent(true, dics);
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
