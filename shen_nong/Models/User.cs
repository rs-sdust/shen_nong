/****************************************************************
 * 
 * File name: User
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 17:31:37
 * 
 * Summary: 用户信息表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;

namespace shen_nong.Models
{
    [Table("tb_user")]
    public class User
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 农场编号
        /// </summary>
        public int farm_id { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string thumb_url { get; set; }

        public User()
        {
            //字段默认值
            name = "";
            mobile = "";
            farm_id = -1;
            thumb_url = "";
        }
    }
}