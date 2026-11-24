using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.UI.Services;

namespace Todo.UI.ViewModels
{
    public partial class TodoDetailViewModel : ObservableObject
    {
        private readonly TodoService _service;

        public TodoDetailViewModel(TodoService service)
        {
            _service = service;
        }

        
    }
}
