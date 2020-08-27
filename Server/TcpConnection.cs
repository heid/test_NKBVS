using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// Класс отвечающий за передачу изображений по протоколу TCP,
    /// используются асинхронные методы
    /// </summary>

    class TcpConnection
    {
        #region Properties

        public string Ip { get; private set; }
        public int Port { get; private set; }

        #endregion

        #region Fields

        private const int QUEUE_SIZE = 10;

        public static BlockingCollection<Bitmap> imageCollection;
        private CancellationTokenSource cancelTokenSource;

        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;

        #endregion

        #region Events

        public event Action<string> ShowMessage;
        public event Action<int> DataSent;

        #endregion

        #region Constructor

        public TcpConnection(string ip, string port)
        {
            if (IPAddress.TryParse(ip, out IPAddress ipAddress) && UInt16.TryParse(port, out ushort iPort))
            {
                Ip = ip;
                Port = iPort;

                cancelTokenSource = new CancellationTokenSource();
                imageCollection = new BlockingCollection<Bitmap>(QUEUE_SIZE);
            }
            else
            {
                throw new FormatException("Invalid ip address format.");
            }
        }

        #endregion

        #region Methods

        public void StartSend(int msPeriodSend)
        {
            try
            {
                StartListen();
            }
            catch
            {
                throw;
            }

            SendAsync(msPeriodSend);
        }

        public void StopSend()
        {
            cancelTokenSource?.Cancel();
        }

        #endregion

        #region Functions

        private void StartListen()
        {
            server = new TcpListener(IPAddress.Parse(Ip), Port);
            server.Start();

            ShowMessage("Server started!");
        }

        private async void SendAsync(int msPeriodSend)
        {
            int msDataSending;

            var sw = new Stopwatch();
            while (true)
            {
                ShowMessage("Waiting for a connection...");
                client = await server.AcceptTcpClientAsync();
                ShowMessage("Connected!");

                stream = client.GetStream();

                int millisecondsDelay;
                while (!cancelTokenSource.Token.IsCancellationRequested)
                {
                    sw.Restart();
                    try
                    {
                        if (imageCollection.TryTake(out Bitmap bmp))
                        {
                            var data = await Task.Run(() => GrayImage.GrayImageToByte(bmp));
                            await stream.WriteAsync(data, 0, data.Length);
                        }
                    }
                    catch
                    {
                        client.Close();
                        ShowMessage("Client disconnected!");

                        break;
                    }
                    sw.Stop();

                    ShowMessage("Data sent!");

                    msDataSending = (int)sw.ElapsedMilliseconds;
                    
                    DataSent?.Invoke(msDataSending);

                    millisecondsDelay = msPeriodSend - msDataSending;
                    if (millisecondsDelay > 0)
                    {
                        await Task.Delay(millisecondsDelay, cancelTokenSource.Token);
                    }
                }
            }
        }

        #endregion
    }
}
