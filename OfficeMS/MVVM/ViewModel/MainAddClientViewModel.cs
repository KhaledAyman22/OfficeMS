using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace OfficeMS.MVVM.ViewModel
{
    class MainAddClientViewModel:ObservableObject
    {
        private string _id { get; set; }
        private string _cName { get; set; }
        private string _address { get; set; }
        private string _mobile { get; set; }

        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        public string CName
        {
            get { return _cName; }
            set { _cName = value; OnPropertyChanged(); }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(); }
        }
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; OnPropertyChanged(); }
        }

        public void AddClient()
        {
            if (CheckData())
            {
                OfficeMSContext context = new OfficeMSContext();
                context.Client.Add(new Client
                {
                    Id = Id,
                    Name = CName,
                    Address = Address,
                    Mobile = Mobile
                });
                context.SaveChanges();
                Clear();
            }
        }

        private bool CheckData()
        {
            bool id = !string.IsNullOrEmpty(Id) && Id.Length == 14 && Regex.IsMatch(Id, @"^[0-9]+$");
            bool mobile = !string.IsNullOrEmpty(Mobile) && Mobile.Length == 11 && Regex.IsMatch(Mobile, @"^[0-9]+$"); ;
            bool address = !string.IsNullOrEmpty(Address);
            bool cName = !string.IsNullOrEmpty(CName);
            if (!id) MessageBox.Show("خطأ في الرقم القومي");
            if (!cName) MessageBox.Show("خطأ في الاسم");
            if (!address) MessageBox.Show("خطأ في العنوان");
            if (!mobile) MessageBox.Show("خطأ في الهاتف");
            return id && mobile && address&& cName;
        }

        private void Clear()
        {
            Id = CName = Address = Mobile = null;
        }
    }
}
