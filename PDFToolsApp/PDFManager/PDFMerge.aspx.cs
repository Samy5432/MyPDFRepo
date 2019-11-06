using System;
using System.IO;
using pdfforge.PDF;
using PDFTools.MasterPage;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace PDFTools.PDFManager
{
    public partial class PDFMerge : System.Web.UI.Page
    {

        protected async void btnMerge_Click(object sender, EventArgs e)
        {
            lblUploadResult.Text = string.Empty;

            string folderPath = PDFToolsMasterPage.GetFolderPathAtServer();

            var aMaster = (PDFToolsMasterPage)this.Master;

            if (!PDFToolsMasterPage.CheckDirectoryPath(folderPath))
            {
                aMaster.DisplayMessageBox("Failed to create directory : " + folderPath);
                return;
            }
            PDFToolsMasterPage.UploadFile(fileUpload1, lblUploadResult, false);

            PDFToolsMasterPage.UploadFile(fileUpload2, lblUploadResult, false);

            string mergedFileNameWithPath = Path.Combine(folderPath, "Merge.pdf");

            PDFToolsMasterPage.DeleteFile("Merge.pdf", lblUploadResult);

            //InvokeMergeWebAPI(Path.Combine(folderPath, fileUpload1.FileName), Path.Combine(folderPath, fileUpload2.FileName), mergedFileNameWithPath);
            bool mergeResult = await MergePDF(Path.Combine(folderPath, fileUpload1.FileName), Path.Combine(folderPath, fileUpload2.FileName), mergedFileNameWithPath, lblUploadResult);

            btnMerge.Enabled = true;

            if (mergeResult)
            {
                lblUploadResult.Text = "Merge is successful";

                aMaster.TransmitFile("Merge.pdf", mergedFileNameWithPath);
            }
            else
            {
                lblUploadResult.Text = "Merge failed";
            }
        }
/*
        private async void InvokeMergeWebAPI(string p1, string p2, string mergedFileNameWithPath)
        {
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri("http://localhost:9001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                //HttpContent aContent = new HttpContent();
                // New code:
                //client.PostAsync("");
                HttpResponseMessage response = await client.GetAsync("api/PDFLib/1.pdf/2.pdf");

                if (response.IsSuccessStatusCode)
                {
                }
            }
        }
        */
        private async Task<bool> MergePDF(string pdf1, string pdf2, string mergedFileNameWithPath, Label lblResult )
        {
            string[] pdfFiles = new string[2];
            pdfFiles[0] = pdf1;
            pdfFiles[1] = pdf2;

            PDF pdf = new PDF();
            try
            {
                pdf.MergePDFFiles(ref pdfFiles, mergedFileNameWithPath, false);
                pdfFiles = null;
                return true;
            }
            catch (Exception ex)
            {
                lblResult.Text = "Merge failed : " + ex.Message;
                PDFToolsMasterPage.DeleteFile("Merge.pdf", lblResult);
                pdfFiles = null;
                return false;
            }
        }
    }
}