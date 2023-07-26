using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages
{
    public class DeleteMessage : ValueChangedMessage<bool>
    {
        public DeleteMessage(bool value) : base(value)
        {
        }
    }
}
