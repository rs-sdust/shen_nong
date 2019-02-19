/****************************************************************
 * 
 * File name: dic_news_type
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:41:12
 * 
 * Summary: 资讯类型表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;

namespace shen_nong.Models
{
    [Table("dic_news_type")]
    public class dic_news_type
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string news_type { get; set; }
    }
}