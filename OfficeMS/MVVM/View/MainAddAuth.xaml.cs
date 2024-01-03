using OfficeMS.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddAuth.xaml
    /// </summary>
    public partial class AddAuth : UserControl
    {
        public AddAuth()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainAddAuthViewModel)this.DataContext).AddClient(); 
        }        
    }
}
