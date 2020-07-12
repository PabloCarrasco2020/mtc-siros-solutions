using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Application.Interface;

namespace Application.Core
{
    public class CaptchaApplication : ICaptchaApplication
    {
        private const int _imageWidth = 80;
        private const int _imageHeight = 30;
        private const int _textColorDepth = 80;
        private const int _interferenceColorDepth = 200;
        //private const string _chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
        //private const string _chars = "abdefghjknpqrstuwyABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        private const string _chars = "0123456789";
        private readonly static Random _random = new Random();
        private readonly static Color _backGroundColor = Color.White;
        private readonly static List<Font> _fonts = new string[]  {
                    "Arial", "Arial Black", "Calibri", "Cambria", "Verdana",
                    "Trebuchet MS", "Palatino Linotype", "Georgia", "Constantia",
                    "Consolas", "Comic Sans MS", "Century Gothic", "Candara",
                    "Courier New", "Times New Roman"
                }.Select(f => new Font(f, 18, FontStyle.Bold | FontStyle.Italic)).ToList();


        public CaptchaApplication()
        {

        }
      
        public string ComputeMd5Hash(string input)
        {
            var encoding = new ASCIIEncoding();
            var bytes = encoding.GetBytes(input);
            var md5Hasher = MD5.Create();
            return BitConverter.ToString(md5Hasher.ComputeHash(bytes));
        }

        public byte[] GenerateCaptchaImage(string text)
        {
            using (var bmpOut = new Bitmap(_imageWidth, _imageHeight))
            {
                float orientationAngle = _random.Next(0, 359);
                var g = Graphics.FromImage(bmpOut);
                var gradientBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, _imageWidth, _imageHeight),
                    _backGroundColor, _backGroundColor,
                    orientationAngle
                );
                g.FillRectangle(gradientBrush, 0, 0, _imageWidth, _imageHeight);

                int tempRndAngle = 0;
              
                for (int i = 0; i < text.Length; i++)
                {
                 
                    tempRndAngle = _random.Next(-5, 5);
                    g.RotateTransform(tempRndAngle);

                   
                    g.DrawString(
                        text[i].ToString(),
                        _fonts[_random.Next(0, _fonts.Count)],
                        new SolidBrush(GetRandomColor(_textColorDepth)),
                        i * _imageWidth / (text.Length + 1) * 1.2f,
                        (float)_random.NextDouble()
                    );

                    g.RotateTransform(-tempRndAngle);
                }

                InterferenceLines(ref g, text.Length * 2);

                ArraySegment<byte> bmpBytes;
                using (var ms = new MemoryStream())
                {
                    bmpOut.Save(ms, ImageFormat.Gif);
                    ms.TryGetBuffer(out bmpBytes);
                    bmpOut.Dispose();
                    ms.Dispose();
                }

                return bmpBytes.ToArray();
            }
        }


        public string GenerateRandomText(int textLength)
        {
            var result = new string(Enumerable.Repeat(_chars, textLength)
                  .Select(s => s[_random.Next(s.Length)]).ToArray());
            return result.ToUpper();
        }


        private static void InterferenceLines(ref Graphics g, int lines)
        {
            for (var i = 0; i < lines; i++)
            {
                var pan = new Pen(GetRandomColor(_interferenceColorDepth));
                var points = new Point[_random.Next(2, 5)];
                for (int pi = 0; pi < points.Length; pi++)
                {
                    points[pi] = new Point(_random.Next(0, _imageWidth), _random.Next(0, _imageHeight));
                }
    
                g.DrawCurve(pan, points);
            }
        }

        
        private static Color GetRandomColor(int depth)
        {
            int red = _random.Next(depth);
            int green = _random.Next(depth);
            int blue = (red + green > 400) ? 0 : 400 - red - green;
            blue = (blue > depth) ? depth : blue;
            return Color.FromArgb(red, green, blue);
        }
    }
}
