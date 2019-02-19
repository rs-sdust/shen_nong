/****************************************************************
 * 
 * File name: dic_moisture_type
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:40:58
 * 
 * Summary: 土壤湿度类型表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;

namespace shen_nong.Models
{
    [Table("dic_moisture_type")]
    public class dic_moisture_type
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string moisture_type { get; set; }
    }
}