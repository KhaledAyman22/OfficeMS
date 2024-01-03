using OfficeMS.Core;
using OfficeMS.MVVM.Model;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace OfficeMS.MVVM.ViewModel
{
    class MainAddAuthViewModel : ObservableObject
    {
        private string _character { get; set; }
        private string _number { get; set; }
        private string _year { get; set; }
        private string _office { get; set; }
        private string _clientId { get; set; }
        public string Character
        {
            get { return _character; }
            set { _character = value; OnPropertyChanged(); }
        }
        public string Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged(); }
        }
        public string Year
        {
            get { return _year; }
            set { _year = value; OnPropertyChanged(); }
        }
        public string Office
        {
            get { return _office; }
            set { _office = value; OnPropertyChanged(); }
        }
        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; OnPropertyChanged(); }
        }

        public void AddClient()
        {
            if (CheckData())
            {
                OfficeMSContext context = new OfficeMSContext();
                try
                {
                    Client client = context.Client.Include("Authorizations").Where(c => c.Id == ClientId).Single();
                    client.Authorizations.Add(new Authorization
                    {
                        Character = Character,
                        Number = Number,
                        Year = Year,
                        Office = Office
                    });
                    context.SaveChanges();
                    Clear();
                }
                catch
                {
                    MessageBox.Show("لا يوجد موكل بهذا الرقم القومي");
                }
            }
        }

        private bool CheckData()
        {
            bool charc = !string.IsNullOrEmpty(Character) && Character.Length == 1;
            bool number = !string.IsNullOrEmpty(Number) && Regex.IsMatch(Number, @"^[0-9]+$"); ;
            bool year = !string.IsNullOrEmpty(Year) && Year.Length == 4 && Regex.IsMatch(Year, @"^[0-9]+$"); ;
            bool office = !string.IsNullOrEmpty(Office);
            bool id = !string.IsNullOrEmpty(ClientId) && ClientId.Length == 14 && Regex.IsMatch(ClientId, @"^[0-9]+$");
            if (!charc) MessageBox.Show("خطأ في الحرف");
            if (!number) MessageBox.Show("خطأ في الرقم");
            if (!year) MessageBox.Show("خطأ في السنة");
            if (!office) MessageBox.Show("خطأ في مكتب التوثيق");
            if (!id) MessageBox.Show("خطأ في الرقم القومي");

            return charc && number && year && office && id;
        }

        private void Clear()
        {
            Character = Number = Year = Office = ClientId = null;
        }
    }
}
