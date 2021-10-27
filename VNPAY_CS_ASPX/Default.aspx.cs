using System;
using System.Configuration;
using log4net;
using VNPAY_CS_ASPX.Models;

namespace VNPAY_CS_ASPX
{
    public partial class _Default : System.Web.UI.Page
    {
        private static readonly ILog log =
          LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtOrderDesc.Text = "Nhap noi dung thanh toan";
                txtAmount.Text = "100000";
                txtExpire.Text = DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss");
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            //Get Config Info
            string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma website
            string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat
            if (string.IsNullOrEmpty(vnp_TmnCode) || string.IsNullOrEmpty(vnp_HashSecret))
            {
                lblMessage.Text = "Vui lòng cấu hình các tham số: vnp_TmnCode,vnp_HashSecret trong file web.config";
                return;
            }
            //Get payment input
            OrderInfo order = new OrderInfo();
            //Save order to db
            order.OrderId = DateTime.Now.Ticks;
            order.Amount = Convert.ToInt64(txtAmount.Text);
            order.OrderDesc = txtOrderDesc.Text;
            order.CreatedDate = DateTime.Now;
            string locale = cboLanguage.SelectedItem.Value;
            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", "2.0.1");
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
            if (cboBankCode.SelectedItem != null && !string.IsNullOrEmpty(cboBankCode.SelectedItem.Value))
            {
                vnpay.AddRequestData("vnp_BankCode", cboBankCode.SelectedItem.Value);
            }
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
            if (!string.IsNullOrEmpty(locale))
            {
                vnpay.AddRequestData("vnp_Locale", locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }
            vnpay.AddRequestData("vnp_OrderInfo", order.OrderDesc);
            vnpay.AddRequestData("vnp_OrderType", orderCategory.SelectedItem.Value); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());
            //Add Params of 2.0.1 Version
            vnpay.AddRequestData("vnp_ExpireDate",txtExpire.Text);
            //Billing
             vnpay.AddRequestData("vnp_Bill_Mobile", txt_billing_mobile.Text.Trim());
             vnpay.AddRequestData("vnp_Bill_Email",txt_billing_email.Text.Trim());
            var fullName = txt_billing_fullname.Text.Trim();
            if (! String.IsNullOrEmpty(fullName)) 
            {
                var indexof = fullName.IndexOf(' ');
                 vnpay.AddRequestData("vnp_Bill_FirstName", fullName.Substring(0, indexof));
                 vnpay.AddRequestData("vnp_Bill_LastName", fullName.Substring(indexof + 1, fullName.Length - indexof - 1));
            }
             vnpay.AddRequestData("vnp_Bill_Address", txt_inv_addr1.Text.Trim());
             vnpay.AddRequestData("vnp_Bill_City", txt_bill_city.Text.Trim());
             vnpay.AddRequestData("vnp_Bill_Country", txt_bill_country.Text.Trim());
             vnpay.AddRequestData("vnp_Bill_State", "");
           // Invoice
             vnpay.AddRequestData("vnp_Inv_Phone", txt_inv_mobile.Text.Trim());
             vnpay.AddRequestData("vnp_Inv_Email", txt_inv_email.Text.Trim());
             vnpay.AddRequestData("vnp_Inv_Customer", txt_inv_customer.Text.Trim());
             vnpay.AddRequestData("vnp_Inv_Address",txt_inv_addr1.Text.Trim());
             vnpay.AddRequestData("vnp_Inv_Company", txt_inv_company.Text);
             vnpay.AddRequestData("vnp_Inv_Taxcode", txt_inv_taxcode.Text);
             vnpay.AddRequestData("vnp_Inv_Type",cbo_inv_type.SelectedItem.Value);

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            log.InfoFormat("VNPAY URL: {0}", paymentUrl);
            Response.Redirect(paymentUrl);
        }


    }
}