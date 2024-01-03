using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace OfficeMS.MVVM.ViewModel
{

    class LawsuitRecordsDetailsViewModel:ObservableObject
    {
        private int LawsuitId { get; set; }
        public RelayCommand Postponed { get; set; }
        public RelayCommand Final { get; set; }

        private Visibility _datePickerVis;
        private ObservableCollection<RecordsListViewRow> _records;
        private DateTime? _selectedDate;
        private string _decision;
        private List<LawsuitRecord> rec;
        public string Decision
        {
            get { return _decision; }
            set { _decision = value; OnPropertyChanged(); }
        }
        public DateTime? SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; OnPropertyChanged(); }
        }
        public ObservableCollection<RecordsListViewRow> Records
        {
            get { return _records; }
            set { _records = value; OnPropertyChanged(); }
        }
        public Visibility DatePickerVis
        {
            get { return _datePickerVis; }
            set { _datePickerVis = value; base.OnPropertyChanged(); }
        }


        public LawsuitRecordsDetailsViewModel(int id)
        {
            LawsuitId = id;
            DatePickerVis = Visibility.Visible;
            Final = new RelayCommand(O => { DatePickerVis = Visibility.Collapsed; });
            Postponed = new RelayCommand(O => { DatePickerVis = Visibility.Visible; });
            SetData();  
        }

        public void AddRecord()
        {
            if (CheckData())
            {
                OfficeMSContext context = new OfficeMSContext();

                context.Lawsuit.Include("Records").Where(l => l.Id == LawsuitId).Single().Records.OrderByDescending(r => r.Date).FirstOrDefault().Decision = _decision;
                if (DatePickerVis == Visibility.Visible) //aka final decision
                {
                    context.Lawsuit.Include("Records").Where(l => l.Id == LawsuitId).Single().Records.Add(new LawsuitRecord
                    {
                        Decision = "بإنتظار الجلسة",
                        Date = (DateTime)SelectedDate
                    });
                }
                context.SaveChanges();
                SetData();
                Clear();
            }
        }

        private void SetData()
        {
            Records = new ObservableCollection<RecordsListViewRow>();
            OfficeMSContext context = new OfficeMSContext();
            rec = context.Lawsuit.Include("Records").Where(l => l.Id == LawsuitId).Single().Records.ToList();
            foreach (var item in rec)
            {
                Records.Add(new RecordsListViewRow { Decision = item.Decision, Date = item.Date.ToShortDateString() });
            }
        }

        private bool CheckData()
        {
            bool selectedDate = (SelectedDate != null && SelectedDate > DateTime.Today) || DatePickerVis == Visibility.Collapsed;
            bool decision = !string.IsNullOrWhiteSpace(_decision);

            if (!selectedDate) MessageBox.Show("خطأ في تاريخ الجلسة القادمة");
            if (!decision) MessageBox.Show("خطأ القرار");

            return selectedDate && decision;
        }

        private void Clear()
        {
            _decision = null;
            SelectedDate = null;
            DatePickerVis = Visibility.Visible;
        }

        public void Print()
        {
            ExcelConverter excel = new ExcelConverter();
            excel.Records(rec);
        }
    }

    public class RecordsListViewRow
    {
        public string Decision { get; set; }
        public string Date { get; set; }
    }
}
