﻿using System;
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
        Dictionary<int,String> GetEntries(int startId, int endId);
        Dictionary<int,String> AddEntries(int amount);
        Dictionary<int, String> GetAllEntries();
        bool SaveEntries();
        bool SetEntries(Dictionary<int, String> entries);
    }
}
