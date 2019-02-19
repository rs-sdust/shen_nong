/****************************************************************
 * 
 * File name: Task
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 17:31:37
 * 
 * Summary: 待处理通知表
 * 
 ****************************************************************/
using Dapper.Contrib.Extensions;
using System;

namespace shen_nong.Models
{
    [Table("tb_user_task")]
    public class Task
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
        /// 发送人编号(NOT NULL)
        /// </summary>     
        public int sender_id { get; set; }
        /// <summary>
        /// 接收人编号(NOT NULL)
        /// </summary>
        public int receiver_id { get; set; }
        /// <summary>
        /// 消息类型 0，申请加入农场(NOT NULL)
        /// </summary>
        public int type_id { get; set; }
        /// <summary>
        ///详细信息(NOT NULL)
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 处理状态 false,未处理；true，已处理(NOT NULL)
        /// </summary>
        public Boolean state { get; set; }
        /// <summary>
        /// 是否同意，f,不同意；t,同意(NOT NULL)
        /// </summary>
        public Boolean agree { get; set; }
        /// <summary>
        /// 创建时间(NOT NULL)
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 处理时间(NOT NULL)
        /// </summary>
        public DateTime process_date { get; set; }

        public Task()
        {
            farm_id = -1;
            sender_id = -1;
            receiver_id = -1;
            type_id = -1;
            desc = "";
            state = false;
            agree = false;
            create_date = DateTime.Now;
            process_date = new DateTime(2000, 1, 1);
        }
    }
}