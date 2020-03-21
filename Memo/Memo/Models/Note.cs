using Microsoft.WindowsAzure.MobileServices;
using SQLite;
using System;
using System.ComponentModel;

namespace Memo.Models
{
    [DataTable("Notes")]
    public class Note : INotifyPropertyChanged
    {
        private string id;
        private string text;
        private DateTime createdOn;
        private DateTime? updatedOn;
        private string venueName;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                this.OnPropertyChanged(nameof(Id));
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                this.OnPropertyChanged(nameof(Text));
            }
        }

        public DateTime CreatedOn
        {
            get { return createdOn; }
            set
            {
                createdOn = value;
                this.OnPropertyChanged(nameof(CreatedOn));
            }
        }

        public DateTime? UpdatedOn
        {
            get { return updatedOn; }
            set
            {
                updatedOn = value;
                this.OnPropertyChanged(nameof(UpdatedOn));
            }
        }

        public string VenueName
        {
            get { return venueName; }
            set { venueName = value; }
        }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public string UserId { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
