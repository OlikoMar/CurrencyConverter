using CurrencyConverter.SharedKernel.Excel;

namespace CurrencyConverter.Application.DataModels;

public class ConversationReportDto
{
    [ExcelCell(Name = "პირადი ნომერი", Column = 1)]
    public string PersonalNumber { get; set; }

    [ExcelCell(Name = "საკუთარი კონვერტაციების რაოდენობა", Column = 2)]
    public int ConversationsCountPerUser { get; set; }

    [ExcelCell(Name = "სრული კონვერტაციების რაოდენობა", Column = 3)]
    public int ConversationsCountTree { get; set; }
}