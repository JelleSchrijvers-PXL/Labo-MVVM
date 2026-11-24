using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.UI.Models;

namespace Todo.UI.Messages
{
    public class TodoAddMessage : ValueChangedMessage<TodoItem>
    {
        public TodoAddMessage(TodoItem value) : base(value)
        {
            
        }
    }
}
