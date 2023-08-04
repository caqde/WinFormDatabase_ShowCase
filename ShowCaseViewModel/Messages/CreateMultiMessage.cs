using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages
{
    public class CreateMultiMessage : ValueChangedMessage<int>
    {
        public CreateMultiMessage(int value) : base(value)
        {
        }
    }
}
