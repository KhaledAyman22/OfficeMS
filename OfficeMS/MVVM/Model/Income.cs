using System;

namespace OfficeMS.MVVM.Model
{
    public class Income
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual Lawsuit Lawsuit { get; set; }
    }
}
