using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages.LibraryMessages
{
    public class LibraryGetItem : ValueChangedMessage<bool>
    {
        public LibraryGetItem(bool value) : base(value)
        {
        }
    }
}
