using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Класс, отвечающий за прием данных по протоколу TCP,
    /// использует асинхронные методы
    /// </summary>

    class TcpConnection
    {
        #region Properties

        public string Ip { get; private set; }
        public int Port { get; private set; }
        public int ReceivePackets { get; private set; }
        public int LostPackets { get; private set; }

        #endregion

        #region Fields

        private const int BUF_SIZE = 1024;       

        private TcpClient client;
        private CancellationTokenSource cancelTokenSource;

        #endregion

        #region Events

        public event Action<string> ShowMessage;
        public event Action<Bitmap, int> DataReceived;

        #endregion

        #region Constructor

        public TcpConnection(string ip, string port)
        {
            if (IPAddress.TryParse(ip, out IPAddress ipAddress) && UInt16.TryParse(port, out ushort iPort))
            {
                Ip = ip;
                Port = iPort;

                ReceivePackets = 0;
                LostPackets = 0;

                cancelTokenSource = new CancellationTokenSource();
            }
            else
            {
                throw new ArgumentException("Incorrect connection settings!");
            }
        }

        #endregion

        #region Methods

        public void StartReceiveData()
        {
            try
            {
                Connect();
            }
            catch
            {
                throw;
            }

            ReceiveAsync();
        }

        public void StopReceiveData()
        {
            cancelTokenSource?.Cancel();
        }

        #endregion

        #region Functions

        private void Connect()
        {
            client = new TcpClient(Ip, Port);

            ShowMessage($"Connected to {Ip}:{Port}");
        }

        private async void ReceiveAsync()
        {
            var arrayData = new byte[BUF_SIZE];
            var listData = new List<byte>();
            int size;
            Bitmap bitmap;
            int msDataReceived;

            NetworkStream stream = client.GetStream();

            var sw = new Stopwatch();
            while (!cancelTokenSource.Token.IsCancellationRequested)
            {
                listData.Clear();
                await Task.Run(() => { while (!stream.DataAvailable) ; });
                sw.Restart();
                do
                {
                    size = await stream.ReadAsync(arrayData, 0, arrayData.Length);
                    listData.AddRange(arrayData);
                }
                while (stream.DataAvailable);
                sw.Stop();

                msDataReceived = (int)sw.ElapsedMilliseconds;

                try
                {
                    using (var ms = new MemoryStream(listData.ToArray()))
                    {
                        bitmap = new Bitmap(ms);
                    }

                    ReceivePackets++;

                    DataReceived?.Invoke(bitmap, msDataReceived);

                    ShowMessage("Data received!");
                }
                catch
                {
                    LostPackets++;

                    ShowMessage("Data lost!");
                }
            }
            stream.Close();
            client.Close();
        }

        #endregion
    }
}
