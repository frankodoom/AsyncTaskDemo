using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  void btnSynch_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://www.bing.com");
            MessageBox.Show(response.Result.ToString());
        }

        private async void btnAsynch_Click(object sender, EventArgs e)
        {
             await Browse("http://www.bing.com");
        }



        public async Task Browse(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var threadId =Thread.CurrentThread.IsThreadPoolThread;
            MessageBox.Show("Request Returned Http StatusCode:" +  response.StatusCode + " using Thread :  "   + threadId);
        }
    }
}
                                         