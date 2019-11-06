<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PDFToolsMasterPage.Master" AutoEventWireup="true" CodeBehind="TableCreation.aspx.cs" Inherits="PDFTools.ExcelManager.TableCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table.Pos1 {
            width:59%;
            margin-left:25%; 
            margin-right:auto;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HTMLRender_ContentPlaceHolder" runat="server">
    <table class="Pos1" >
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Create DataTable with Default Values"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="No. of Columns"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="4"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 22px"></td>
            <td style="height: 22px">
                <asp:Label ID="Label4" runat="server" Text="No. of Rows"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="txtRows" runat="server">1000</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRows" ErrorMessage="Row Number is required" SetFocusOnError="True" TabIndex="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Write to Excel and Download" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>        
