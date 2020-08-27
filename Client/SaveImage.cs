using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace Client
{
    /// <summary>
    /// Статический класс, который в отдельном потоке сохраняет
    /// принятые изображения в файл.
    /// </summary>

    static class SaveImage
    {
        #region Properties

        public static ConcurrentQueue<Bitmap> ImageQueue { get; private set; }

        #endregion

        #region Fields

        private static Thread saveImageThread;

        #endregion

        #region Events

        public static event Action<Bitmap> ShowImage;
        public static Action<string> ShowMessage;

        #endregion

        #region Constructor

        static SaveImage()
        {
            ImageQueue = new ConcurrentQueue<Bitmap>();
        }

        #endregion

        #region Methods

        public static void StartSaveToFile()
        {
            saveImageThread = new Thread(new ThreadStart(SaveToFile));
            saveImageThread.Start();
        }

        public static void StopSaveToFile()
        {
            saveImageThread?.Abort();
        }

        #endregion

        #region Thread SaveToFile()

        private static void SaveToFile()
        {
            int fName = 1;

            while (true)
            {
                while (ImageQueue.TryDequeue(out Bitmap jpgImage))
                {
                    try
                    {
                        ShowImage?.Invoke(jpgImage);

                        jpgImage.Save(String.Format("{0}.jpg", fName), ImageFormat.Jpeg);

                        ShowMessage($"File {fName}.jpg saved!");
                    }
                    catch (Exception ex)
                    {
                        ShowMessage?.Invoke(ex.Message);
                    }
                    fName++;
                }
            }
        }

        #endregion
    }
}
