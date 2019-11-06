<%@ Page Title="Embed PDF" Language="C#" MasterPageFile="~/MasterPage/PDFToolsMasterPage.Master" AutoEventWireup="true" CodeBehind="EmbedPDF.aspx.cs" Inherits="PDFTools.PDFManager.EmbedPDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 78%;
        }
        .auto-style2 {
            width: 69px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            width: 69px;
            height: 23px;
        }
        .auto-style5 {
            width: 615px;
        }
        .auto-style6 {
            height: 23px;
            width: 615px;
        }
        .auto-style7 {
            width: 388px;
        }
        .auto-style8 {
            width: 388px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HTMLRender_ContentPlaceHolder" runat="server">
    <table align="center" class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7" align="right">
                <asp:Label ID="Label2" runat="server" Text="Parent PDF file"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:FileUpload ID="fileUploadParent" runat="server" />
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style8"></td>
            <td class="auto-style6">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fileUploadParent" ErrorMessage="Please select a Parent PDF"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7" align="right">
                <asp:Label ID="Label3" runat="server" Text="PDF file to Embed"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:FileUpload ID="fileUpload2bEmbedded" runat="server" />
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fileUpload2bEmbedded" ErrorMessage="Please select a Child PDF"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="btnEmbed" runat="server" OnClick="btnEmbed_Click" Text="Embed" />
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5" >
                <asp:Label ID="Label4" runat="server" Text="To view embedded file, open PDF and click on View Attachments"></asp:Label>
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="lblUploadResult" runat="server"></asp:Label>
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
