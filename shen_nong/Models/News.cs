/****************************************************************
 * 
 * File name: News
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:40:46
 * 
 * Summary: 新闻资讯表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using System;

namespace shen_nong.Models
{
    [Table("tb_news")]
    public class News
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 资讯类型
        /// </summary>
        public int news_type { get; set; }
        /// <summary>
        /// 资讯简述
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 资讯日期
        /// </summary>
        public DateTime news_date { get; set; }
        /// <summary>
        /// 资讯链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string thumb_url { get; set; }

        public News()
        {
            news_type = -1;
            title = "";
            news_date = DateTime.Now;
            url = "";
            thumb_url = "";
        }

    }
}