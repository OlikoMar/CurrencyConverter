namespace CurrencyConverter.SharedKernel.Excel;

public static class Extensions
{
    public static byte[] ToExcel<T>(this List<T> users)
    {
        using var excelExporter = new ExcelExporter();
        excelExporter.Parse(users);
        using var stream = excelExporter.Export();
        using var file = File.OpenWrite("excel.xlsx");
        stream.CopyTo(file);
        return excelExporter.ExcelPackage.GetAsByteArray();
    }
}