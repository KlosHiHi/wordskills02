using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClassLibrary.Models;
using ClassLibrary.Options;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CsvHelper;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Pdfua.Checkers.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MsBox.Avalonia;
using OfficeOpenXml;

namespace AvaloniaApplication.ViewModels;

public partial class EventViewModel : ViewModelBase
{
    [ObservableProperty]
    private List<Formulation> _formulations;

    [ObservableProperty]
    private string _title = "события";

    [RelayCommand]
    private async Task GetData()
    {
        try
        {
            var responce = 
                await HttpOption.httpClient.GetFromJsonAsync<IEnumerable<Formulation>>($"{HttpOption.baseUrl}formulation");
            Formulations = (List<Formulation>)responce;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        
    }

    [RelayCommand]
    private async Task ExportData()
    {
        try
        {
            using (FileStream fs = new("C:\\sss\\data.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<Formulation>>(fs, Formulations);
                await MessageBoxManager.GetMessageBoxStandard("Успех", "Файл успешно экспортирован в .json").ShowAsync();
            }

            using (StreamWriter sw = new("C:\\sss\\data.csv")){
            await sw.WriteLineAsync("id;product_id;name;status;is_current");
            foreach(var item in Formulations)
            {
                await sw.WriteLineAsync($"{item.Id};{item.Name};{item.Product.Name};{item.Status};{item}") ;
            }
                await MessageBoxManager.GetMessageBoxStandard("Успех", "Файл успешно экспортирован в .csv").ShowAsync();
            }

            using (PdfWriter writer = new PdfWriter("C:\\sss\\data.pdf"))
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new(pdf, PageSize.A4.Rotate());

                PropertyInfo[] properties = typeof(Formulation).GetProperties();

                // Создаем таблицу
                iText.Layout.Element.Table table = new(UnitValue.CreatePercentArray(properties.Length));
                table.SetWidth(UnitValue.CreatePercentValue(100));

                // Добавляем заголовки (имена свойств)
                foreach (var prop in properties)
                {
                    table.AddHeaderCell(new Cell()
                        .Add(new Paragraph(prop.Name))
                        .SetBackgroundColor(new DeviceRgb(52, 73, 94))
                        .SetFontColor(ColorConstants.WHITE));
                }

                // Заполняем данными
                foreach (var item in Formulations)
                {
                    foreach (var prop in properties)
                    {
                        object value = prop.GetValue(item);
                        table.AddCell(new Cell().Add(new Paragraph(value?.ToString() ?? "")));
                    }
                }

                document.Add(table);
                document.Close();
                await MessageBoxManager.GetMessageBoxStandard("Успех", "Файл успешно экспортирован в .pdf").ShowAsync();
            }
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new())
            {
                var worksheet = package.Workbook.Worksheets.Add("user_data");
            
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Название";
                worksheet.Cells[1, 3].Value = "Продукт";
                worksheet.Cells[1, 4].Value = "Статус";
                worksheet.Cells[1, 5].Value = "Текущий";
            
                int row = 2;
                foreach (var item in Formulations)
                {
                    worksheet.Cells[row, 1].Value = item.Id;
                    worksheet.Cells[row, 2].Value = item.Name;
                    worksheet.Cells[row, 3].Value = item.Product.Name;
                    worksheet.Cells[row, 4].Value = item.Status;
                    worksheet.Cells[row, 5].Value = item.IsCurrent;
                    row++;
                }
            
                worksheet.Cells.AutoFitColumns();
            
                FileInfo fileInfo = new("C://sss//data.xlsx");
                await package.SaveAsAsync(fileInfo);
                await MessageBoxManager.GetMessageBoxStandard("Сохранение", "Файл успешно сохранён .xlsx").ShowAsync();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
