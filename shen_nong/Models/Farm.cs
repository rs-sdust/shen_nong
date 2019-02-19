/****************************************************************
 * 
 * File name: Farm
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:41:57
 * 
 * Summary: 农场信息表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;

namespace shen_nong.Models
{
    [Table("tb_farm")]
    public class Farm
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 农场名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 农场主
        /// </summary>
        public int owner { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public string county { get; set; }
        /// <summary>
        /// 街道
        /// </summary>
        public string street { get; set; }

        public Farm()
        {
            //字段默认值
            name = "";
            owner = -1;
            province = "";
            city = "";
            county = "";
            street = "";
        }
    }
}