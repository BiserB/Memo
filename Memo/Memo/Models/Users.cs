using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Memo.Models
{
    public class Users : INotifyPropertyChanged
    {
        private string id;
        private string email;
        private string password;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                this.OnPropertyChanged(nameof(Id));
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                this.OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                this.OnPropertyChanged(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
