using OfficeMS.MVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OfficeMS.MVVM.View
{
    /// <summary>
    /// Interaction logic for Agenda.xaml
    /// </summary>
    /// 
    public partial class Agenda : UserControl
    {
        public Agenda()
        {
            InitializeComponent();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MainAgendaViewModel)this.DataContext).GetDateLawsuits((DateTime)Calendar.SelectedDate);
        }

        
        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainAgendaViewModel)this.DataContext).ViewDetails(LawsuitsListView.SelectedIndex);
        }
    }   
}
