using System.Collections.ObjectModel;



namespace OfficeMS.MVVM.Model
{
    public class Lawsuit
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Year { get; set; }
        public string Court { get; set; }
        public string Circle { get; set; }
        public string Day { get; set; }
        public double Cost { get; set; }
        public ObservableCollection<LawsuitRecord> Records { get; set; }
        public ObservableCollection<Income> Incomes { get; set; }
        public ObservableCollection<Expense> Expenses { get; set; }
        public string ClientDescription { get; set; }
        public string OpponentName { get; set; }
        public virtual Client Client { get; set; }
    }
}
