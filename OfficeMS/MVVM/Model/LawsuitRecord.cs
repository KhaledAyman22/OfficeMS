using System;

namespace OfficeMS.MVVM.Model
{
    public class LawsuitRecord
    {
        public int Id { get; set; }
        public string Decision { get; set; }
        public DateTime Date { get; set; }
        public virtual Lawsuit Lawsuit { get; set; }
    }
}