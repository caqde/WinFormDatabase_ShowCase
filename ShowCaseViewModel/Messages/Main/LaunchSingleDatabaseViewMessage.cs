using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages.Main
{
    public class LaunchSingleDatabaseViewMessage : ValueChangedMessage<bool>
    {
        public LaunchSingleDatabaseViewMessage(bool value) : base(value)
        {
        }
    }
}
