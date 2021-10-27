using System;
using System.Web;
using System.IO;
using System.Net;
using System.Configuration;
using VNPAY_CS_ASPX.Models;
using log4net;

namespace VNPAY_CS_ASPX
{
    public partial class vnpay_querydr : System.Web.UI.Page
    {
        private static readonly ILog Log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void btnQuery_Click(object sender, EventArgs e)
        {

            var vnpayApiUrl = ConfigurationManager.AppSettings["vnpay_api_url"];
            var vnpHashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"];
            var vnpTmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"];

            //Get payment input
            var vnpay = new VnPayLibrary();
            var createDate = DateTime.Now;

            vnpay.AddRequestData("vnp_Version", "2.0.1");
            vnpay.AddRequestData("vnp_Command", "querydr");
            vnpay.AddRequestData("vnp_TmnCode", vnpTmnCode);
            vnpay.AddRequestData("vnp_TxnRef", orderId.Text);
            vnpay.AddRequestData("vnp_OrderInfo", "queryDr OrderId:" + orderId.Text);
            vnpay.AddRequestData("vnp_TransDate", payDate.Text);
            vnpay.AddRequestData("vnp_CreateDate", createDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());

            var queryDr = vnpay.CreateRequestUrl(vnpayApiUrl, vnpHashSecret);

            var strDatax = "";
            var request = (HttpWebRequest)WebRequest.Create(queryDr);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
                if (stream != null)

                    using (var reader = new StreamReader(stream))
                    {
                        strDatax = reader.ReadToEnd();
                    }
            display.InnerHtml = "<b>VNPAY RESPONSE:</b> " + strDatax;
            
        }
    }
}