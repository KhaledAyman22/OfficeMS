using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace OfficeMS.MVVM.ViewModel
{
    class MainAddSuitViewModel:ObservableObject
    {
        private DateTime? _selectedDate { get; set; }
        private double? _prepayment { get; set; }
        private Lawsuit _lawsuit;
        private string _clientId;
        private string _cost;
        public string Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        public Lawsuit Lawsuit
        {
            get { return _lawsuit; }
            set { _lawsuit = value; }
        }
        public DateTime? SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; OnPropertyChanged(); }
        }
        public double? Prepayment
        {
            get { return _prepayment; }
            set { _prepayment = value; OnPropertyChanged(); }
        }


        public RelayCommand DefendantVC { get; set; }
        public RelayCommand ProsecutorVC { get; set; }

        public MainAddSuitViewModel()
        {
            Lawsuit = new Lawsuit { ClientDescription = "مدعى عليه" };
            DefendantVC = new RelayCommand(O => { Lawsuit.ClientDescription = "مدعى عليه"; });
            ProsecutorVC = new RelayCommand(O => { Lawsuit.ClientDescription = "مدعي"; });
        }

        public void AddSuit()
        {
            if (CheckData())
            {
                OfficeMSContext context = new OfficeMSContext();
                try
                {
                    Lawsuit.Day = Convert.ToDateTime(SelectedDate).ToString("dddd", new System.Globalization.CultureInfo("ar-EG"));
                    Lawsuit.Cost = Convert.ToDouble(Cost);
                    Lawsuit.Records = new ObservableCollection<LawsuitRecord>() { new LawsuitRecord { Decision = "", Date = (DateTime)SelectedDate } };
                    Lawsuit.Incomes = Prepayment == null ? null : new ObservableCollection<Income> { new Income { Amount = (double)Prepayment, Date = DateTime.Now } };

                    Client client = context.Client.Include("Lawsuits").Where(c => c.Id == ClientId).Single();
                    client.Lawsuits.Add(Lawsuit);
                    context.SaveChanges();
                    Clear();
                }
                catch
                {
                    MessageBox.Show("لا يوجد موكل بهذا الرقم القومي");
                }
            }
        }

        private bool CheckData()
        {
            
            bool number = !string.IsNullOrEmpty(Lawsuit.Number) && Regex.IsMatch(Lawsuit.Number, @"^[0-9]+$"); ;
            bool year = !string.IsNullOrEmpty(Lawsuit.Year) && Lawsuit.Year.Length == 4 && Regex.IsMatch(Lawsuit.Year, @"^[0-9]+$"); ;
            bool cost = !string.IsNullOrEmpty(Cost) && Regex.IsMatch(Cost, @"^[0-9.]+$");
            bool court = !string.IsNullOrEmpty(Lawsuit.Court);
            bool prepayment = Prepayment == null || Regex.IsMatch(Prepayment.ToString(), @"^[0-9.]+$");
            bool circle = !string.IsNullOrEmpty(Lawsuit.Circle);
            bool day = SelectedDate != null;
            bool oppName = !string.IsNullOrEmpty(Lawsuit.OpponentName);
            bool id = !string.IsNullOrEmpty(ClientId) && ClientId.Length==14 && Regex.IsMatch(ClientId, @"^[0-9]+$");

            if (!number) MessageBox.Show("خطأ في الرقم");
            if (!year) MessageBox.Show("خطأ في السنة");
            if (!court) MessageBox.Show("خطأ في المحكمة");
            if (!circle) MessageBox.Show("خطأ في الدفعة الدائرة");
            if (!day) MessageBox.Show("خطأ في الدفعة تاريخ الإنعقاد");
            if (!id) MessageBox.Show("خطأ في الرقم القومي");
            if (!oppName) MessageBox.Show("خطأ في الدفعة اسم الخصم");
            if (!cost) MessageBox.Show("خطأ في الاتعاب");
            if (!prepayment) MessageBox.Show("خطأ في الدفعة الاولى");
            return number && year && cost && prepayment && circle && day && oppName;
        }

        private void Clear()
        {
            Lawsuit = null; SelectedDate = null; ClientId = null; Prepayment = null; Cost = null;
        }
    }
}
