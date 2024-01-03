using System.Collections.ObjectModel;

namespace OfficeMS.MVVM.Model
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public ObservableCollection<Authorization> Authorizations { get; set; }
        public ObservableCollection<Lawsuit> Lawsuits { get; set; }
    }
}
