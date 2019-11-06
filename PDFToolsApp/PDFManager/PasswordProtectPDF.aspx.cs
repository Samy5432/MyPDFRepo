using System;
using System.IO;
using pdfforge.PDF;
using PDFTools.MasterPage;

namespace PDFTools.PDFManager
{
    public partial class PasswordProtectPDF : System.Web.UI.Page
    {
        protected void btnSetPwd_Click(object sender, EventArgs e)
        {
            lblUploadResult.Text = string.Empty;

            if (!CheckControls())
            {
                return;
            }
           
            String folderPath = PDFToolsMasterPage.GetFolderPathAtServer();

            String fileNameWithPath = Path.Combine(folderPath, fileUpload.FileName);

            //PDFToolsMasterPage.DeleteFile(fileUpload.FileName);

            PDFToolsMasterPage.UploadFile(fileUpload, lblUploadResult, false);

            PDFToolsMasterPage.DeleteFile("PwdProtected.pdf", lblUploadResult);

            String newFileNameWithPath = Path.Combine(folderPath, "PwdProtected.pdf");

            bool result = SetPassword2PDF(fileNameWithPath, newFileNameWithPath, txtPwd.Text);

            if (result)
            {
                var aMaster = (PDFToolsMasterPage)Master;
                aMaster.TransmitFile("PwdProtected.pdf", newFileNameWithPath);
            }
        }

        private bool SetPassword2PDF(String fileNameWithPath, String newFileNameWithPath, String pwd)
        {
            PDF pdf = new PDF();
            PDFEncryptor enc = new PDFEncryptor();
            enc.UserPassword = pwd;

            try
            {
                pdf.EncryptPDFFile(fileNameWithPath, newFileNameWithPath, ref enc);
                return true;
            }
            catch (Exception e)
            {
                var aMaster = (PDFToolsMasterPage)this.Master;
                aMaster.DisplayMessageBox(e.Message);
                return false;
            }
        }

        private bool CheckControls()
        {
            PDFToolsMasterPage aMaster = (PDFToolsMasterPage)Master;

            if (String.IsNullOrWhiteSpace(txtPwd.Text))
            {
                aMaster.DisplayMessageBox("Please provide a valid Password");
                return false;
            }
            if (!fileUpload.HasFile)
            {
                aMaster.DisplayMessageBox("Please upload a valid PDF file");
                return false;
            }
            return true;
        }
    }
}