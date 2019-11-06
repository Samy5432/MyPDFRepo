<%@ Page Title="Set Password to PDF" Language="C#" MasterPageFile="~/MasterPage/PDFToolsMasterPage.Master" AutoEventWireup="true" CodeBehind="PasswordProtectPDF.aspx.cs" Inherits="PDFTools.PDFManager.PasswordProtectPDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
        width: 55%;
    }
        .auto-style2 {
            width: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HTMLRender_ContentPlaceHolder" runat="server">
    <table align="center" class="auto-style1">
    <tr>
        <td>&nbsp;</td>
        <td align="center">
            <asp:Label ID="Label11" runat="server" Text="PDF File"></asp:Label>
        </td>
        <td align="left">
            <asp:FileUpload ID="fileUpload" runat="server" TabIndex="1" />
        </td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" BackColor="#FFCC99" ControlToValidate="fileUpload" ErrorMessage="Please select a PDF file"></asp:RequiredFieldValidator>
        </td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td align="right">
            <asp:Label ID="Label12" runat="server" Text="Enter Password"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" BorderColor="#CCCCCC" BorderWidth="1px" TabIndex="2"></asp:TextBox>
        </td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="#FFCC99" ControlToValidate="txtPwd" ErrorMessage="Password Cannot be blank" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td align="left">
            <asp:Button ID="btnSetPwd" runat="server" OnClick="btnSetPwd_Click" Text="Set Password" TabIndex="3" />
        </td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblUploadResult" runat="server"></asp:Label>
        </td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
</table>
</asp:Content>
