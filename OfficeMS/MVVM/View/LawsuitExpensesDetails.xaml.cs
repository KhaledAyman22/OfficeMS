using OfficeMS.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for ExpensesDetails.xaml
    /// </summary>
    public partial class ExpensesDetails : UserControl
    {
        public ExpensesDetails()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ((LawsuitExpensesDetailsViewModel)this.DataContext).AddExpense();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            ((LawsuitExpensesDetailsViewModel)this.DataContext).Print();
        }
    }
}
