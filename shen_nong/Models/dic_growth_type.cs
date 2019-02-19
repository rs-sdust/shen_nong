/****************************************************************
 * 
 * File name: dic_growth_type
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:40:46
 * 
 * Summary: 作物长势级别表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;

namespace shen_nong.Models
{
    [Table("dic_growth_type")]
    public class dic_growth_type
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string growth_type { get; set; }
    }
}