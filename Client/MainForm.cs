using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        private Graphics g;
        private TcpConnection tcpConnection;

        public MainForm()
        {
            InitializeComponent();

            g = this.CreateGraphics();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SaveImage.ShowImage += SaveImage_ShowImage;
            SaveImage.ShowMessage += ConsoleMessage;
        }

        void SaveImage_ShowImage(Bitmap obj)
        {
            g.DrawImage(obj, new Rectangle(15, 270, 150, 150));
        }

        private void TcpConnection_DataReceived(Bitmap bitmap, int msDataReceived)
        {
            lblPreview.Text = $"Preview ({bitmap.Width} x {bitmap.Height})";

            SaveImage.ImageQueue.Enqueue(bitmap);

            lblNetReceive.Text = $"Data received in {msDataReceived} ms";
        }

        private void ConsoleMessage(string message)
        {
            if (tcpConnection != null)
            {
                lblNetStat.Text = $"Receive packets: {tcpConnection.ReceivePackets} Lost: {tcpConnection.LostPackets}";
            }
            tbConsole.BeginInvoke((MethodInvoker)(() => tbConsole.AppendText($"[{DateTime.Now}] {message} {Environment.NewLine}")));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                SaveImage.StartSaveToFile();

                try
                {
                    tcpConnection = new TcpConnection(tbIp.Text, tbPort.Text);
                    tcpConnection.ShowMessage += ConsoleMessage;
                    tcpConnection.DataReceived += TcpConnection_DataReceived;
                    tcpConnection.StartReceiveData();
                }
                catch (Exception ex)
                {
                    ConsoleMessage(ex.Message);

                    return;
                }

                btnConnect.Text = "Disconnect";
                tbIp.Enabled = false;
                tbPort.Enabled = false;
            }
            else
            {
                tcpConnection.StopReceiveData();
                tcpConnection = null;

                btnConnect.Text = "Connect";
                tbIp.Enabled = true;
                tbPort.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpConnection?.StopReceiveData();

            SaveImage.StopSaveToFile();
        }
    }
}
