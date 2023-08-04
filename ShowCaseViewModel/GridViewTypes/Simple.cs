using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModel.GridViewTypes
{
    public class Simple
    {
        public Simple() 
        {
            Name = "NULL";
        }
        public Simple(string name) 
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
