namespace UiFormApp
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class UiForm : Form
    {
        public UiForm()
        {
            this.InitializeComponent();
        }

        private async void DownloadBtnLeft_Click(object sender, System.EventArgs e)
        {
            var url = this.urlTextBoxLeft.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var source = await this.DownloadStringAsync(url);

                this.contentTxbLeft.Text = source;
            }
            catch (Exception ex)
            {
                this.contentTxbLeft.Text = ex.Message;
            }
            this.logLabelLeft.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
        }

        private async void DownloadBtnRight_Click(object sender, System.EventArgs e)
        {
            var url = this.urlTextBoxRight.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var source = await this.DownloadStringAsync(url);

            this.contentTxbRight.Text = source;
            }
            catch (Exception ex)
            {
                this.contentTxbRight.Text = ex.Message;
            }
            this.logLabelRight.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
        }

        private async Task<string> DownloadStringAsync(string url)
        {
            return await new WebClient().DownloadStringTaskAsync(url);
        }
    }
}
