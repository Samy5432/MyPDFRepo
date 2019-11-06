<%@ Page Title="Help on PDF Tools" Language="C#" MasterPageFile="~/MasterPage/PDFToolsMasterPage.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="PDFTools.Additional.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HTMLRender_ContentPlaceHolder" runat="server">
    <div id="content">
        <p> Merging of PDF documents are often required for our day to day life like to upload IT declaration document 
        or WBP document or Visa Processing documents or Customer documents e.t.c</p> 
       <p>As an Employee or any user has to either go to <a> www.adobe.com </a> or use any freeware to merge PDF documents. 
            But for Customer sensitive documents <a> www.adobe.com </a> cannot be used. And, to install freeware is a big headache. 
           So for that reason we as our team have developed a PDF merge tool where you can Merge the PDF documents very easily and efficiently.</p>

        <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Features of PDF Tools:</h3>
        <h4>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    1. Merge
                </h4>
        <h4>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2. Set Password
                </h4>
        <h4>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 3. Embed PDF               </h4>
        <h4>    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 4. Convert Image to PDF File
        </h4>
         <p>
                <div style="margin-left: 80px">
                    
                        <h3> Merging of PDF Files  </h3>
                    <p>
                        The PDF merge Tool helps user to merge 2 or more pdf files and merge to single doucment and save it as PDF. So you can use flawlessly to other applications.
                    </p>

                     <h3> Set Password for your PDF files  </h3>
                    <p>
                        Now days protecting our documents is very important. So for that reason we have given option to our user to protect their files adding password to their files. So this faciltiy extends to your existing PDF files also. So You can Set Password to PDF files and access whenever you want.
                    </p>
                    <h3> Embed PDF  </h3>
                    <p>
                        Once the Child PDF is embedded into the Parent PDF then to view the Child PDF, open the Parent PDF and in the left side bar click on "View Attachments". Here you can view the embedded Child PDF.
                    </p>

                     <h3> Convert Image to PDF Files  </h3>
                    <p>
                        When we have our documents are in JPEG images and website ask for the PDF files at that time once again scanning of document take a lot of time. So for that reason and reducing the extra effort we have introduced a special option like <b>Conver the Image to PDF</b>. So using this option user can convert the JPEG image into a PDF file and add use however he/she want.
                    </p>
                </div>
                </p>
        <p>
            <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Limitations :</h3>
            <h5>
             1. The PDF Merge Tool can merge the two PDF file Size of 20 mb.<br />
             2. The PDF Merge Tool can Convert only JPEG Image only for first Version of this website.<br />
             3. The PDF Merge Tool can give access PDF files to set password upto 25 characters only.
                </h5>
        </p>
        
  </div>

</asp:Content>
