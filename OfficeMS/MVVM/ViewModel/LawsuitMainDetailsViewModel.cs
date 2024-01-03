using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using OfficeMS.MVVM.View;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfficeMS.MVVM.ViewModel
{
    class LawsuitMainDetailsViewModel:ObservableObject
    {
        public Lawsuit Lawsuit { get; set; }
        public LawsuitMainDetailsViewModel(Lawsuit lawsuit)
        {
            Lawsuit = lawsuit;
        }

        public void ViewDetails()
        {
            ClientDetails details = new ClientDetails();
            details.DataContext = new ClientDetailsViewModel(Lawsuit.Client);
            details.Show();
        }
    }
}
