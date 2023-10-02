using ShowCaseModel.Models;

namespace ShowCaseModel
{
    public sealed class ShowCaseInstance
    {
        private static readonly Lazy<ShowCaseInstance> _Lazy = new(() => new ShowCaseInstance());
        public static ShowCaseInstance Instance => _Lazy.Value;

        private IDbObject? DBObject;
        private ILibrary? Library;

        private ShowCaseInstance()
        {
            
        }

        public void SetupDBObject(IDbObject dbObject)
        {
            DBObject = dbObject;
        }

        public void SetupLibrary(ILibrary library)
        {
            Library = library;
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

        public ILibrary getLibrary()
        {
            if (Library is not null)
            {
                return Library;
            }
            else
            {
                Library = new Library();
                return Library;
            }
        }
    }
}