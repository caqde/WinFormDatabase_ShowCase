﻿using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.Messages.LibraryMessages
{
    public class LibraryRemoveItem : ValueChangedMessage<bool>
    {
        public LibraryRemoveItem(bool value) : base(value)
        {
        }
    }
}
