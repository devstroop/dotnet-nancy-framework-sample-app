using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Hosting_Application
{
    public partial class FrmApp : Form
    {
        NancyHost nancyHost;
        string hostUri = "localhost";
        int port = 5000;
        public FrmApp()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            HostConfiguration hostConfigs = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            this.nancyHost = new NancyHost(hostConfigs, new Uri($"http://{hostUri}:{port}"));
            this.nancyHost.Start();
            UpdateUI();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.nancyHost.Stop();
            this.nancyHost.Dispose();
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (this.nancyHost != null)
            {
                this.valHost.Text = hostUri;
                this.valPort.Text = $"{port}";
                this.valStatus.Text = "Running";
            }
            else
            {
                this.valHost.Text = "NA";
                this.valPort.Text = "NA";
                this.valStatus.Text = "NA";
            }
        }
    }
}
