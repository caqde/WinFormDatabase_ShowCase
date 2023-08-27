using ShowCaseModel.Models;

namespace ShowCaseModel
{
    public sealed class ShowCaseInstance
    {
        private static readonly Lazy<ShowCaseInstance> _Lazy = new(() => new ShowCaseInstance());
        public static ShowCaseInstance Instance => _Lazy.Value;

        private IDbObject? DBObject;

        private ShowCaseInstance()
        {
            
        }

        public void SetupDBObject(IDbObject dbObject)
        {
            DBObject = dbObject;
        }

        public IDbObject getDBObject()
        {
            if (DBObject is not null)
            {
                return DBObject;
            }
            else
            {
                DBObject = new DbObjectModel();
                return DBObject;
            }
        }
    }
}