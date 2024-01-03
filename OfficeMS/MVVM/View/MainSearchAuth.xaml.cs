using OfficeMS.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for SearchAuth.xaml
    /// </summary>
    public partial class SearchAuth : UserControl
    {
        public SearchAuth()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainSearchAuthViewModel)this.DataContext).RunSearch();
        }
    }
}
