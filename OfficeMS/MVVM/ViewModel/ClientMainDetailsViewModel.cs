using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System.Linq;

namespace OfficeMS.MVVM.ViewModel
{
    class ClientMainDetailsViewModel : ObservableObject
    {
        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; OnPropertyChanged(); }
        }

        public ClientMainDetailsViewModel(Client client)
        {
            Client = client;
        }
    }
}
