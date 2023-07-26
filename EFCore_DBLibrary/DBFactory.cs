using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DBLibrary
{
    public class DBFactory
    {
        private DbContextOptions<ShowCaseDbContext>? _options;
        
        public DBFactory()
        {

        }

        public DBFactory(DbContextOptions<ShowCaseDbContext> options)
        {
            _options = options;
        }

        public ShowCaseDbContext GetDbContext()
        {
            if (_options == null)
            {
                return new ShowCaseDbContext();
            }
            else
            {
                return new ShowCaseDbContext(_options);
            }
        }
    }
}
