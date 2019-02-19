/****************************************************************
 * 
 * File name: HomeController
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/8/27
 * 
 * Summary: 首页控制器 api/v1/
 * 
 ****************************************************************/
using System.Web.Http;

namespace shen_nong.Controllers
{
    /// <summary>
    /// 主目录请求，返回字符串，以避免直接提示IIS错误
    /// </summary>
    public class HomeController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Json<string>("shen_nong");
        }
        [Route("api")]
        public IHttpActionResult GetApi()
        {
            return Json<string>("shen_nong_api");
        }
        [Route("api/v1")]
        public IHttpActionResult GetApiV1()
        {
            return Json<string>("shen_nong_api_v1");
        }

    }
}
