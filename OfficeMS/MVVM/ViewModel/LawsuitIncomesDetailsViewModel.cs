using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace OfficeMS.MVVM.ViewModel
{
    class LawsuitIncomesDetailsViewModel:ObservableObject
    {
        private int LawsuitId { get; set; }
        private double Cost { get; set; }
        private ObservableCollection<IncomesListViewRow> _incomes;
        private List<Income> rec;
        private double paid;
        private double? _amount;
        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged(); }
        }
        public double? Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(); }
        }
        public ObservableCollection<IncomesListViewRow> Incomes
        {
            get { return _incomes; }
            set { _incomes = value; OnPropertyChanged(); }
        }


        public LawsuitIncomesDetailsViewModel(int id, double cost)
        {
            Cost = cost;
            LawsuitId = id;
            SetData();
            GetPaymentsInfo();
        }

        public void AddIncome()
        {
            if(CheckData()) 
            {
                OfficeMSContext context = new OfficeMSContext();
                context.Lawsuit.Include("Incomes").Where(l => l.Id == LawsuitId).Single().Incomes.Add(new Income
                {
                    Amount = (double)Amount,
                    Date = DateTime.Now
                }); 
                context.SaveChanges();
                SetData();
                Clear();
                GetPaymentsInfo();
            }
        }

        private void GetPaymentsInfo()
        {
            paid = Incomes.Select(i => i.Amount).Sum();

            Info = string.Format("المــدفــوع:  {0}\tالمتـبـقــي:  {1}", paid, Cost - paid);
        }

        private bool CheckData()
        {
            bool amount = Amount != null && Amount != 0;
            if (!amount) MessageBox.Show("خطأ في المبلغ");
            return amount;
        }

        private void SetData()
        {
            Incomes = new ObservableCollection<IncomesListViewRow>();
            OfficeMSContext context = new OfficeMSContext();
            rec = context.Lawsuit.Include("Incomes").Where(l => l.Id == LawsuitId).Single().Incomes.ToList();
            foreach (var item in rec)
            {
                Incomes.Add(new IncomesListViewRow { Amount = item.Amount, Date = item.Date.ToShortDateString() });
            }
        }

        private void Clear()
        {
            Amount = null;
        }

        public void Print()
        {
            ExcelConverter excel = new ExcelConverter();
            excel.Incomes(rec,paid,Cost-paid);
        }
    }

    public class IncomesListViewRow
    {
        public double Amount { get; set; }
        public string Date { get; set; }
    }
}
