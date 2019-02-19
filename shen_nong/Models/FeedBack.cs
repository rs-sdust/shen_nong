/****************************************************************
 * 
 * File name: FeedBack
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 19:36:39
 * 
 * Summary: 用户反馈
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using System;

namespace shen_nong.Models
{
    [Table("tb_feedback")]
    public class FeedBack
    {
        /// <summary>
        /// 主键 id(NOT NULL)
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 用户id(NOT NULL)
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 意见(NOT NULL)
        /// </summary>   
        public string suggestion { get; set; }
        /// <summary>
        /// 图片链接(NOT NULL)
        /// </summary>
        public string thumb_url { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime create_date { get; set; }
        public FeedBack()
        {
            id = -1;
            user_id = -1;
            suggestion = "";
            thumb_url = "";
            create_date = DateTime.Now;
        }
    }
}