using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Todo.UI.Models
{
    public class TodoItem
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _title ="";
        private string _description = "";
        private bool _isCompleted;
        private DateTime _dueDate;

        public string Title { get => _title; set 
            {
                if (!_title.Equals(value)) {

                    _title = value; OnPropertyChanged();
                }
            } 
        }
        public string Description { get => _description; set => _description = value; }
        public bool IsCompleted { get => _isCompleted; set {
                if(!_isCompleted.Equals(value))
                {
                    _isCompleted = value; OnPropertyChanged();
                }
            } 
        }
        public DateTime DueDate { get => _dueDate; set => _dueDate = value; }
    }
}
