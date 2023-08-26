using Moq;
using ShowCaseModel;
using ShowCaseModel.Models;

namespace ShowCaseViewModelUnitTests
{
    public class UnitTest1
    {
        public UnitTest1() 
        {
            SetupDbObjectMoq();
        }

        private void SetupDbObjectMoq()
        {
            ShowCaseInstance showcase = ShowCaseInstance.Instance;
            var dbObject = new Mock<IDbObject>();
            SetupMultiDbObjectMoq(dbObject);
            SetupSingleDbObjectMoq(dbObject);
            showcase.SetupDBObject(dbObject.Object);
        }

        private void SetupMultiDbObjectMoq(Mock<IDbObject> dbObject)
        {
            dbObject
                .Setup(x => x.SetEntries(It.IsAny<Dictionary<int, string>>()))
                .Returns(true);
            dbObject
                .Setup(x => x.GetEntries(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new Dictionary<int, string>
                {
                    {1, "A"},
                    {2, "B"},
                    {3, "C"},
                    {4, "D"},
                    {5, "E"},
                    {6, "F"}
                });
            dbObject
                .Setup(x => x.AddEntries(ref It.Ref<Dictionary<int, string>>.IsAny))
                .Returns(true);
            dbObject
                .Setup(x => x.GetAllEntries())
                .Returns(new Dictionary<int, string>
                {
                    {1, "A"},
                    {2, "B"},
                    {3, "C"},
                    {4, "D"},
                    {5, "E"},
                    {6, "F"}
                });
        }

        private void SetupSingleDbObjectMoq(Mock<IDbObject> dbObject)
        {
            dbObject
                .Setup(x => x.SetName(It.IsAny<string>()));
            dbObject
                .Setup(x => x.AddEntry(It.IsAny<string>()))
                .Returns(true);
                
        }

        [Fact]
        public void TestGetEntries()
        {
            ShowCaseInstance showCaseInstance = ShowCaseInstance.Instance;
            var data = showCaseInstance.getDBObject().GetEntries(1, 6);
            Assert.Equal("A", data[1]);
        }
    }
}