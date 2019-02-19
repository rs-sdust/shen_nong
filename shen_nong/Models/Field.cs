/****************************************************************
 * 
 * File name: Field
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:41:57
 * 
 * Summary: 地块信息表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using NpgsqlTypes;
using System;

namespace shen_nong.Models
{
    [Table("tb_field")]
    public class Field
    {
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 地块名称(NOT NULL)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 地块面积以亩为单位(NOT NULL)
        /// </summary>
        public float area { get; set; }
        /// <summary>
        /// 创建时间(NOT NULL)
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string thumb_url { get; set; }
        /// <summary>
        /// 空间字段(NOT NULL)
        /// </summary>
        public PostgisPolygon geom { get; set; }
        /// <summary>
        /// 所属农场编号(NOT NULL)
        /// </summary>
        public int farm_id { get; set; }
        /// <summary>
        /// 种植作物编号
        /// </summary>
        public int crop_id { get; set; }
        /// <summary>
        /// 播种日期
        /// </summary>
        public DateTime sow_date { get; set; }
        /// <summary>
        /// 物候期
        /// </summary>
        public int phenophase { get; set; }

        public Field()
        {
            name = "";
            area = 0;
            create_date = DateTime.Now;
            thumb_url = "";
            farm_id = -1;
            crop_id = -1;
            sow_date = new DateTime(2000, 1, 1);
            phenophase = -1;
        }

    }
}