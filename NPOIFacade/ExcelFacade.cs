using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NPOI.POIFS;
//using NPOI.HSSF.Model;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using System.Data;
using System.Collections;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
//using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

//POIFS (Poor Obfuscation Implementation File System)
//HSSF (Horrible SpreadSheet Format)

namespace NPOIFacade
{
    public class ExcelFacade : IExcelOperation
    {
        private static SimpleDateFormat fmt = new SimpleDateFormat("dd-MMM");

        private static String[] titles = {
            "ID", "Project Name", "Owner", "Days", "Start", "End"};

        //sample data to fill the sheet.
        private static String[][] data = new string[18][];

        public int Add(int x, int y)
        {
            return x + y;
        }

        public void CreateEmptyExcel()
        {
            //CreateExcelWithDefaultValues();
            //GenerateExcelReport();
            return;
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            ////create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "New Technologies Pvt. Ltd.";
            hssfworkbook.DocumentSummaryInformation = dsi;

            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "Crowd Genie";
            hssfworkbook.SummaryInformation = si;

            //here, we must insert at least one sheet to the workbook. otherwise, Excel will say 'data lost in file'
            //So we insert three sheet just like what Excel does
            hssfworkbook.CreateSheet("Sheet1");
            hssfworkbook.CreateSheet("Sheet2");
            hssfworkbook.CreateSheet("Sheet3");
            hssfworkbook.CreateSheet("Sheet4");

            ((HSSFSheet)hssfworkbook.GetSheetAt(0)).AlternativeFormula = false;
            ((HSSFSheet)hssfworkbook.GetSheetAt(0)).AlternativeExpression = false;

            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.GetSheetAt(0);
            //return sheet1;
            //sheet1.DVRecords = 
            //Write the stream data of workbook to the root directory
            FileStream file = new FileStream(@"D:\MyProjects\ASP.Net\NPOI\ExcelFiles\test2.xls", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
   
        }

        public static void GenerateExcelReport()
        {/*
            IRow headerRow = s1.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("First Name");
            s1.SetColumnWidth(0, 20 * 256);
            headerRow.CreateCell(1).SetCellValue("Last Name");
            s1.SetColumnWidth(1, 20 * 256);
            headerRow.CreateCell(2).SetCellValue("Salary");
            headerRow.CreateCell(3).SetCellValue("Tax Rate");
            headerRow.CreateCell(4).SetCellValue("Tax");
            headerRow.CreateCell(5).SetCellValue("Delivery");

            int row = 1;

            for (; row < 100001;)
            {
                GenerateRow(s1, row++, "Bill", "Zhang", 5000, 9.0);
            }
            /*GenerateRow(s1, row++, "Amy", "Huang", 8000, 11.0 / 100);
            GenerateRow(s1, row++, "Tomos", "Johnson", 6000, 9.0 / 100);
            GenerateRow(s1, row++, "Macro", "Jeep", 12000, 15.0 / 100);
            */
            //s1.ForceFormulaRecalculation = true;
/*
            String file = @"D:\MyProjects\ASP.Net\NPOI\ExcelFiles\Report3.xlsx";
            FileStream fs = File.Create(file);
            wb.Write(fs);
            fs.Close();*/
            //wb.UnlockWindows();
        }

        private static void GenerateRow(ISheet sheet1, int rowid, string firstName, string lastName, double salaryAmount, double taxRate)
        {
            IRow row = sheet1.CreateRow(rowid);
            row.CreateCell(0).SetCellValue(firstName);  //A2
            row.CreateCell(1).SetCellValue(lastName);   //B2
            row.CreateCell(2).SetCellValue(salaryAmount);   //C2
            row.CreateCell(3).SetCellValue(taxRate);        //D2
            row.CreateCell(4).SetCellFormula(string.Format("C{0}*D{0}", rowid + 1));
            row.CreateCell(5).SetCellFormula(string.Format("C{0}-E{0}", rowid + 1));
        }

        private static void CopyDataTableToExcelSheet(DataTable table_in, ISheet sheet_in)
        {
            int tableColumnCount = table_in.Columns.Count;
            int tableRowCount = table_in.Rows.Count;

            for (int tableRowid = 0; tableRowid < tableRowCount; tableRowid++ )
            {
                IRow excelRow = sheet_in.CreateRow(tableRowid);
                DataRow tableRow = table_in.Rows[tableRowid];

                for (int i = 0; i < tableColumnCount; i++)
                {
                    ICell aCell = excelRow.CreateCell(i);

                    Type aTableColumnType = tableRow[i].GetType();

                    switch (aTableColumnType.ToString())
                    {
                        case "System.Int32":
                            aCell.SetCellType(CellType.Numeric);
                            aCell.SetCellValue((int)tableRow[i]);
                            break;
                        case "System.String":
                            aCell.SetCellType(CellType.String);
                            aCell.SetCellValue(tableRow[i].ToString());
                            break;
                        case "System.Double":
                            aCell.SetCellType(CellType.Numeric);
                            aCell.SetCellValue((double)tableRow[i]);
                            break;
                        default:
                            aCell.SetCellType(CellType.String);
                            aCell.SetCellValue(tableRow[i].ToString());
                            break;
                    }
                }
            }
        }

        public bool PopulateExcel(DataTable dataTable, String outputFileNameWithPath)
        {
            XSSFWorkbook wb = new XSSFWorkbook();
            ISheet s1 = wb.CreateSheet("Monthly Salary Report");
            CopyDataTableToExcelSheet(dataTable, s1);
            s1.ForceFormulaRecalculation = true;

            //String file = @"D:\MyProjects\ASP.Net\NPOI\ExcelFiles\Report10.xlsx";
            FileStream fs = File.Create(outputFileNameWithPath);
            wb.Write(fs);
            fs.Close();
            return true;
        }

        private IList ConvertTableColumnToList(DataRowCollection drCollection)
        {
            IList aList = new List<string>(drCollection.Count);
            foreach(DataRow row in drCollection)
            {
                aList.Add(row[0].ToString());
            }
            return aList;
        }

        static void CreateExcelWithDefaultValues()
        {
            data[0] = new string[] {"1.0", "Marketing Research Tactical Plan", "J. Dow", "70", "9-Jul", null,
                "x", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x"};
            data[1] = new string[] { null };
            data[2] = new string[] {"1.1", "Scope Definition Phase", "J. Dow", "10", "9-Jul", null,
                "x", "x", null, null,  null, null, null, null, null, null, null};
            data[3] = new string[] {"1.1.1", "Define research objectives", "J. Dow", "3", "9-Jul", null,
                    "x", null, null, null,  null, null, null, null, null, null, null};
            data[4] = new string[] {"1.1.2", "Define research requirements", "S. Jones", "7", "10-Jul", null,
                "x", "x", null, null,  null, null, null, null, null, null, null};
            data[5] = new string[] {"1.1.3", "Determine in-house resource or hire vendor", "J. Dow", "2", "15-Jul", null,
                "x", "x", null, null,  null, null, null, null, null, null, null};
            data[6] = new string[] { null };
            data[7] = new string[] {"1.2", "Vendor Selection Phase", "J. Dow", "19", "19-Jul", null,
                null, "x", "x", "x",  "x", null, null, null, null, null, null};
            data[8] = new string[] {"1.2.1", "Define vendor selection criteria", "J. Dow", "3", "19-Jul", null,
                null, "x", null, null,  null, null, null, null, null, null, null};
            data[9] = new string[] {"1.2.2", "Develop vendor selection questionnaire", "S. Jones, T. Wates", "2", "22-Jul", null,
                null, "x", "x", null,  null, null, null, null, null, null, null};
            data[10] = new string[] {"1.2.3", "Develop Statement of Work", "S. Jones", "4", "26-Jul", null,
                null, null, "x", "x",  null, null, null, null, null, null, null};
            data[11] = new string[] {"1.2.4", "Evaluate proposal", "J. Dow, S. Jones", "4", "2-Aug", null,
                null, null, null, "x",  "x", null, null, null, null, null, null};
            data[12] = new string[] {"1.2.5", "Select vendor", "J. Dow", "1", "6-Aug", null,
                null, null, null, null,  "x", null, null, null, null, null, null};
            data[13] = new string[] { null };
            data[14] = new string[] {"1.3", "Research Phase", "G. Lee", "47", "9-Aug", null,
                null, null, null, null,  "x", "x", "x", "x", "x", "x", "x"};
            data[15] = new string[] {"1.3.1", "Develop market research information needs questionnaire", "G. Lee", "2", "9-Aug", null,
                null, null, null, null,  "x", null, null, null, null, null, null};
            data[16] = new string[] {"1.3.2", "Interview marketing group for market research needs", "G. Lee", "2", "11-Aug", null,
                null, null, null, null,  "x", "x", null, null, null, null, null};
            data[17] = new string[] {"1.3.3", "Document information needs", "G. Lee, S. Jones", "1", "13-Aug", null,
                null, null, null, null,  null, "x", null, null, null, null, null};

            XSSFWorkbook wb = new XSSFWorkbook();

            IDictionary<String, ICellStyle> styles = createStyles(wb);

            ISheet sheet = wb.CreateSheet("Business Plan");

            //turn off gridlines
            sheet.DisplayGridlines = true;
            sheet.IsPrintGridlines = false;
            sheet.FitToPage = true;
            sheet.HorizontallyCenter = true;
            IPrintSetup printSetup = sheet.PrintSetup;
            printSetup.Landscape = true;

            //the following three statements are required only for HSSF
            sheet.Autobreaks = true;
            printSetup.FitHeight = ((short)1);
            printSetup.FitWidth = ((short)1);

            //the header row: centered text in 48pt font
            IRow headerRow = sheet.CreateRow(0);
            headerRow.HeightInPoints = (12.75f);
            for (int i = 0; i < titles.Length; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(titles[i]);
                cell.CellStyle = (styles["header"]);
            }
            //columns for 11 weeks starting from 9-Jul
            DateTime dt = new DateTime(DateTime.Now.Year, 6, 9);
            for (int i = 0; i < 11; i++)
            {
                ICell cell = headerRow.CreateCell(titles.Length + i);
                cell.SetCellValue(dt);
                cell.CellStyle = (styles[("header_date")]);
                //calendar.roll(Calendar.WEEK_OF_YEAR, true);
                dt.AddDays(7);
            }
            //freeze the first row
            sheet.CreateFreezePane(0, 1);
            //sheet.
            IRow row;
            //ICell cell;
            int rownum = 1;
            for (int i = 0; i < data.Length; i++, rownum++)
            {
                row = sheet.CreateRow(rownum);
                if (data[i] == null) continue;

                for (int j = 0; j < data[i].Length; j++)
                {
                    ICell cell = row.CreateCell(j);
                    String styleName;
                    bool isHeader = i == 0 || data[i - 1] == null;
                    switch (j)
                    {
                        case 0:
                            if (isHeader)
                            {
                                styleName = "cell_b";
                                cell.SetCellValue(Double.Parse(data[i][j]));
                            }
                            else
                            {
                                styleName = "cell_normal";
                                cell.SetCellValue(data[i][j]);
                            }
                            break;
                        case 1:
                            if (isHeader)
                            {
                                styleName = i == 0 ? "cell_h" : "cell_bb";
                            }
                            else
                            {
                                styleName = "cell_indented";
                            }
                            cell.SetCellValue(data[i][j]);
                            break;
                        case 2:
                            styleName = isHeader ? "cell_b" : "cell_normal";
                            cell.SetCellValue(data[i][j]);
                            break;
                        case 3:
                            styleName = isHeader ? "cell_b_centered" : "cell_normal_centered";
                            cell.SetCellValue(int.Parse(data[i][j]));
                            break;
                        case 4:
                            {
                                //calendar.setTime(fmt.parse(data[i][j]));
                                //calendar.set(Calendar.YEAR, year);

                                DateTime dt2 = DateTime.Parse(DateTime.Now.Year.ToString() + "-" + data[i][j]);

                                cell.SetCellValue(dt2);
                                styleName = isHeader ? "cell_b_date" : "cell_normal_date";
                                break;
                            }
                        case 5:
                            {
                                int r = rownum + 1;
                                String fmla = "IF(AND(D" + r + ",E" + r + "),E" + r + "+D" + r + ",\"\")";
                                cell.SetCellFormula(fmla);
                                styleName = isHeader ? "cell_bg" : "cell_g";
                                break;
                            }
                        default:
                            styleName = data[i][j] != null ? "cell_blue" : "cell_normal";
                            break;
                    }

                    cell.CellStyle = (styles[(styleName)]);
                }
            }

            //group rows for each phase, row numbers are 0-based
            sheet.GroupRow(4, 6);
            sheet.GroupRow(9, 13);
            sheet.GroupRow(16, 18);

            //set column widths, the width is measured in units of 1/256th of a character width
            sheet.SetColumnWidth(0, 256 * 6);
            sheet.SetColumnWidth(1, 256 * 33);
            sheet.SetColumnWidth(2, 256 * 20);
            sheet.SetZoom(3, 4);


            // Write the output to a file
            String file = @"D:\MyProjects\ASP.Net\NPOI\ExcelFiles\businessplan17.xlsx";
            //if (wb is XSSFWorkbook) file += "x";
            using (FileStream out1 = new FileStream(file, FileMode.Create))
            {
                wb.Write(out1);
                out1.Close();
            }

        }

        /**
     * create a library of cell styles
     */
        private static IDictionary<String, ICellStyle> createStyles(XSSFWorkbook wb)
        {
            IDictionary<String, ICellStyle> styles = new Dictionary<String, ICellStyle>();
            IDataFormat df = wb.CreateDataFormat();

            ICellStyle style;
            IFont headerFont = wb.CreateFont();
            headerFont.Boldweight = (short)(FontBoldWeight.Bold);
            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.FillForegroundColor = (IndexedColors.LightCornflowerBlue.Index);
            style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(headerFont);
            styles.Add("header", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.FillForegroundColor = (IndexedColors.LightCornflowerBlue.Index);
            style.FillPattern = FillPattern.SolidForeground;
            style.SetFont(headerFont);
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("header_date", style);

            IFont font1 = wb.CreateFont();
            font1.Boldweight = (short)(FontBoldWeight.Bold);
            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            styles.Add("cell_b", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            styles.Add("cell_b_centered", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("cell_b_date", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            style.FillForegroundColor = (IndexedColors.Grey25Percent.Index);
            style.FillPattern = FillPattern.SolidForeground;
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("cell_g", style);

            IFont font2 = wb.CreateFont();
            font2.Color = (IndexedColors.Blue.Index);
            font2.Boldweight = (short)(FontBoldWeight.Bold);
            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font2);
            styles.Add("cell_bb", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font1);
            style.FillForegroundColor = (IndexedColors.Grey25Percent.Index);
            style.FillPattern = FillPattern.SolidForeground;
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("cell_bg", style);

            IFont font3 = wb.CreateFont();
            font3.FontHeightInPoints = ((short)14);
            font3.Color = (IndexedColors.DarkBlue.Index);
            font3.Boldweight = (short)(FontBoldWeight.Bold);
            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font3);
            style.WrapText = (true);
            styles.Add("cell_h", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = (true);
            styles.Add("cell_normal", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = (true);
            styles.Add("cell_normal_centered", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = (true);
            style.DataFormat = (df.GetFormat("d-mmm"));
            styles.Add("cell_normal_date", style);

            style = CreateBorderedStyle(wb);
            style.Alignment = HorizontalAlignment.Center;
            style.Indention = ((short)1);
            style.WrapText = (true);
            styles.Add("cell_indented", style);

            style = CreateBorderedStyle(wb);
            style.FillForegroundColor = (IndexedColors.Blue.Index);
            style.FillPattern = FillPattern.SolidForeground;
            styles.Add("cell_blue", style);

            return styles;
        }

        private static ICellStyle CreateBorderedStyle(XSSFWorkbook wb)
        {
            ICellStyle style = wb.CreateCellStyle();
            style.BorderRight = BorderStyle.Thin;
            style.RightBorderColor = (IndexedColors.Black.Index);
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = (IndexedColors.Black.Index);
            style.BorderLeft = BorderStyle.Thin;
            style.LeftBorderColor = (IndexedColors.Black.Index);
            style.BorderTop = BorderStyle.Thin;
            style.TopBorderColor = (IndexedColors.Black.Index);
            return style;
        }


    }
}
