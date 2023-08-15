using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.Models
{
    public interface IDbObject
    {
        string GetName();
        int GetID();
        void SetName(string name);
        bool NextEntry();
        bool PrevEntry();
        bool DeleteEntry();
        Dictionary<int,String> GetEntries(int startId, int endId);
        bool AddEntries(ref Dictionary<int, String> entries);
        Dictionary<int, String> GetAllEntries();
        bool SetEntries(Dictionary<int, String> entries);
        bool AddEntry(string? name);
    }
}
