/****************************************************************
 * 
 * File name: Auth
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27 11:40:09
 * 
 * Summary: 授权接口返回结果
 * 
 ****************************************************************/
using System;

namespace shen_nong.Models
{
    public class Auth
    {
        /// <summary>
        /// access token
        /// </summary>
        public String token { get; set; }
        /// <summary>
        /// user info
        /// </summary>
        public User user { get; set; }

        public Auth(User user, String token)
        {
            this.user = user;
            this.token = token;
        }
    }
}