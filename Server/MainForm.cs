using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server
{
    public partial class MainForm : Form
    {
        private GrayImage image;
        private TcpConnection connection;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Config.Load("config.xml");
                ConsoleMessage("Data loaded successfully.");

                image = new GrayImage(Config.getInstance().ResolutionX, Config.getInstance().ResolutionY);
                image.ImageGenerated += image_ImageGenerated;
                image.StartGenerate(Config.getInstance().FrameRate);

                connection = new TcpConnection(Config.getInstance().Ip, Config.getInstance().Port.ToString());
                connection.DataSent += connection_DataSent;
                connection.ShowMessage += ConsoleMessage;
                connection.StartSend(Config.getInstance().NetSpeed);
            }
            catch (ArgumentException ex)
            {
                ConsoleMessage(ex.Message);

                return;
            }
            catch (FormatException ex)
            {
                ConsoleMessage(ex.Message);

                return;
            }
            catch (Exception ex)
            {
                ConsoleMessage(ex.Message);
                ConsoleMessage("Default data loaded.");
            }
        }

        private void connection_DataSent(int msDataSending)
        {
            lblNet.Text = $"Data transferred in {msDataSending} ms";
        }

        private void image_ImageGenerated(Bitmap bitmap, int msImageGenerated, int msFramePeriod)
        {
            TcpConnection.imageCollection.TryAdd(bitmap);

            lblImage.BeginInvoke((MethodInvoker)(() => lblImage.Text = $"The image was generated in {msImageGenerated} ms"));
            var fps = (int)Math.Round(1.0 / (msFramePeriod / 1000.0));
            lblFps.BeginInvoke((MethodInvoker)(() => lblFps.Text = $"Fps {fps}"));
        }

        private void ConsoleMessage(string message)
        {
            tbConsole.BeginInvoke((MethodInvoker)(() => tbConsole.AppendText($"[{DateTime.Now}] {message} {Environment.NewLine}")));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            image?.StopGenerate();
        }
    }
}
