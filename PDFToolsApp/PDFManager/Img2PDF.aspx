<%@ Page Title="Convert Image to PDF" Language="C#" MasterPageFile="~/MasterPage/PDFToolsMasterPage.Master" AutoEventWireup="true" CodeBehind="Img2PDF.aspx.cs" Inherits="PDFTools.PDFManager.Img2PDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 51%;
        }
        .auto-style2 {
            width: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HTMLRender_ContentPlaceHolder" runat="server">
    <table align="center" class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Image File"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="fileUpload" runat="server" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="#FFCC99" ControlToValidate="fileUpload" ErrorMessage="Please select a PDF file"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td align="left">
                <asp:Button ID="btnConvert" runat="server" OnClick="btnConvert_Click" Text="Convert" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblUploadResult" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
