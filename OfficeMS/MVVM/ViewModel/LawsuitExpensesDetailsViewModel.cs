using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace OfficeMS.MVVM.ViewModel
{
    class LawsuitExpensesDetailsViewModel : ObservableObject
    {
        private int LawsuitId { get; set; }
        private ObservableCollection<ExpensesListViewRow> _expenses;
        private double? _amount;
        private string _statment;
        private string _total;
        private double total;
        private List<Expense> rec;
        public string Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(); }
        }
        public string Statment
        {
            get { return _statment; }
            set { _statment = value; OnPropertyChanged(); }
        }
        public double? Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(); }
        }
        public ObservableCollection<ExpensesListViewRow> Expenses
        {
            get { return _expenses; }
            set { _expenses = value; OnPropertyChanged(); }
        }


        public LawsuitExpensesDetailsViewModel(int id)
        {
            LawsuitId = id;
            SetData();
            GetTotal();
        }

        public void AddExpense()
        {
            if (CheckData())
            {
                OfficeMSContext context = new OfficeMSContext();
                context.Lawsuit.Include("Expenses").Where(l => l.Id == LawsuitId).Single().Expenses.Add(new Expense
                {
                    Amount = (double)Amount,
                    Date = DateTime.Now,
                    Statment = Statment
                });
                context.SaveChanges();
                SetData();
                GetTotal();
                Clear();
            }
        }

        private void GetTotal()
        {
            total = Expenses.Select(e => e.Amount).Sum();
            Total = string.Format("الإجمــالــي:  {0}", total);
        }

        private bool CheckData()
        {
            bool amount = Amount != null && Amount != 0;
            bool statment = !string.IsNullOrWhiteSpace(Statment);
            if (!amount) MessageBox.Show("خطأ في المبلغ");
            if (!statment) MessageBox.Show("خطأ في البيان");
            return amount && statment;
        }

        private void SetData()
        {
            Expenses = new ObservableCollection<ExpensesListViewRow>();
            OfficeMSContext context = new OfficeMSContext();
            rec = context.Lawsuit.Include("Expenses").Where(l => l.Id == LawsuitId).Single().Expenses.ToList();
            foreach (var item in rec)
            {
                Expenses.Add(new ExpensesListViewRow { Amount = item.Amount, Statment = item.Statment, Date = item.Date.ToShortDateString() });
            }
        }

        private void Clear()
        {
            Amount = null;Statment = null;
        }

        public void Print()
        {
            ExcelConverter excel = new ExcelConverter();
            excel.Expenses(rec, total);
        }
    }

    public class ExpensesListViewRow
    {
        public double Amount { get; set; }
        public string Date { get; set; }
        public string Statment { get; set; }
    }
}
