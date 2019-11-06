using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOIFacade;
using System.Data;
using PDFTools.MasterPage;
using System.IO;

namespace PDFTools.ExcelManager
{
    public partial class TableCreation : System.Web.UI.Page
    {
        protected void btnShowGrid_Click(object sender, EventArgs e)
        {
            DataTable aTable = new DataTable();
            aTable.Columns.Add("Emp Id");
            aTable.Columns.Add("Name");
            aTable.Columns.Add("Email Id");
            aTable.Rows.Add("1", "Mickey Mouse", "mickey@def.com");
            aTable.Rows.Add("2", "Donald Duck", "donald@def.com");
            aTable.Rows.Add("3", "Pluto", "pluto@def.com");

            //grdView.DataSource = aTable;
            //grdView.DataBind();
        }

        private static DataTable CreateDataTable(int numberOfRows)
        {
            DataTable aTable = new DataTable();

            aTable.Columns.Add("Emp Id", typeof(int));
            aTable.Columns.Add("Name", typeof(string));
            aTable.Columns.Add("Amount", typeof(int));
            aTable.Columns.Add("Rate", typeof(double));

            for (int rowid = 1; rowid <= numberOfRows; rowid++)
            {
                DataRow arow = aTable.NewRow();
                // arow.SetField<int>(0, rowid);
                // arow.SetField<string>(1, "Emp1");
                // arow.SetField<int>(2, 100);
                aTable.Rows.Add(rowid, "EmpName", 100, 10.5);
            }
            return aTable;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            int rowNumber = 0;
            try
            {
                rowNumber = int.Parse(txtRows.Text);
            }
            catch (Exception)
            {
                return;
            }
            DataTable aTable = CreateDataTable(rowNumber);

            IExcelOperation aExcelFacade = new ExcelFacade();

            string folderPath = PDFToolsMasterPage.GetFolderPathAtServer();

            string fileName = "Report.xlsx";

            string outputFileNameWithPath = Path.Combine(folderPath, fileName);

            PDFToolsMasterPage.DeleteFile(fileName, null);

            bool aSuccess = aExcelFacade.PopulateExcel(aTable, outputFileNameWithPath);

            if (aSuccess)
            {
                var aMaster = (PDFToolsMasterPage)Master;
                aMaster.TransmitFile(fileName, outputFileNameWithPath, "application/excel");              
            }
        }
    }
}