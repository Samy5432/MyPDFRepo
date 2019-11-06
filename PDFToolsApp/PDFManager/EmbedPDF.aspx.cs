using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDFTools.MasterPage;
using System.IO;
using pdfforge.PDF;

namespace PDFTools.PDFManager
{
    public partial class EmbedPDF : System.Web.UI.Page
    {
        protected void btnEmbed_Click(object sender, EventArgs e)
        {
            lblUploadResult.Text = string.Empty;

            string folderPath = PDFToolsMasterPage.GetFolderPathAtServer();

            var aMaster = (PDFToolsMasterPage)this.Master;

            if (!PDFToolsMasterPage.CheckDirectoryPath(folderPath))
            {
                aMaster.DisplayMessageBox("Failed to create directory : " + folderPath);
                return;
            }
            PDFToolsMasterPage.UploadFile(fileUploadParent, lblUploadResult, false);

            PDFToolsMasterPage.UploadFile(fileUpload2bEmbedded, lblUploadResult, true);

            string outputFileNameWithPath = Path.Combine(folderPath, "EmbedOutput.pdf");

            PDFToolsMasterPage.DeleteFile("EmbedOutput.pdf", lblUploadResult);

            string[] pdfFiles2bEmbedded = new string[1];

            pdfFiles2bEmbedded[0] = Path.Combine(folderPath, fileUpload2bEmbedded.FileName);

            bool embedResult = EmbedChildPDFInParent(Path.Combine(folderPath, fileUploadParent.FileName), outputFileNameWithPath, pdfFiles2bEmbedded, false, lblUploadResult);

            if (embedResult)
            {
                lblUploadResult.Text = "Embed is successful";

                aMaster.TransmitFile("EmbedOutput.pdf", outputFileNameWithPath);
            }
            else
            {
                lblUploadResult.Text = "Embed failed";
            }
        }

        private bool EmbedChildPDFInParent(string parentPdfFile, string outputFileNameWithPath, string[] pdfFiles2bEmbedded, bool compress, Label lblResult)
        {
            PDF pdf = new PDF();

            try
            {
                pdf.EmbedFilesInPDFFile(parentPdfFile, outputFileNameWithPath, ref pdfFiles2bEmbedded, false);

                return true;
            }
            catch (Exception ex)
            {
                lblResult.Text = "Merge failed : " + ex.Message;
                return false;
            }
        }

    }
}