using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Todo.UI.Models
{
    public partial class TodoItem : ObservableObject
    {
        [ObservableProperty]
        private string _title ="";
        [ObservableProperty]
        private string _description = "";
        [ObservableProperty]
        private bool _isCompleted;
        [ObservableProperty]
        private DateTime _dueDate;
    }
}
