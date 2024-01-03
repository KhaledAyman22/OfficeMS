using OfficeMS.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for IncomesDetails.xaml
    /// </summary>
    public partial class IncomesDetails : UserControl
    {
        public IncomesDetails()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ((LawsuitIncomesDetailsViewModel)this.DataContext).AddIncome();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            ((LawsuitIncomesDetailsViewModel)this.DataContext).Print();
        }
    }
}
