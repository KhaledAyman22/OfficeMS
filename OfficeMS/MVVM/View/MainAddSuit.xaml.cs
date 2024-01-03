using OfficeMS.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddSuit.xaml
    /// </summary>
    public partial class AddSuit : UserControl
    {
        public AddSuit()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainAddSuitViewModel)this.DataContext).AddSuit();
        }
    }
}
