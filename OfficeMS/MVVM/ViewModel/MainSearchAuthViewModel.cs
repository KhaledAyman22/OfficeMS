using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace OfficeMS.MVVM.ViewModel
{
    class MainSearchAuthViewModel:ObservableObject
    {
        public string CName { get; set; }
        private ObservableCollection<Authorization> _searchResult { get; set; }

        public ObservableCollection<Authorization> SearchResult
        {
            get { return _searchResult; }
            set { _searchResult = value; OnPropertyChanged(); }
        }

        public MainSearchAuthViewModel()
        {
            SearchResult = new ObservableCollection<Authorization>();
        }

        public void RunSearch()
        {
            OfficeMSContext context = new OfficeMSContext();
            var Clients = context.Client.Where(c => c.Name.Contains(CName)).Select(c => c.Id);
            var Auths = context.Authorization.Where(a => Clients.Contains(a.Client.Id));

            SearchResult = new ObservableCollection<Authorization>(Auths);
        }
    }
}
