using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMS.MVVM.ViewModel
{
    class ClientDetailsViewModel:ObservableObject 
    {
        public RelayCommand MainVC { get; set; }
        public RelayCommand SuitsVC { get; set; }
        public RelayCommand AuthsVC { get; set; }

        public ClientMainDetailsViewModel MainDetailsVM { get; set; }
        public ClientLawsuitsDetailsViewModel SuitsDetailsVM { get; set; }
        public ClientAuthsDetailsViewModel AuthsDetailsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ClientDetailsViewModel(Client client)
        {
            MainDetailsVM = new ClientMainDetailsViewModel(client);
            SuitsDetailsVM = new ClientLawsuitsDetailsViewModel(client.Id);
            AuthsDetailsVM = new ClientAuthsDetailsViewModel(client.Id);

            CurrentView = MainDetailsVM;

            MainVC = new RelayCommand(O => { CurrentView = MainDetailsVM; });
            SuitsVC = new RelayCommand(O => { CurrentView = SuitsDetailsVM; });
            AuthsVC = new RelayCommand(O => { CurrentView = AuthsDetailsVM; });
        }
    }
}
