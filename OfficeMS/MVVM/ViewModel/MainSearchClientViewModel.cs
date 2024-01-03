using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using OfficeMS.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMS.MVVM.ViewModel
{
    class MainSearchClientViewModel:ObservableObject
    {
        public string CName { get; set; }
        private ObservableCollection<Client> _searchResult { get; set; }

        public ObservableCollection<Client> SearchResult
        {
            get { return _searchResult; }
            set { _searchResult = value; OnPropertyChanged(); }
        }

        public void RunSearch()
        {
            OfficeMSContext context = new OfficeMSContext();
            var Client = context.Client.Where(c => c.Name.Contains(CName));
            SearchResult = new ObservableCollection<Client>(Client);
        }

        public void ViewDetails(int index)
        {
            ClientDetails details = new ClientDetails();
            details.DataContext = new ClientDetailsViewModel(SearchResult[index]);
            details.Show();
        }
    }
}
