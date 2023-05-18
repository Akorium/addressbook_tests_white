using NUnit.Framework;

namespace addressbook_tests_white
{
    public class TestBase
    {
        public ApplicationManager manager;

        [OneTimeSetUp]

        public void InitApplication()
        {
            manager = new ApplicationManager();
        }
        [OneTimeTearDown]
        public void TearDownApplication()
        {
            manager.Stop();
        }
    }
}
