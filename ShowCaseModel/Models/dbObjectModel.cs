using EFCore_DBLibrary;
using EFCore_DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.Models
{
    public class dbObjectModel : IdbObject
    {
        private DBFactory dBFactory;
        private int currentID;
        private dbObject? currentdBObject;

        public dbObjectModel()
        {
            dBFactory = new DBFactory();
            using (var context = dBFactory.GetDbContext())
            {
                currentdBObject = context.dbObjects.FirstOrDefault();
                if (currentdBObject != null)
                {
                    currentID = currentdBObject.Id;
                }
                else
                {
                    currentID = 0;
                }
            }
        }

        public bool AddEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                currentdBObject = new dbObject { Name = "tempNew" };
                context.Add(currentdBObject);
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                context.Remove(currentdBObject);
                context.SaveChanges();
                return true;
            }
        }

        public int GetiD()
        {
            return currentID;
        }

        public string GetName()
        {
            if (currentdBObject is not null)
            {
                return currentdBObject.Name;
            }
            else
            {
                return "NULL";
            }
        }

        public bool NextEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                var next = context.Set<dbObject>().Where(t => t.Id > currentID).Order().Take(1).Single();
                if (next is not null)
                {
                    currentdBObject = next;
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool PrevEntry()
        {
            using (var context = dBFactory.GetDbContext())
            {
                var next = context.Set<dbObject>().Where(t => t.Id < currentID).OrderDescending().Take(1).Single();
                if (next is not null)
                {
                    currentdBObject = next;
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool SaveEntry(string name)
        {
            using (var context = dBFactory.GetDbContext())
            {
                if (currentdBObject != null)
                {
                    context.Update(currentdBObject);
                }
                context.SaveChanges();
                return true;
            }
        }

        public void SetName(string name)
        {
            if (currentdBObject is not null)
            {
                currentdBObject.Name = name;
                return;
            }
            else
            {
                return;
            }
        }
    }
}
