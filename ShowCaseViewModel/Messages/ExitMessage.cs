using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages
{
    public class ExitMessage : ValueChangedMessage<bool>
    {
        public ExitMessage(bool value) : base(value)
        {
        }
    }
}
