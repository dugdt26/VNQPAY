<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vnpay_querydr.aspx.cs" Inherits="VNPAY_CS_ASPX.vnpay_querydr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>VNPAY DEMO QUERYDR</title>
        <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    </head>
<body>
    <div class="container">
        <div class="header clearfix">
                 
                <h3 class="text-muted">VNPAY DEMO QUERYDR</h3>
        </div>
            <div class="table-responsive">
            <form id="form1" runat="server">
            <div class="form-group">
                 <label >Mã giao dịch(*)</label>
                 <asp:TextBox ID="orderId" runat="server" CssClass="form-control"></asp:TextBox>
 
                 </div>
            <div class="form-group">
                 <label >Ngày thanh toán(*)</label>
                 <asp:TextBox ID="payDate" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
                <asp:Button ID="btnSearch" runat="server" Text="QueryDr" placeholder="yyyyMMddHHmmss" CssClass="btn btn-default" OnClick="btnQuery_Click" />
          
            <div runat="server" id="display" style="padding-top: 20px"></div>

        </form>
        </div>
    </div>
    
</body>
</html>
