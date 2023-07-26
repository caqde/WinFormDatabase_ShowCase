using ShowCaseModel.Models;

namespace ShowCaseModel
{
    public class ShowCaseInstance
    {
        public static ShowCaseInstance Instance { get; } = new ShowCaseInstance();

        private dbObjectModel DBObject = new dbObjectModel();

        public dbObjectModel getDBObject()
        {
            return DBObject;
        }
    }
}