using pdfforge.PDF;
using System;
using System.IO;
using PDFTools.MasterPage;

namespace PDFTools.PDFManager
{
    public partial class Img2PDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUploadResult.Text = string.Empty;
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            if (!fileUpload.HasFile)
            {
                lblUploadResult.Text = "No file found";
                return;
            }

          //  PDFToolsMasterPage.DeleteFile(fileUpload.FileName, lblUploadResult);

            PDFToolsMasterPage.UploadFile(fileUpload, lblUploadResult, true);

            String folderPath = PDFToolsMasterPage.GetFolderPathAtServer();

            String fileNameWithPath = Path.Combine(folderPath, fileUpload.FileName);
            
            String destFileName = Path.ChangeExtension(fileUpload.FileName, ".pdf");

            String destFileNameWithPath = Path.Combine(folderPath, destFileName);

            bool result = ConvertImg2PDF(fileNameWithPath, destFileNameWithPath);

            if (result)
            {
                var aMaster = (PDFToolsMasterPage)Master;
                aMaster.TransmitFile(destFileName, destFileNameWithPath);
            }
        }

        private bool ConvertImg2PDF(String fileNameWithPath, String destFileNameWithPath)
        {
            string[] pdfFiles = new string[1];
            pdfFiles[0] = fileNameWithPath;

            PDF pdf = new PDF();
            try
            {
                int x = pdf.Images2PDF(ref pdfFiles, destFileNameWithPath, 1);

                lblUploadResult.Text = "Conversion is successful";

                return true;
            }
            catch (Exception ex)
            {
                lblUploadResult.Text = "Conversion failed : " + ex.Message;
                
                return false;
            }

        }
    }
}