using Dapper.Contrib.Extensions;
using shen_nong.Common;
using SunGolden.DbUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shen_nong.Controllers
{
    [RoutePrefix("api/v1/pictures")]
    public class PictureController : ApiController
    {
        /// <summary>
        /// 上传图片，返回图片链接
        /// </summary>
        /// <param name="fieldLive">地块实况</param>
        /// <returns>ResultContent</returns>
        [Route("")]
        public ResultContent Post(List<String> base64Strs)
        {
            if (base64Strs == null || base64Strs.Count < 1)
            {
                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
            }
            try
            {
                var path = System.Web.HttpContext.Current.Server.MapPath("~");
                var folder = @"img\"+DateTime.Now.ToString("yyyyMMdd") +"\\";
                var folderName = path +"\\"+ folder;
                if (!Directory.Exists(folderName)) {
                    Directory.CreateDirectory(folderName);
                }
                var urls = new List<string>();
                foreach (string str in base64Strs)
                {
                    using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str)))
                    {
                        using (Bitmap bitmap = new Bitmap(memoryStream))
                        {
                            if (bitmap == null)
                            {
                                return new ResultContent(false, MSG.GetInstance().INVALID_DATA, null);
                            }
                            var file = DateTime.Now.ToFileTime().ToString() + ".jpg";
                            var fileName = folderName + file;
                            //BitmapUtils.Compress(bitmap, fileName, 0);
                            bitmap.Save(fileName,ImageFormat.Jpeg);
                            urls.Add((folder + file).Replace(@"\", "/"));
                        }
                    }

                }
                return new ResultContent(true, urls);
            }
            catch (Exception ex)
            {
                //TODO:记录日志
                return new ResultContent(false, MSG.GetInstance().SERVER_ERROR, null);
            }
        }
    }
}
