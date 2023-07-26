using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.Models
{
    public interface IdbObject
    {
        string GetName();
        int GetiD();
        void SetName(string name);
        bool NextEntry();
        bool PrevEntry();
        bool SaveEntry();
        bool AddEntry();
        bool DeleteEntry();
    }
}
