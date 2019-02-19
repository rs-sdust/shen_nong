/****************************************************************
 * 
 * File name: RSI
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 17:31:37
 * 
 * Summary: 遥感农情信息
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using System;

namespace shen_nong.Models
{
    [Table("tb_field_rsi")]
    public class RSI
    {
        /// <summary>
        /// 主键 编号(NOT NULL)
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 农场编号(NOT NULL)
        /// </summary>
        public int farm_id { get; set; }
        /// <summary>
        /// 地块编号(NOT NULL)
        /// </summary>
        public int field_id { get; set; }
        /// <summary>
        /// FK_农情类型(NOT NULL)
        /// </summary>
        public int type_id { get; set; }
        /// <summary>
        /// 产品日期(NOT NULL)
        /// </summary>
        public DateTime product_date { get; set; }
        /// <summary>
        /// 更新日期(NOT NULL)
        /// </summary>
        public DateTime update_date { get; set; }
        /// <summary>
        /// 产品数据分类后的等级(NOT NULL)
        /// </summary>
        public int grade_id { get; set; }
        /// <summary>
        /// 产品反演的实际数值(NOT NULL)
        /// </summary>
        public float value { get; set; }

        public RSI()
        {
            farm_id = -1;
            field_id = -1;
            type_id = -1;
            grade_id = -1;
            value = -1;
            product_date = new DateTime(2000, 1, 1);
            update_date = DateTime.Now;
        }
    }
}