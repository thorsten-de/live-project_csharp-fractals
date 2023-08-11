using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace escape_time_fractals
{
    public static class Extensions
    {
        public static void DrawDashedBox(this Graphics gr,
            Color color1, Color color2, float thickness, float dash_size,
            Point point1, Point point2)
        {
            Rectangle rect = point1.ToRectangle(point2);
            using (Pen pen = new Pen(color1, thickness))
            {
                gr.DrawRectangle(pen, rect);

                pen.DashPattern = new float[] { dash_size, dash_size };
                pen.Color = color2;
                gr.DrawRectangle(pen, rect);
            }
        }

        // Make a rectangle from the two corner points.
        public static Rectangle ToRectangle(this Point point1, Point point2)
        {
            int x = Math.Min(point1.X, point2.X);
            int y = Math.Min(point1.Y, point2.Y);
            int width = Math.Abs(point1.X - point2.X);
            int height = Math.Abs(point1.Y - point2.Y);
            return new Rectangle(x, y, width, height);
        }

        // Make a rectangle from the two corner points.
        public static RectangleF ToRectangle(this PointF point1, PointF point2)
        {
            float x = Math.Min(point1.X, point2.X);
            float y = Math.Min(point1.Y, point2.Y);
            float width = Math.Abs(point1.X - point2.X);
            float height = Math.Abs(point1.Y - point2.Y);
            return new RectangleF(x, y, width, height);
        }

        // Save the file with the appropriate format.
        public static void SaveImage(this Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }
    }
}
