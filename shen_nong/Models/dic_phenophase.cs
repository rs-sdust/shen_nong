/****************************************************************
 * 
 * File name: dic_phenophase
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:41:44
 * 
 * Summary: 作物物候信息表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using System;

namespace shen_nong.Models
{
    [Table("dic_phenophase")]
    public class dic_phenophase
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 作物类型编号
        /// </summary>
        public int crop_id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public String type { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        public int days { get; set; }
        /// <summary>
        /// 物候特征
        /// </summary>
        public String detail { get; set; }
    }
}