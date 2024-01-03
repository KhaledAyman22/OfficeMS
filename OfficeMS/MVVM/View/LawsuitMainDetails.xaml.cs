using OfficeMS.MVVM.ViewModel;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainDetails.xaml
    /// </summary>
    public partial class MainDetails : UserControl
    {
        public MainDetails()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ((LawsuitMainDetailsViewModel)this.DataContext).ViewDetails();
        }
    }
}
