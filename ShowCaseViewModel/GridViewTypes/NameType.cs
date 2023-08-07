using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.GridViewTypes
{
    public partial class NameType: ObservableObject
    {
        public NameType() 
        {
            name = "NULL";
        }
        public NameType(string _name) 
        {
            name = _name;
        }

        [ObservableProperty]
        private string name;

    }
}
