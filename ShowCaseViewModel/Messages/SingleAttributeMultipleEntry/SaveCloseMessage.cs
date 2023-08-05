using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages.MainAddMutlipleDialog
{
    public class SaveCloseMessage : ValueChangedMessage<bool>
    {
        public SaveCloseMessage(bool value) : base(value)
        {
        }
    }
}
