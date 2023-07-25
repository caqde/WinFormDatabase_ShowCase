using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages
{
    public class SaveMessage: ValueChangedMessage<bool>
    {
        public SaveMessage(bool value) : base(value) 
        { 
        }
    }
}
