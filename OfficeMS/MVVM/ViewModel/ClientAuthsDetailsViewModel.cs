using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMS.MVVM.ViewModel
{
    class ClientAuthsDetailsViewModel : ObservableObject
    {
        private ObservableCollection<Authorization> _auths;
        private string ClientId;
        public ObservableCollection<Authorization> Auths
        {
            get { return _auths; }
            set { _auths = value; }
        }

        public ClientAuthsDetailsViewModel(string id)
        {
            ClientId = id;
            OfficeMSContext context = new OfficeMSContext();
            Auths = new ObservableCollection<Authorization>(context.Authorization.Where(a => a.Client.Id == ClientId));
        }

    }
}
