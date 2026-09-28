using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using DVLD_Business_Layer;

namespace DVLD_Solution
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private async Task LoadPeopleDataAsync()
        {
            DataTable dataTable = await clsPeopleBusiness.GetAllPeople();

            if(dataTable != null && dataTable.Rows.Count > 0)
            {
                string jsonString = JsonConvert.SerializeObject(dataTable);
                string script = $"loadReportData({jsonString});";

                await webView21.ExecuteScriptAsync(script);
            }
        }
        private async Task LoadUsersDataAsync()
        {
            // استدعاء الدالة من كلاس clsUserBusiness الذي يعيد DataTable ببيانات الاستعلام المدمج
            DataTable dataTable = await clsUsersBusines.GetUsersReport();

            if (dataTable != null)
            {
                // تحويل DataTable إلى JSON مباشرة
                string jsonString = JsonConvert.SerializeObject(dataTable);

                // إرسال البيانات لدالة الجافاسكربت
                string script = $"loadReportData({jsonString});";
                await webView21.ExecuteScriptAsync(script);
            }
        }
        private async void frmReports_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
        }

        private void btnReportPeople_Click(object sender, EventArgs e)
        {
            string htmlPath = Path.Combine(Application.StartupPath, @"Reports\DVLD Reports People.html");
            if (File.Exists(htmlPath))
            {
                webView21.Source = new Uri(htmlPath);

                webView21.CoreWebView2.NavigationCompleted += async (s, args) =>
                {
                    if (args.IsSuccess)
                    {
                        await LoadPeopleDataAsync();
                    }
                };
            }
        }

        private void btnReportUsers_Click(object sender, EventArgs e)
        {
            // 2. Load HTML File
            string htmlPath = Path.Combine(Application.StartupPath, @"C:\Users\Administrator\Downloads\DVLD Repors Users.html");
            if (File.Exists(htmlPath))
            {
                webView21.Source = new Uri(htmlPath);

                webView21.CoreWebView2.NavigationCompleted += async (s, args) =>
                {
                    if (args.IsSuccess)
                    {
                        await LoadUsersDataAsync();
                    }
                };
            }
        }

    }
}
