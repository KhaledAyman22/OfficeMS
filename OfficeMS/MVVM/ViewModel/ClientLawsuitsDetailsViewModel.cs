using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace OfficeMS.MVVM.ViewModel
{
    class ClientLawsuitsDetailsViewModel : ObservableObject
    {
        private ObservableCollection<Lawsuit> _lawsuits;
        private string ClientId { get; set; }
        public ObservableCollection<Lawsuit> Lawsuits
        {
            get { return _lawsuits; }
            set { _lawsuits = value; OnPropertyChanged(); }
        }

        public ClientLawsuitsDetailsViewModel(string id)
        {
            ClientId = id;
            OfficeMSContext context = new OfficeMSContext();
            Lawsuits = new ObservableCollection<Lawsuit>(context.Lawsuit.Include("Client").Where(l => l.Client.Id == ClientId));
        }
    }
}
