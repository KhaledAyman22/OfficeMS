using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using OfficeMS.MVVM.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace OfficeMS.MVVM.ViewModel
{
    class MainAgendaViewModel:ObservableObject
    {
        private ObservableCollection<AgendaListViewRow> _todaysLawsuits;

        public ObservableCollection<AgendaListViewRow> TodaysLawsuits
        {
            get { return _todaysLawsuits; }
            set { _todaysLawsuits = value; OnPropertyChanged(); }
        }

        public MainAgendaViewModel()
        {
            GetDateLawsuits(DateTime.Now);
        }

        public void GetDateLawsuits(DateTime date)
        {
            OfficeMSContext context = new OfficeMSContext();
            date = date.Date;
            var nxtDay = date.AddDays(1).Date;

            var RecOnDate = context.LawsuitRecord.Where(r => r.Date >= date && r.Date < nxtDay).Select(r => r.Lawsuit.Id);
            var Lawsuits = context.Lawsuit
                                  .Include("Records")
                                  .Include("Client")
                                  .Where(l => RecOnDate.Contains(l.Id));

            TodaysLawsuits = new ObservableCollection<AgendaListViewRow>();
            foreach (var item in Lawsuits)
            {
                var tmp = item.Records.Where(r => r.Date < date).OrderByDescending(r => r.Date).FirstOrDefault();
                var LDate = tmp == null ? "أول جلسة" : tmp.Date.ToShortDateString();
                var CDecision = item.Records.Where(r => r.Date >= date && r.Date < nxtDay).Single().Decision;

                TodaysLawsuits.Add(new AgendaListViewRow
                {
                    Lawsuit = item,
                    LastDate = LDate,
                    Decision = CDecision
                });
            }
        }

        public void ViewDetails(int index)
        {
            LawsuitDetails details = new LawsuitDetails();
            details.DataContext = new LawsuitDetailsViewModel(TodaysLawsuits[index].Lawsuit);
            details.Show();
        }
    }

    public class AgendaListViewRow
    {
        public Lawsuit Lawsuit { get; set; }
        public string LastDate { get; set; }
        public string Decision { get; set; }
    }
}

