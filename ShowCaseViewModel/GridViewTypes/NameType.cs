using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.GridViewTypes
{
    public class NameType
    {
        public NameType() 
        {
            Name = "NULL";
        }
        public NameType(string name) 
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
