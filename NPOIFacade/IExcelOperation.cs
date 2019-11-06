using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOIFacade
{
    public interface IExcelOperation
    {
        int Add(int x, int y);

        void CreateEmptyExcel();

        bool PopulateExcel(DataTable dataTable, String outputFileNameWithPath);
    }
}
