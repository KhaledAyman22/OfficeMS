using OfficeMS.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for SearchSuit.xaml
    /// </summary>
    public partial class SearchSuit : UserControl
    {
        

        public SearchSuit()
        {
            InitializeComponent();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainSearchSuitViewModel)this.DataContext).ViewDetails(LawsuitsListView.SelectedIndex);

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainSearchSuitViewModel)this.DataContext).RunSearch();
        }
    }
}
