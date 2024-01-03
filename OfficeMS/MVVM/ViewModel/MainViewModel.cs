using OfficeMS.Core;

namespace OfficeMS.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand AgendaVC { get; set; }
        public RelayCommand AddSuitVC { get; set; }
        public RelayCommand AddAuthVC { get; set; }
        public RelayCommand AddClientVC { get; set; }
        public RelayCommand SearchClientVC { get; set; }
        public RelayCommand SearchAuthVC { get; set; }
        public RelayCommand SearchSuitVC { get; set; }

        public MainAgendaViewModel AgendaVM { get; set; }
        public MainAddAuthViewModel AddAuthVM { get; set; }
        public MainAddSuitViewModel AddSuitVM { get; set; }
        public MainAddClientViewModel AddClientVM { get; set; }
        public MainSearchClientViewModel SearchClientVM { get; set; }
        public MainSearchAuthViewModel SearchAuthVM { get; set; }
        public MainSearchSuitViewModel SearchSuitVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {

            AgendaVM = new MainAgendaViewModel();
            AddAuthVM = new MainAddAuthViewModel();
            AddClientVM = new MainAddClientViewModel();
            AddSuitVM = new MainAddSuitViewModel();
            SearchClientVM = new MainSearchClientViewModel();
            SearchSuitVM = new MainSearchSuitViewModel();
            SearchAuthVM = new MainSearchAuthViewModel();

            CurrentView = AgendaVM;
            
            AgendaVC = new RelayCommand(O => { CurrentView = AgendaVM; });
            AddAuthVC = new RelayCommand(O => { CurrentView = AddAuthVM; });
            AddClientVC = new RelayCommand(O => { CurrentView = AddClientVM; });
            AddSuitVC = new RelayCommand(O => { CurrentView = AddSuitVM; });
            SearchClientVC = new RelayCommand(O => { CurrentView = SearchClientVM; });
            SearchSuitVC = new RelayCommand(O => { CurrentView = SearchSuitVM; });
            SearchAuthVC = new RelayCommand(O => { CurrentView = SearchAuthVM; });
        }
    }
}
