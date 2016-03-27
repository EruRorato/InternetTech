using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;

namespace notes.Models
{
    public static class ImageFactory
    {
        public static Image generateImage(string txt)
        {
            Image bmp = new Bitmap(1, 1);
            int width, height;
            //Font
            Font aFont = new Font("Times New Roman",16);
            //Graphics
            Graphics graphics = Graphics.FromImage(bmp);
            //Resize bmp
            width = (int)graphics.MeasureString(txt,aFont).Width;
            height = (int)graphics.MeasureString(txt,aFont).Height;
            bmp = new Bitmap(width,height);

            graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(txt,aFont,new SolidBrush(Color.Black),0,0);
            graphics.Save();
            graphics.Flush();
            
            return bmp;
        }

        public static Stream ToStream(this Image image) {
          var stream = new System.IO.MemoryStream();
          image.Save(stream, ImageFormat.Png);
          stream.Position = 0;
          return stream;
        }
    }
}