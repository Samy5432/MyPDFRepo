<%@ Page Async="true" Title="Merge PDF" Language="C#" MasterPageFile="~/MasterPage/PDFToolsMasterPage.Master" AutoEventWireup="true" CodeBehind="PDFMerge.aspx.cs" Inherits="PDFTools.PDFManager.PDFMerge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style5
        {
            width: 52%;
        }
    </style>
    <script type="text/javascript">
    </script>
    <script type="text/javascript" language="javascript">
        function Disable(btn)
        {

            btn.disabled = true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HTMLRender_ContentPlaceHolder" runat="server">
    <table class="style5" align="center">
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="Label11" runat="server" Text="PDF File 1"></asp:Label>
                <asp:FileUpload ID="fileUpload1" runat="server" TabIndex="1" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td align="center">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="#FFCC99" ControlToValidate="fileUpload1" ErrorMessage="Please select PDF file"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="Label12" runat="server" Text="PDF File 2"></asp:Label>
                <asp:FileUpload ID="fileUpload2" runat="server" TabIndex="2" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="center">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" BackColor="#FFCC99" ControlToValidate="fileUpload2" ErrorMessage="Please select PDF file"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="center">
                <asp:Button ID="btnMerge" runat="server" onclick="btnMerge_Click"
                    Text="Merge" TabIndex="3" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="center" rowspan="3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="lblUploadResult" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
