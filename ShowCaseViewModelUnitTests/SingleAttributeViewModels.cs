using CommunityToolkit.Mvvm.Messaging;
using Moq;
using ShowCaseModel;
using ShowCaseModel.Models;
using ShowCaseViewModel;
using ShowCaseViewModel.Messages;

namespace ShowCaseViewModelUnitTests
{
    public class SingleAttributeViewModels
    {
        public Mock<IDbObject> mockIDbObject;

        public SingleAttributeViewModels() 
        {
            SetupDbObjectMoq();
        }

        private void SetupDbObjectMoq()
        {
            ShowCaseInstance showcase = ShowCaseInstance.Instance;
            if (mockIDbObject is null)
            {
                mockIDbObject = new Mock<IDbObject>();
            }
            else
            {
                mockIDbObject.Reset();
            }
            SetupMultiDbObjectMoq(mockIDbObject);
            SetupSingleDbObjectMoq(mockIDbObject);
            SetupGet(1, "A");
            showcase.SetupDBObject(mockIDbObject.Object);
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
            dbObject
                .Setup(x => x.DeleteEntry())
                .Returns(true);
            dbObject
                .SetupSequence(x => x.NextEntry())
                .Returns(true)
                .Returns(false);
            dbObject
                .SetupSequence(x => x.PrevEntry())
                .Returns(true)
                .Returns(false);
        }

        private void SetupGet(int x, string value)
        {
            mockIDbObject
                .SetupSequence(x => x.GetID())
                .Returns(x)
                .Returns(2);
            mockIDbObject 
                .SetupSequence(x => x.GetName())
                .Returns(value)
                .Returns("NewName");
        }

        [Fact]
        public void TestViewModelAddCommand()
        {
            SingleAttributeDatabaseViewModel viewModel = new SingleAttributeDatabaseViewModel();
            Assert.True(viewModel.AddCommand.CanExecute(null));
            Assert.Equal("A", viewModel.DbName);
            Assert.Equal(1, viewModel.DbId);
            bool testvalue = false;
            WeakReferenceMessenger.Default.Register<AddMessage>(this, (t,actual) => {
                testvalue = true; });
            viewModel.AddCommand.Execute(null);
            Assert.Equal("", viewModel.DbName);
            Assert.Equal(0, viewModel.DbId);
            Assert.True(testvalue);
        }

        [Fact]
        public void TestViewModelDeleteCommand() 
        {
            SingleAttributeDatabaseViewModel viewModel1 = new SingleAttributeDatabaseViewModel();
            Assert.True(viewModel1.DeleteCommand.CanExecute(null));
            Assert.Equal("A", viewModel1.DbName);
            Assert.Equal(1,viewModel1.DbId);
            bool testvalue = false;
            WeakReferenceMessenger.Default.Register<DeleteMessage>(this, (t, actual) => { testvalue = true; });
            viewModel1.DeleteCommand.Execute(null);
            Assert.Equal("NewName", viewModel1.DbName);
            Assert.Equal(2, viewModel1.DbId);
            Assert.True(testvalue);
        }
    }
}