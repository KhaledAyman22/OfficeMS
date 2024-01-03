using OfficeMS.Core;
using OfficeMS.MVVM.Model;

namespace OfficeMS.MVVM.ViewModel
{
    class LawsuitDetailsViewModel:ObservableObject
    {
        public RelayCommand MainVC { get; set; }
        public RelayCommand RecordsVC { get; set; }
        public RelayCommand IncomesVC { get; set; }
        public RelayCommand ExpensesVC { get; set; }

        public LawsuitMainDetailsViewModel MainDetailsVM { get; set; }
        public LawsuitRecordsDetailsViewModel RecordsDetailsVM { get; set; }
        public LawsuitExpensesDetailsViewModel ExpensesDetailsVM { get; set; }
        public LawsuitIncomesDetailsViewModel IncomesDetailsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public LawsuitDetailsViewModel(Lawsuit lawsuit)
        {
            MainDetailsVM = new LawsuitMainDetailsViewModel(lawsuit);
            RecordsDetailsVM = new LawsuitRecordsDetailsViewModel(lawsuit.Id);
            ExpensesDetailsVM = new LawsuitExpensesDetailsViewModel(lawsuit.Id);
            IncomesDetailsVM = new LawsuitIncomesDetailsViewModel(lawsuit.Id, lawsuit.Cost);

            CurrentView = MainDetailsVM;

            MainVC = new RelayCommand(O => { CurrentView = MainDetailsVM; });
            RecordsVC = new RelayCommand(O => { CurrentView = RecordsDetailsVM; });
            IncomesVC = new RelayCommand(O => { CurrentView = IncomesDetailsVM; });
            ExpensesVC = new RelayCommand(O => { CurrentView = ExpensesDetailsVM; });
        }
    }
}
