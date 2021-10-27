using System;
using System.Web;
using System.IO;
using System.Net;
using System.Configuration;
using VNPAY_CS_ASPX.Models;
using log4net;

namespace VNPAY_CS_ASPX
{
    public partial class vnpay_refund : System.Web.UI.Page
    {
        private static readonly ILog Log =
       LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnRefund_Click(object sender, EventArgs e)
        {

            var vnpayApiUrl = ConfigurationManager.AppSettings["querydr"];
            var vnpHashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"];
            var vnpTmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"];
            var vnpay = new VnPayLibrary();
            var createDate = DateTime.Now;

            try
            {
                var amountrf = Convert.ToInt32(Amount.Text)*100;
                vnpay.AddRequestData("vnp_Version", "2.0.1");
                vnpay.AddRequestData("vnp_Command", "refund");
                vnpay.AddRequestData("vnp_TmnCode", vnpTmnCode);

                vnpay.AddRequestData("vnp_TransactionType", RefundCategory.Text);
                vnpay.AddRequestData("vnp_CreateBy", Email.Text);
                vnpay.AddRequestData("vnp_TxnRef", OrderId.Text);
                vnpay.AddRequestData("vnp_Amount", amountrf.ToString());
                vnpay.AddRequestData("vnp_OrderInfo", "REFUND ORDERID:" + OrderId.Text);
                vnpay.AddRequestData("vnp_TransDate", payDate.Text);
                vnpay.AddRequestData("vnp_CreateDate", createDate.ToString("yyyyMMddHHmmss"));
                vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());

                var strDatax = "";

                var refundtUrl = vnpay.CreateRequestUrl(vnpayApiUrl, vnpHashSecret);

                var request = (HttpWebRequest)WebRequest.Create(refundtUrl);
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
            catch(Exception ex)
            {
                displaymessage.InnerText = "Có lỗi sảy ra trong quá trình hoàn tiền:"+ ex;
            }
        }
    }
}