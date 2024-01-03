using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using OfficeMS.MVVM.View;
using System.Collections.ObjectModel;
using System.Linq;

namespace OfficeMS.MVVM.ViewModel
{
    class MainSearchSuitViewModel:ObservableObject
    {
        public string CName { get; set; }
        private ObservableCollection<Lawsuit> _searchResult { get; set; }

        public ObservableCollection<Lawsuit> SearchResult
        {
            get { return _searchResult; }
            set { _searchResult = value; OnPropertyChanged(); }
        }

        public void RunSearch()
        {
            OfficeMSContext context = new OfficeMSContext();
            var Client = context.Client.Where(c => c.Name.Contains(CName)).Select(c => c.Id);
            var Lawsuits = context.Lawsuit
                                  .Include("Client")
                                  .Where(l => Client.Contains(l.Client.Id));

            SearchResult = new ObservableCollection<Lawsuit>(Lawsuits);
        }

        public void ViewDetails(int index)
        {
            LawsuitDetails details = new LawsuitDetails();
            details.DataContext = new LawsuitDetailsViewModel(SearchResult[index]);
            details.Show();
        }
    }
}
