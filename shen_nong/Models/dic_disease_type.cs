/****************************************************************
 * 
 * File name: dic_disease_type
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:40:25
 * 
 * Summary: 病害类型表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;

namespace shen_nong.Models
{
    [Table("dic_disease_type")]
    public class dic_disease_type
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string disease_type { get; set; }
    }
}