<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage/PDFToolsMasterPage.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PDFToolsApp._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="HTMLRender_ContentPlaceHolder" runat="server">
    <table align="center">
                <tr >
            <td>&nbsp;</td>
            <td>   
        <h1>PDF Tools</h1>
        <p>The Portal facilitates following operatios on PDF files...
                            </td>
            <td>&nbsp;</td>
            </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
        
          <a href="PDFManager/PDFMerge.aspx">Merge 2 PDF files &raquo;</a>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><a href="PDFManager/PasswordProtectPDF.aspx">Set Password to open PDF &raquo;</a></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><a href="PDFManager/EmbedPDF.aspx">Embed one PDF into another PDF &raquo;</a></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><a href="PDFManager/Img2PDF.aspx">Convert any Image to PDF &raquo;</a></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>                    
       </table>
</asp:Content>
