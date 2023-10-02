using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages.Universal
{
    public class ExceptionMessage : ValueChangedMessage<Exception>
    {
        public ExceptionMessage(Exception value) : base(value)
        {
        }
    }
}
