﻿/****************************************************************
 * 
 * File name: BitmapUtils
 * 
 * Version: 1.0
 * 
 * Author: RickerYan
 * 
 * Company: SunGolden
 * 
 * Created: 2018/9/3 16:23:25
 * 
 * Summary: bitmap 相关操作
 * 
 ****************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace shen_nong.Common
{
    public class BitmapUtils
    {
        #region 图片压缩

        /// <summary>
        /// 图片压缩(降低质量以减小文件的大小)
        /// </summary>
        /// <param name="srcBitMap">传入的Bitmap对象</param>
        /// <param name="destFile">压缩后的图片保存路径</param>
        /// <param name="level">压缩等级，0到100，0 最差质量，100 最佳</param>
        public static void Compress(Bitmap srcBitMap, string destFile, long level)
        {
            using (Stream s = new FileStream(destFile, FileMode.Create))
            {
                Compress(srcBitMap, s, level);
                s.Flush();
                s.Close();
            }

        }

        /// <summary>
        /// 编码信息
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /// <summary>
        /// 图片压缩(降低质量以减小文件的大小)
        /// </summary>
        /// <param name="srcBitmap">传入的Bitmap对象</param>
        /// <param name="destStream">压缩后的Stream对象</param>
        /// <param name="level">压缩等级，0到100，0 最差质量，100 最佳</param>
        private static void Compress(Bitmap srcBitmap, Stream destStream, long level)
        {
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            // Get an ImageCodecInfo object that represents the JPEG codec.
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            myEncoder = Encoder.Quality;
            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(1);
            // Save the bitmap as a JPEG file with 给定的 quality level
            myEncoderParameter = new EncoderParameter(myEncoder, level);
            myEncoderParameters.Param[0] = myEncoderParameter;
            srcBitmap.Save(destStream, myImageCodecInfo, myEncoderParameters);
        }
        #endregion
    }
}