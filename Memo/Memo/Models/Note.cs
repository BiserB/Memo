using SQLite;
using System;
using System.ComponentModel;

namespace Memo.Models
{
    public class Note : INotifyPropertyChanged
    {
        private int id;
        private string text;
        private DateTime createdOn;
        private DateTime? updatedOn;
        
        [PrimaryKey, AutoIncrement]
        public int Id
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
