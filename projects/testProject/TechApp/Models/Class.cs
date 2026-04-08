
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ClassLibrary.Models;
using CsvHelper;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using OfficeOpenXml;

namespace TechApp.Models;

public class ExportService
{
    public void ExportToCsv<T>(IEnumerable<T> records, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer))
        {
            csv.WriteRecords(records);
        }
    }
    public static async Task ExportToExcel(IEnumerable<User> data, string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("user_data");

            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Login";

            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cells[row, 1].Value = item.UserId;
                worksheet.Cells[row, 2].Value = item.Login;
                row++;
            }

            worksheet.Cells.AutoFitColumns();

            FileInfo fileInfo = new FileInfo(filePath);
            await package.SaveAsAsync(fileInfo);
            var box = MessageBoxManager.GetMessageBoxStandard("Сохранение", "Файл успешно сохранён", ButtonEnum.Ok);
            await box.ShowAsync();
        }
    }
}