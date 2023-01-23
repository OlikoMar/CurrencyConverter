using System.Reflection;
using OfficeOpenXml;

namespace CurrencyConverter.SharedKernel.Excel;

public class ExcelExporter : IDisposable
{
    public ExcelExporter()
    {
        ExcelPackage = new ExcelPackage();
        _excelWorksheet = ExcelPackage.Workbook.Worksheets.Add("sheet");
    }

    public readonly ExcelPackage ExcelPackage;
    private readonly ExcelWorksheet _excelWorksheet;
    private int _row = 1;
    private readonly Dictionary<PropertyInfo, ExcelCellAttribute> _propertyAttributes = new();
    private PropertyInfo[] _propertyInfos;

    public void Parse<T>(List<T> users)
    {
        _propertyInfos = typeof(T).GetProperties();

        SetHeaders();

        SetData(users);
        _excelWorksheet.Cells.AutoFitColumns();
    }

    private void SetData<T>(List<T> data)
    {
        foreach (var user in data)
        {
            _row++;
            foreach (var propertyInfo in _propertyInfos)
            {
                var attribute = _propertyAttributes[propertyInfo];
                _excelWorksheet.Cells[_row, attribute.Column].Value = propertyInfo.GetValue(user);
            }
        }
    }

    private void SetHeaders()
    {
        foreach (var propertyInfo in _propertyInfos)
        {
            var attribute = propertyInfo.GetCustomAttributes<ExcelCellAttribute>().First();
            _excelWorksheet.Cells[_row, attribute.Column].Value = attribute.Name;
            _propertyAttributes.Add(propertyInfo, attribute);
        }
    }

    public Stream Export()
    {
        var memoryStream = new MemoryStream();
        ExcelPackage.Stream.CopyTo(memoryStream);
        return memoryStream;
    }

    public void Dispose()
    {
        ExcelPackage.Dispose();
        _excelWorksheet.Dispose();
    }
}