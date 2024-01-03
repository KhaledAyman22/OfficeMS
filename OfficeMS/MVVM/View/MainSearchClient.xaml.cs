using OfficeMS.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for SearchClient.xaml
    /// </summary>
    public partial class SearchClient : UserControl
    {
        public SearchClient()
        {
            InitializeComponent();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainSearchClientViewModel)this.DataContext).ViewDetails(ClientsListView.SelectedIndex);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainSearchClientViewModel)this.DataContext).RunSearch();
        }
    }
}
