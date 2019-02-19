/****************************************************************
 * 
 * File name: dic_crop_type
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:40:09
 * 
 * Summary: 作物类型字典
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;

namespace shen_nong.Models
{
    [Table("dic_crop_type")]
    public class dic_crop_type
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string crop_type { get; set; }
    }
}