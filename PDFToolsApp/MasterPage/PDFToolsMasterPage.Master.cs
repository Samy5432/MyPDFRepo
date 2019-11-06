namespace PDFTools.MasterPage
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Web.UI;
    using System.Globalization;
    using System.Web.UI.WebControls;

    public partial class PDFToolsMasterPage : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblPageTitle.Text = this.Page.Title;

            SetDateFormat();
        }

        public void DisplayMessageBox(string message)
        {
            var sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function DisplayMessagebox(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        /// <summary>
        ///     Transmit filet to Client Side
        /// </summary>
        /// <param name="fileName_in"></param>
        /// <param name="fileNameWithPath"></param>
        public void TransmitFile(String fileName_in, String fileNameWithPath, string contentType="application/pdf")
        {
            if (File.Exists(fileNameWithPath))
            {
                try
                {
                    this.Response.Clear();
                    this.Response.Charset = "UTF-8";
                    this.Response.ContentType = contentType;
                    this.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName_in);
                    //Response.AddHeader("Content-Length", file.Length.ToString());
                    this.Response.TransmitFile(fileNameWithPath);
                    this.Response.Flush();
                    this.Response.End();
                }
                catch (System.Web.HttpException he)
                {
                    DisplayMessageBox("Exception caught : " + he.Message);
                }
                catch (ThreadAbortException tae)
                {
                    DisplayMessageBox("Exception caught : " + tae.Message);
                }
            }
            else
            {
                DisplayMessageBox("File not found");
            }
        }

        public static string GetFolderPathAtServer()
        {
            //return @"h:\root\home\rajsingh-001\www\site1\Temp";
            return @"D:\Myprojects\Temp";
            //return @"D:\PDFTest\Temp";
        }

        public static string UploadFile(FileUpload fileUpload, Label lblUploadResult, bool ignoreFileExtnCheck)
        {
            lblUploadResult.Text = string.Empty;

            String folderPath = GetFolderPathAtServer();
            
            String[] allowedExtensions = new String[] { ".pdf" };

            Boolean fileOK = false;

            if (fileUpload == null)
            {
                lblUploadResult.Text = "File not found";
                return string.Empty;
            }

            if (allowedExtensions == null || !allowedExtensions.Any())
            {
                if (fileUpload.HasFile)
                {
                    fileOK = true;
                    goto StartUploading;
                }
                lblUploadResult.Text = "File not found";
                return null;
            }

            if (ignoreFileExtnCheck)
            {
                fileOK = true;
                goto StartUploading;
            }
            //check file extension is valid or not
            if (fileUpload.HasFile)
            {
                String fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();

                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (String.CompareOrdinal(fileExtension, allowedExtensions[i]) == 0)
                    {
                        fileOK = true;
                        break;
                    }
                }
            }
            else
            {
                lblUploadResult.Text = "File not found";
                return null;
            }
        StartUploading:

            string strFileNameWithPath = null;

            if (fileOK)
            {
                try
                {
                    strFileNameWithPath = Path.Combine(folderPath, fileUpload.FileName);

                    //delete file if already exists
                    DeleteFile(fileUpload.FileName, lblUploadResult);

                    fileUpload.PostedFile.SaveAs(strFileNameWithPath);

                    if (lblUploadResult != null)
                    {
                        lblUploadResult.Text = "File uploaded Successfully!";
                    }
                }
                catch (Exception ex)
                {
                    if (lblUploadResult != null)
                    {
                        lblUploadResult.Text = "File could not be uploaded. " + ex.Message;
                    }
                }
                finally
                {
                    fileUpload.PostedFile.InputStream.Close();
                    fileUpload.PostedFile.InputStream.Dispose();
                }
            }
            else
            {
                if (lblUploadResult != null)
                {
                    lblUploadResult.Text = "Upload failed";
                }
            }
            return strFileNameWithPath;
        }

        public static bool CheckDirectoryPath(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return true;
        }

        public static void DeleteFile(String fileNameInServerTempFolder, Label lblUploadResult)
        {
            String fileNameWithPath = Path.Combine(GetFolderPathAtServer(), fileNameInServerTempFolder);

            if (File.Exists(fileNameWithPath))
            {
                try
                {
                    File.Delete(fileNameWithPath);
                }
                catch (ArgumentException ae)
                {
                    lblUploadResult.Text = "Please re-start Application. Existing file delete issue " + ae.Message;
                }
                catch (IOException ioe)
                {
                    lblUploadResult.Text = "Please re-start Application. Existing file delete issue " + ioe.Message;
                }
                catch (UnauthorizedAccessException uae)
                {
                    lblUploadResult.Text = "Please re-start Application. Existing file delete issue " + uae.Message;
                }
                catch (Exception ae)
                {
                    lblUploadResult.Text = "Please re-start Application. Existing file delete issue " + ae.Message;
                }

            }
        }

        public static void SetDateFormat()
        {
            var standardizedCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            standardizedCulture.DateTimeFormat.DateSeparator = " ";
            standardizedCulture.DateTimeFormat.ShortDatePattern = "dd MMM yyyy";
            Thread.CurrentThread.CurrentCulture = standardizedCulture;
            Thread.CurrentThread.CurrentUICulture = standardizedCulture;
        }
    }
}