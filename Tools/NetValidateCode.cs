using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace EmployeeManagement.Tools
{
    public class NetValidateCode
    {

        private int _length = 4;                        //验证码长度
        private int _fontSize = 18;              //字体最大尺寸
        private int _border = 0;                      //边框，0时没有连框
        private Color _backgroundColor = Color.AliceBlue;      //背景色
        private Color _fontColor = Color.Blue;          //验证码色51aspx
        private int _rateNumber = 10;              //验证码中的数字出现机率  ，越大出现的数字机率越大
        private string _randomChars;              //随机生成的验证码
        private int _randomAngle = 40;              //随机码的旋转角度
        private string _fontFamily = "Verdana";        //字体
        private int _chaosNumber = 0;                //噪点数量  ,0  时不用
        private Random random = new Random();    //随机种子，公用
        public NetValidateCode()
        {

        }
        ///  <summary>
        ///  重载一  ：噪点
        ///  </summary>
        ///  <param  name="chaosNumber"></param>
        public NetValidateCode(int chaosNumber)
        {
            _chaosNumber = chaosNumber;
        }
        ///  <summary>
        ///  重载二：长度，噪点
        ///  </summary>
        ///  <param  name="length"></param>
        ///  <param  name="chaosNumber"></param>
        public NetValidateCode(int length, int chaosNumber)
        {
            _length = length;
            _chaosNumber = chaosNumber;
        }
        ///  <summary>
        ///  重载三：长度，噪点，数字机率
        ///  </summary>
        ///  <param  name="length"></param>
        ///  <param  name="chaosNumber"></param>
        ///  <param  name="rate">越大，生成的随机码中数字占的比例越多</param>
        public NetValidateCode(int length, int chaosNumber, int rate)
        {
            _length = length;
            _chaosNumber = chaosNumber;
            _rateNumber = rate;
        }

        #region  .Length  验证码长度(默认4个)
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        #endregion
        #region  .FontSize  字体最大尺寸(默认18)
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }
        #endregion
        #region  .Border  边框（默认0  没有连框）
        public int Border
        {
            get { return _border; }
            set { _border = value; }
        }
        #endregion
        #region  .BackgroundColor  自定义背景色(默认Color.AliceBlue)
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }
        #endregion
        #region  .FontColor  验证码色(默认Color.Blue)
        public Color FontColor
        {
            get { return _fontColor; }
            set { _fontColor = value; }
        }
        #endregion
        #region  .RandomCode    随机生成的验证码
        public string RandomCode
        {
            get { return _randomChars; }
            set { _randomChars = value.ToUpper(); }
        }
        #endregion
        #region  .RateNumber  验证码中的数字出现机率,越大出现的数字机率越大(默认10)
        public int RateNumber
        {
            get { return _rateNumber; }
            set { _rateNumber = value; }
        }
        #endregion
        #region  .RandomAngle  随机码的旋转角度(默认40度)
        public int RandomAngle
        {
            get { return _randomAngle; }
            set { _randomAngle = value; }
        }
        #endregion
        #region  .FontFamily  字体
        public string FontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }
        #endregion
        #region  .ChaosNumber  噪点数量(默认值为2)
        public int ChaosNumber
        {
            get { return _chaosNumber; }
            set { _chaosNumber = value; }
        }
        #endregion


        ///  <summary>
        ///  生成随机验证码
        ///  </summary>
        private void CreateCode()
        {
            //有外部输入验证码时不用产生，否则随机生成
            if (!string.IsNullOrEmpty(_randomChars))
            { return; }
            char code;
            for (int i = 0; i < _length; i++)
            {
                int rand = random.Next();
                if (rand % _rateNumber == 0)
                { code = (char)('A' + (char)(rand % 26)); }
                else
                { code = (char)('0' + (char)(rand % 10)); }
                _randomChars += code.ToString();
            }
        }

        ///  <summary>
        ///  背景噪点生成
        ///  </summary>
        ///  <param  name="graph"></param>
        private void CreateBackgroundChaos(Bitmap map, Graphics graph)
        {
            Pen blackPen = new Pen(Color.Azure, 0);
            for (int i = 0; i < map.Width * 2; i++)
            {
                int x = random.Next(map.Width);
                int y = random.Next(map.Height);
                graph.DrawRectangle(blackPen, x, y, 1, 1);
            }
        }
        ///  <summary>
        ///  前景色噪点
        ///  </summary>
        ///  <param  name="map"></param>
        private void CreaetForeChaos(Bitmap map)
        {
            for (int i = 0; i < map.Width * _chaosNumber; i++)
            {
                int x = random.Next(map.Width);
                int y = random.Next(map.Height);
                //map.SetPixel(x,  y,  Color.FromArgb(random.Next(300)));
                map.SetPixel(x, y, _fontColor);
            }
        }

        ///  <summary>
        ///  创建随机码图片
        ///  </summary>
        ///  <param  name="context"></param>
        public byte[] CreateImage()
        {
            CreateCode();          //创建验证码
            Bitmap map = new Bitmap((int)(_randomChars.Length * 15), 24);                            //创建图片背景
            Graphics graph = Graphics.FromImage(map);

            try
            {
                //graph.FillRectangle(new  SolidBrush(Color.Black),  0,  0,  map.Width+1,  map.Height+1);          //填充一个有背景的矩形

                //if  (_border  >  0)  //画一个边框
                //{
                //        graph.DrawRectangle(new  Pen(Color.Black,  0),  0,  0,  map.Width  -  _border,  map.Height  -  _border);
                //}        
                //graph.SmoothingMode  =  System.Drawing.Drawing2D.SmoothingMode.AntiAlias;        //模式
                graph.Clear(_backgroundColor);              //清除画面，填充背景
                SolidBrush brush = new SolidBrush(_fontColor);    //画笔
                Point dot = new Point(12, 12);
                //CreateBackgroundChaos(map,graph);              //背景噪点生成
                CreaetForeChaos(map);              //前景色噪点
                                                    //文字距中
                StringFormat format = new StringFormat(StringFormatFlags.NoClip);
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                //验证码旋转，防止机器识别
                char[] chars = _randomChars.ToCharArray();            //拆散字符串成单字符数组
                for (int i = 0; i < chars.Length; i++)
                {
                    Font fontstyle = new Font(_fontFamily, random.Next(_fontSize - 3, _fontSize), FontStyle.Regular);            //字体样式
                    float angle = random.Next(-_randomAngle, _randomAngle);            //转动的度数
                    graph.TranslateTransform(dot.X, dot.Y);          //移动光标到指定位置
                    graph.RotateTransform(angle);
                    graph.DrawString(chars[i].ToString(), fontstyle, brush, -2, 2, format);
                    graph.RotateTransform(-angle);                    //转回去
                    graph.TranslateTransform(2, -dot.Y);          //移动光标到指定位置
                }

                //生成图片
                MemoryStream ms = new MemoryStream();
                map.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            finally
            {
                graph.Dispose();
                map.Dispose();
            }
        }
    }
}