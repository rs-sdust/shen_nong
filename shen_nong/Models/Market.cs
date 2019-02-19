/****************************************************************
 * 
 * File name: Market
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 19:36:27
 * 
 * Summary: 市场价格
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using System;

namespace shen_nong.Models
{
    [Table("tb_market")]
    public class Market
    {
        /// <summary>
        /// 主键 编号(NOT NULL)
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 作物类型编号(NOT NULL)
        /// </summary>
        public int crop_id { get; set; }
        /// <summary>
        /// 作物单价(NOT NULL)
        /// </summary>
        public float price { get; set; }
        /// <summary>
        /// 更新日期(NOT NULL)
        /// </summary>
        public DateTime update_date { get; set; }
        public Market()
        {
            update_date = new DateTime(2000, 1, 1);
        }
    }
}