using Microsoft.Office.Interop.Excel;
using OfficeMS.MVVM.Model;
using System.Collections.Generic;

namespace OfficeMS
{
    class ExcelConverter
    {
        Application excapp;
        Workbook workbook;
        Worksheet sheet;
        int sheetC;

        public ExcelConverter()
        {
            excapp = new Application { Visible = true };
            workbook = excapp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            sheetC = 0;
        }

        public void Expenses(List<Expense> list,double total)
        {
            sheet = workbook.Sheets[++sheetC];
            sheet.Columns.ColumnWidth = 20;
            sheet.Cells[1, 1] = "البيان";
            sheet.Cells[1, 2] = "التاريخ";
            sheet.Cells[1, 3] = "المبلغ";

            int j = 2;
            for (int i = 1; i < list.Count + 1; i++)
            {
                sheet.Cells[j, 1] = list[i - 1].Statment;
                sheet.Cells[j, 2] = list[i - 1].Date;
                sheet.Cells[j, 3] = list[i - 1].Amount;
                j++;
            }

            int infoRow = list.Count + 3;
            sheet.Cells[infoRow, 3] = total;
            sheet.Cells[infoRow, 4] = "الإجمـالــي";
        }

        public void Incomes(List<Income> list,double paid,double remaining)
        {
            sheet = workbook.Sheets[++sheetC];
            sheet.Columns.ColumnWidth = 20;
            sheet.Cells[1, 1] = "التاريخ";
            sheet.Cells[1, 2] = "المبلغ";

            int j = 2;
            for (int i = 1; i < list.Count + 1; i++)
            {
                sheet.Cells[j, 1] = list[i - 1].Date;
                sheet.Cells[j, 2] = list[i - 1].Amount;
                j++;
            }

            int infoRow = list.Count + 3;
            sheet.Cells[infoRow, 2] = paid;
            sheet.Cells[infoRow, 3] = "المدفــوع";
            infoRow++;
            sheet.Cells[infoRow, 2] = remaining;
            sheet.Cells[infoRow, 3] = "المتـبـقي";
        }

        public void Records(List<LawsuitRecord> list)
        {
            sheet = workbook.Sheets[++sheetC];
            sheet.Columns.ColumnWidth = 20;
            sheet.Cells[1, 1] = "القرار";
            sheet.Cells[1, 2] = "تاريخ الجلسة";

            int j = 2;
            for (int i = 1; i < list.Count + 1; i++)
            {
                sheet.Cells[j, 1] = list[i - 1].Decision;
                sheet.Cells[j, 2] = list[i - 1].Date;
                j++;
            }
        }

        public void All(List<Expense> list1, List<Income> list2, List<LawsuitRecord> list3,double total, double paid, double remaining)
        {
            Expenses(list1, total);
            Incomes(list2, paid, remaining);
            Records(list3);
        }

    }   
}

