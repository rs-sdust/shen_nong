/****************************************************************
 * 
 * File name: DocController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 接口文档控制器 api/v1/docs
 * 
 ****************************************************************/
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shen_nong.Controllers
{
    public class DocController : ApiController
    {
        /// <summary>
        /// 获取接口文档
        /// </summary>
        /// <returns>HttpResponseMessage/html</returns>
        [Route("api/v1/docs")]
        public HttpResponseMessage GetV1()
        {
            try
            {
                //需要加载的html页面的路径
                var path = System.Web.HttpContext.Current.Server.MapPath("~/Views/doc_v1.html");
                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(System.IO.File.ReadAllText(path), System.Text.Encoding.UTF8, "text/html")
                };
                return result;
         
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(statusCode: HttpStatusCode.NotFound);
            }
        }
    }
}
