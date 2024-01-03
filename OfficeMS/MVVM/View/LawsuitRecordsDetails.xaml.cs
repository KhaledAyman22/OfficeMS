using OfficeMS.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for RecordsDetails.xaml
    /// </summary>
    public partial class RecordsDetails : UserControl
    {
        public RecordsDetails()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ((LawsuitRecordsDetailsViewModel)this.DataContext).AddRecord();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            ((LawsuitRecordsDetailsViewModel)this.DataContext).Print();
        }
    }
}
