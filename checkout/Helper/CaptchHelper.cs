using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Helper
{
    class CaptchHelper
    {

        /// <summary>
        /// 截图
        /// </summary>
        /// <param name="fromImagePath"></param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <param name="toImagePath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void CaptureImage(byte[] fromImageByte, int offsetX, int offsetY, string toImagePath, int width, int height)
        {
            //原图片文件
            MemoryStream ms = new MemoryStream(fromImageByte);
            Image fromImage = Image.FromStream(ms);
            //创建新图位图
            Bitmap bitmap = new Bitmap(width, height);
            //创建作图区域
            Graphics graphic = Graphics.FromImage(bitmap);
            //截取原图相应区域写入作图区
            graphic.DrawImage(fromImage, 0, 0, new Rectangle(offsetX, offsetY, width, height), GraphicsUnit.Pixel);
            //从作图区生成新图
            Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());
            //保存图片
            saveImage.Save(toImagePath, ImageFormat.Png);
            //释放资源   
            saveImage.Dispose();
            graphic.Dispose();
            bitmap.Dispose();
        }

        /// <summary>
        /// 比较两张图片的像素，确定阴影图片位置
        /// </summary>
        /// <param name="oldBmp"></param>
        /// <param name="newBmp"></param>
        /// <returns></returns>
        public static int GetArgb(Bitmap oldBmp, Bitmap newBmp)
        {
            //由于阴影图片四个角存在黑点(矩形1*1)
            for (int i = 0; i < newBmp.Width; i++)
            {

                for (int j = 0; j < newBmp.Height; j++)
                {
                    if ((i >= 0 && i <= 1) && ((j >= 0 && j <= 1) || (j >= (newBmp.Height - 2) && j <= (newBmp.Height - 1))))
                    {
                        continue;
                    }
                    if ((i >= (newBmp.Width - 2) && i <= (newBmp.Width - 1)) && ((j >= 0 && j <= 1) || (j >= (newBmp.Height - 2) && j <= (newBmp.Height - 1))))
                    {
                        continue;
                    }

                    //获取该点的像素的RGB的颜色
                    Color oldColor = oldBmp.GetPixel(i, j);
                    Color newColor = newBmp.GetPixel(i, j);
                    if (Math.Abs(oldColor.R - newColor.R) > 60 || Math.Abs(oldColor.G - newColor.G) > 60 || Math.Abs(oldColor.B - newColor.B) > 60)
                    {
                        return i;
                    }


                }
            }
            return 0;
        }

        /// <summary>
        /// 根据图片地址，得到图片对象
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Image GetImg(string url)
        {

            WebRequest webreq = WebRequest.Create(url);
            WebResponse webres = webreq.GetResponse();
            Image img;
            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                img = Image.FromStream(stream);
            }
            return img;
        }
    }

}
