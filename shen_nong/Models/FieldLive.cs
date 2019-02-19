/****************************************************************
 * 
 * File name: FieldLive
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 19:37:03
 * 
 * Summary: 地块实况信息
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using System;

namespace shen_nong.Models
{
    [Table("tb_field_live")]
    public class FieldLive
    {
        /// <summary>
        /// 主键 实况编号(NOT NULL)
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
        /// 长势等级(NOT NULL)
        /// </summary>
        public int growth_id { get; set; }
        /// <summary>
        /// 土壤湿度等级(NOT NULL)
        /// </summary>
        public int moisture_id { get; set; }
        /// <summary>
        /// 病害类型编号(NOT NULL)
        /// </summary>
        public int disease_id { get; set; }
        /// <summary>
        /// 虫害类型编号(NOT NULL)
        /// </summary>
        public int pest_id { get; set; }
        /// <summary>
        /// 采集人(NOT NULL)
        /// </summary>
        public int collector { get; set; }
        /// <summary>
        /// 采集时间(NOT NULL)
        /// </summary>
        public DateTime collect_date { get; set; }
        /// <summary>
        /// gps坐标(NOT NULL)
        /// </summary>
        public NpgsqlTypes.PostgisPoint gps { get; set; }
        /// <summary>
        /// 图片连接(NOT NULL)
        /// </summary>
        public string picture { get; set; }

        public FieldLive()
        {
            farm_id = -1;
            field_id = -1;
            growth_id = -1;
            moisture_id = -1;
            disease_id = -1;
            pest_id = -1;
            collector = -1;
            collect_date = DateTime.Now ;
            picture = "";
        }
    }
}