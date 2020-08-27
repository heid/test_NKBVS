using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace Server
{   
    /// <summary>
    /// Класс, отвечающий за генерацию изображения в оттенках серого цвета
    /// в отдельном потоке.
    /// </summary>

    class GrayImage
    {
        #region Properties

        public int Width { get; private set; }
        public int Height { get; private set; }

        #endregion

        #region Fields

        private Thread imageThread;

        private const int MAX_WIDTH = 1920;
        private const int MAX_HEIGHT = 1080;

        #endregion

        #region Events

        public event Action<string> ShowMessage;
        public event Action<Bitmap, int, int> ImageGenerated;

        #endregion

        #region Constructor

        public GrayImage(int width, int height)
        {
            if (width > MAX_WIDTH || height > MAX_HEIGHT)
            {
                throw new ArgumentException("The image is too large. Maximum FullHD size!");
            }

            Width = width;
            Height = height;
        }

        #endregion

        #region Methods

        public void StartGenerate(int msPeriodGenerate)
        {
            imageThread = new Thread(new ParameterizedThreadStart(Generate));
            imageThread.Start(msPeriodGenerate);
        }

        public void StopGenerate()
        {
            imageThread.Abort();
        }

        public static byte[] GrayImageToByte(Bitmap bitmap)
        {
            ImageConverter converter = new ImageConverter();

            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }

        #endregion

        #region Thread Generate

        private void Generate(object msPeriodGenerate)
        {
            Bitmap image;
            int msImageGenerated;
            int msFramePeriod;
            int millisecondsDelay;

            var sw = new Stopwatch();
            while (true)
            {
                try
                {
                    sw.Restart();
                    image = GenerateGrayImage();

                    msImageGenerated = (int)sw.ElapsedMilliseconds;
                    millisecondsDelay = (int)msPeriodGenerate - msImageGenerated;
                    if (millisecondsDelay > 0)
                    {
                        Thread.Sleep(millisecondsDelay);
                    }
                    sw.Stop();
                    msFramePeriod = (int)sw.ElapsedMilliseconds;

                    ImageGenerated?.Invoke(image, msImageGenerated, msFramePeriod);
                }
                catch (Exception ex)
                {
                    ShowMessage?.Invoke(ex.Message);
                }
            }
        }

        #endregion

        #region Functions

        private unsafe Bitmap GenerateGrayImage()
        {
            var rnd = new Random();

            var bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte grayColor;
                byte* p = (byte*)(void*)bmData.Scan0.ToPointer();
                int stopAddress = (int)p + bmData.Stride * bmData.Height;
                while ((int)p != stopAddress)
                {
                    grayColor = (byte)rnd.Next(Byte.MaxValue + 1);
                    p[0] = grayColor;
                    p[1] = grayColor;
                    p[2] = grayColor;
                    p += 3;
                }
            }
            bitmap.UnlockBits(bmData);

            return bitmap;
        }

        #endregion
    }
}
