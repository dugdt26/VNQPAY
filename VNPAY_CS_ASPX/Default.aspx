<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VNPAY_CS_ASPX._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VNPAY DEMO</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="header clearfix">

            <h3 class="text-muted">VNPAY DEMO</h3>
        </div>
        <div class="table-responsive">
            <form id="form1" runat="server">
                <h3>Thông tin thanh toán </h3>

                <div class="form-group">
                    <label>Loại hàng hóa (*) </label>
                    <asp:DropDownList ID="orderCategory" runat="server" CssClass="form-control">
                        <asp:ListItem Value="topup" Text="Nạp tiền điện thoại"></asp:ListItem>
                        <asp:ListItem Value="billpayment" Text="Thanh toán hóa đơn"></asp:ListItem>
                        <asp:ListItem Value="fashion" Text="Thời trang"></asp:ListItem>
                        <asp:ListItem Value="other" Text="Thanh toán trực tuyến"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Số tiền (*)</label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Nội dung thanh toán (*)</label>
                    <asp:TextBox ID="txtOrderDesc" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Ngân hàng</label>
                    <asp:DropDownList ID="cboBankCode" runat="server" CssClass="form-control">
                        <asp:ListItem Value="" Text="Không chọn"></asp:ListItem>
                        <asp:ListItem Value="VNPAYQR" Text="VNPAYQR"></asp:ListItem>
                        <asp:ListItem Value="VNBANK" Text="LOCAL BANK"></asp:ListItem>
                        <asp:ListItem Value="IB" Text="INTERNET BANKING"></asp:ListItem>
                        <asp:ListItem Value="INTCARD" Text="INTERNATIONAL CARD"></asp:ListItem>
                        <asp:ListItem Value="VISA" Text="VISA"></asp:ListItem>
                        <asp:ListItem Value="MASTERCARD" Text="MASTERCARD"></asp:ListItem>
                        <asp:ListItem Value="JCB" Text="JCB"></asp:ListItem>
                        <asp:ListItem Value="UPI" Text="UPI"></asp:ListItem>
                        <asp:ListItem Value="NCB" Text="Ngan hang NCB"></asp:ListItem>
                        <asp:ListItem Value="SACOMBANK" Text="Ngan hang SacomBank"></asp:ListItem>
                        <asp:ListItem Value="EXIMBANK" Text="Ngan hang EximBank"></asp:ListItem>
                        <asp:ListItem Value="MSBANK" Text="Ngan hang MSBANK"></asp:ListItem>
                        <asp:ListItem Value="NAMABANK" Text="Ngan hang NamABank "></asp:ListItem>
                        <asp:ListItem Value="VNMART" Text="Vi dien tu VnMart"></asp:ListItem>
                        <asp:ListItem Value="VIETINBANK" Text="Ngan hang Vietinbank"></asp:ListItem>
                        <asp:ListItem Value="VIETCOMBANK" Text="Ngan hang VCB"></asp:ListItem>
                        <asp:ListItem Value="HDBANK" Text="Ngan hang HDBank"></asp:ListItem>
                        <asp:ListItem Value="DONGABANK" Text="Ngan hang Dong A"></asp:ListItem>
                        <asp:ListItem Value="TPBANK" Text="Ngân hàng TPBank"></asp:ListItem>
                        <asp:ListItem Value="OJB" Text="Ngân hàng OceanBank"></asp:ListItem>
                        <asp:ListItem Value="BIDV" Text="Ngân hàng BIDV"></asp:ListItem>
                        <asp:ListItem Value="TECHCOMBANK" Text="Ngân hàng Techcombank"></asp:ListItem>
                        <asp:ListItem Value="VPBANK" Text="Ngan hang VPBank"></asp:ListItem>
                        <asp:ListItem Value="AGRIBANK" Text="Ngan hang Agribank"></asp:ListItem>
                        <asp:ListItem Value="ACB" Text="Ngan hang ACB"></asp:ListItem>
                        <asp:ListItem Value="OCB" Text="Ngan hang Phuong Dong"></asp:ListItem>
                        <asp:ListItem Value="SCB" Text="Ngan hang SCB"></asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="form-group">
                    <label>Ngôn ngữ  (*)</label>
                    <asp:DropDownList ID="cboLanguage" CssClass="form-control" runat="server">
                        <asp:ListItem Value="vn" Text="Tiếng Việt"></asp:ListItem>
                        <asp:ListItem Value="en" Text="English"></asp:ListItem>
                    </asp:DropDownList>

                </div>


                <div class="form-group">
                    <label>Thời hạn thanh toán</label>
                    <asp:TextBox ID="txtExpire" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <h3>Thông tin hóa đơn (Billing)</h3>
                </div>
                <div class="form-group">
                    <label>Họ tên (*)</label>
                    <asp:TextBox ID="txt_billing_fullname" runat="server" CssClass="form-control">NGUYEN VAN XO</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Email (*)</label>
                    <asp:TextBox ID="txt_billing_email" runat="server" CssClass="form-control">xonv@vnpay.vn</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Số điện thoại (*)</label>
                    <asp:TextBox ID="txt_billing_mobile" runat="server" CssClass="form-control">0934998386</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Địa chỉ (*)</label>
                    <asp:TextBox ID="txt_billing_addr1" runat="server" CssClass="form-control">22 Lang Ha</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Mã bưu điện (*)</label>
                    <asp:TextBox ID="txt_postalcode" runat="server" CssClass="form-control">100000</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Tỉnh/TP (*)</label>
                    <asp:TextBox ID="txt_bill_city" runat="server" CssClass="form-control">Hà Nội</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Bang (Áp dụng cho US,CA)</label>
                    <asp:TextBox ID="txt_bill__state" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Quốc gia (*)</label>
                    <asp:TextBox ID="txt_bill_country" runat="server" CssClass="form-control">VN</asp:TextBox>

                </div>
                <div class="form-group">
                    <h3>Thông tin giao hàng (Shipping)</h3>
                </div>
                <div class="form-group">
                    <label>Họ tên (*)</label>
                    <asp:TextBox ID="txt_ship_fullname" runat="server" CssClass="form-control">Nguyễn Thế Vinh</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Email (*)</label>
                    <asp:TextBox ID="txt_ship_email" runat="server" CssClass="form-control">vinhnt@vnpay.vn</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Số điện thoại (*)</label>
                    <asp:TextBox ID="txt_ship_mobile" runat="server" CssClass="form-control">0123456789</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Địa chỉ (*)</label>
                    <asp:TextBox ID="txt_ship_addr1" runat="server" CssClass="form-control">Phòng 315, Công ty VNPAY, Tòa nhà TĐL, 22 Láng Hạ, Đống Đa, Hà Nội</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Mã bưu điện (*)</label>
                    <asp:TextBox ID="txt_ship_postalcode" runat="server" CssClass="form-control">1000000</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Tỉnh/TP (*)</label>
                    <asp:TextBox ID="txt_ship_city" runat="server" CssClass="form-control">Hà Nội</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Bang (Áp dụng cho US,CA)</label>
                    <asp:TextBox ID="txt_ship_state" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Quốc gia (*)</label>
                    <asp:TextBox ID="txt_ship_country" runat="server" CssClass="form-control">VN</asp:TextBox>

                </div>

                <div class="form-group">
                    <h3>Thông tin gửi Hóa đơn điện tử (Invoice)</h3>
                </div>
                <div class="form-group">
                    <label>Tên khách hàng</label>
                    <asp:TextBox ID="txt_inv_customer" runat="server" CssClass="form-control">Lê Văn Phổ</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Công ty</label>
                    <asp:TextBox ID="txt_inv_company" runat="server" CssClass="form-control">Công ty Cổ phần giải pháp Thanh toán Việt Nam</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Địa chỉ</label>
                    <asp:TextBox ID="txt_inv_addr1" runat="server" CssClass="form-control">22 Láng Hạ, Phường Láng Hạ, Quận Đống Đa, TP Hà Nội</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Mã số thuế</label>
                    <asp:TextBox ID="txt_inv_taxcode" runat="server" CssClass="form-control">0102182292</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Loại hóa đơn</label>
                    <asp:DropDownList ID="cbo_inv_type" runat="server" CssClass="form-control">
                        <asp:ListItem Value="I" Text="Cá Nhân"></asp:ListItem>
                        <asp:ListItem Value="O" Text="Công ty/Tổ chức"></asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="form-group">
                    <label>Email</label>
                    <asp:TextBox ID="txt_inv_email" runat="server" CssClass="form-control">pholv@vnpay.vn</asp:TextBox>

                </div>
                <div class="form-group">
                    <label>Điện thoại</label>
                    <asp:TextBox ID="txt_inv_mobile" runat="server" CssClass="form-control">02437764668</asp:TextBox>

                </div>
                <asp:Button ID="btnPay" runat="server" Text="Thanh toán (Redirect)" CssClass="btn btn-default" OnClick="btnPay_Click" />
                &nbsp;&nbsp;
                    <button type="submit" class="btn btn-default" runat="server" id="btnPayPopup">Thanh toán (Popup)</button>
            </form>
            <asp:Label runat="server" ID="lblMessage" ForeColor="#FF3300"></asp:Label>
        </div>
    </div>

    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="https://pay.vnpay.vn/lib/vnpay/vnpay.css" rel="stylesheet" />
    <script type="text/javascript" src="https://pay.vnpay.vn/lib/vnpay/vnpay.min.js"></script>
    <script type="text/javascript">

        $("#btnPayPopup").click(function () {
            var postData = $("#form1").serialize();
            var submitUrl = "<%=ResolveUrl("/GetUrl.aspx") %>";
            $.ajax({
                type: "GET",
                url: submitUrl,
                data: postData,
                dataType: 'JSON',
                success: function (x) {
                    if (x.code === '00') {
                        if (window.vnpay) {
                            vnpay.open({ width: 768, height: 600, url: x.data });
                        } else {
                            location.href = x.data;
                        }
                        return false;
                    } else {
                        alert(x.Message);
                    }
                }
            });
            return false;
        });

    </script>
</body>
</html>
