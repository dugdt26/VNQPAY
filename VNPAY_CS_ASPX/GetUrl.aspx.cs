using log4net;
using System;
using System.Configuration;
using VNPAY_CS_ASPX.Models;

namespace VNPAY_CS_ASPX
{
    /*
    Code cài đặt trong trường hợp show popup Cổng thanh toán VNPAY.
    Code này giống code của phần Redirect trong file default.aspx.cs
    */
    public partial class GetUrl : System.Web.UI.Page
    {
        private static readonly ILog log =
          LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Config Info
            string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma website
            string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat
            if (string.IsNullOrEmpty(vnp_TmnCode) || string.IsNullOrEmpty(vnp_HashSecret))
            {
                Response.Clear();
                Response.Write("{\"code\":\"01\",\"Message\":\"Vui lòng cấu hình các tham số: vnp_TmnCode,vnp_HashSecret trong file web.config\"}");
                Response.End();
                return;
            }
            //Get payment input
            OrderInfo order = new OrderInfo();
            //Save order to db
            order.OrderId = DateTime.Now.Ticks;
            order.Amount = Convert.ToInt64(Request.QueryString["txtAmount"]);
            order.OrderDesc = Request.QueryString["txtOrderDesc"];
            order.CreatedDate = DateTime.Now;
            string vnp_OrderType= Request.QueryString["orderCategory"];
            string vnp_BankCode = Request.QueryString["cboBankCode"];
            string vnp_Locale = Request.QueryString["cboLanguage"];// vn,en
            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", "2.0.0");
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
            if (string.IsNullOrEmpty(vnp_BankCode))
            {
                vnpay.AddRequestData("vnp_BankCode", vnp_BankCode);
            }
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", GetIpAddress());
            if (!string.IsNullOrEmpty(vnp_Locale))
            {
                vnpay.AddRequestData("vnp_Locale", vnp_Locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }

            vnpay.AddRequestData("vnp_OrderInfo", order.OrderDesc);

            if (!string.IsNullOrEmpty(vnp_OrderType))
            {
                vnpay.AddRequestData("vnp_OrderType", vnp_OrderType);
            }
            else
            {
                vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            }
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());
            
            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            log.InfoFormat("VNPAY URL: {0}", paymentUrl);
            Response.Clear();
            Response.Write("{\"code\":\"00\",\"Message\":\"Create payment url success\",\"data\":\"" + paymentUrl + "\"}");
            Response.End();
        }
        public string GetIpAddress()
        {
            string ipAddress;
            try
            {
                ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() == "unknown"))
                    ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            catch (Exception ex)
            {
                ipAddress = "Invalid IP:" + ex.Message;
            }

            return ipAddress;
        }
    }
}