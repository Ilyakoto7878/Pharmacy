using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Report
{
    public class ReportManager
    {
        public byte[] GenerateReport<TEntity>(IEnumerable<TEntity> info)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Отчёт");
            sheet.Cells["A1"].LoadFromCollection(info, true);
            return package.GetAsByteArray();
        }
    }
}
