using ShowCaseModel.Models;

namespace ShowCaseModel
{
    public class ShowCaseInstance
    {
        public static ShowCaseInstance Instance { get; } = new ShowCaseInstance();

        private DbObjectModel DBObject = new DbObjectModel();

        public DbObjectModel getDBObject()
        {
            return DBObject;
        }
    }
}