using EFCore_DBLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.Models
{
    public class dbObjectModel : IdbObject
    {
        private DBFactory dBFactory;

        public dbObjectModel()
        {
            dBFactory = new DBFactory();
        }

        public int GetiD()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public bool NextEntry()
        {
            throw new NotImplementedException();
        }

        public bool PrevEntry()
        {
            throw new NotImplementedException();
        }

        public bool SaveEntry(string name)
        {
            throw new NotImplementedException();
        }

        public void SetName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
