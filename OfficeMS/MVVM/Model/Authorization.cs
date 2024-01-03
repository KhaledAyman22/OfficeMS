namespace OfficeMS.MVVM.Model
{
    public class Authorization
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Character { get; set; }
        public string Year { get; set; }
        public string Office { get; set; }
        public virtual Client Client { get; set; }
    }
}
