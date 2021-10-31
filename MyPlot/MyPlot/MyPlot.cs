using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPlot
{
    public partial class MyPlot : Form
    {
        private ConfigureMain playersConfig;

        public MyPlot()
        {
            InitializeComponent();
        }

        private async void MyPlot_Load(object sender, EventArgs e)
        {
            //Load the configurations of all players.
            playersConfig = new ConfigureMain();
            playersConfig.LoadConfigure("C:\\videodev360gps\\config_default.json");

            SetPlayerControlSize();

            webView21.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            Debug.WriteLine("before InitializeAsync");
            await InitializeAsync();
            Debug.WriteLine("after InitializeAsync");
            if ((webView21 == null) || (webView21.CoreWebView2 == null))
            {
                Debug.WriteLine("not ready");
            }
            webView21.NavigateToString(System.IO.File.ReadAllText("browse_index.html"));
            Debug.WriteLine("after NavigateToString");
        }

        private async Task InitializeAsync()
        {
            Debug.WriteLine("InitializeAsync");
            await webView21.EnsureCoreWebView2Async(null);
            Debug.WriteLine("WebView2 Runtime version: " + webView21.CoreWebView2.Environment.BrowserVersionString);
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Debug.WriteLine("WebView_CoreWebView2InitializationCompleted");
        }

        private void MyPlot_Resize(object sender, EventArgs e)
        {
            SetPlayerControlSize();
        }

        private void SetPlayerControlSize()
        {
            Size newSize = ClientSize;

            //Set main player to occupy the whole client area.
            vlcCtrlMain.Location = new Point(0, 0);
            vlcCtrlMain.Size = newSize;

            //Set PIP web player at the bottom right corner
            newSize.Width = ClientSize.Width / 3;
            newSize.Height = ClientSize.Height / 3;
            webView21.Location = new Point(ClientSize.Width - newSize.Width, ClientSize.Height - newSize.Height);
            webView21.Size = newSize;

            //Set Audio player at the bottom left
            newSize.Width = ClientSize.Width * 2 / 3;
            newSize.Height = ClientSize.Height / 6;
            vlcCtrlAudio.Location = new Point(0, ClientSize.Height - newSize.Height);
            vlcCtrlAudio.Size = newSize;

            //Set Radio player at the right up
            newSize.Width = ClientSize.Width / 6;
            newSize.Height = ClientSize.Height * 2 / 3;
            vlcCtrlRadio.Location = new Point(ClientSize.Width - newSize.Width, 0);
            vlcCtrlRadio.Size = newSize;
        }
    }
}
