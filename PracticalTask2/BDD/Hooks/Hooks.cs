using PracticalTask2.Core.Configuration;
using PracticalTask2.Core.Driver;
using Reqnroll;

namespace PracticalTask2.BDD.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly DriverContext _context;

        public Hooks(DriverContext context)
        {
            _context = context;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _context.Driver = BrowserFactory.CreateDriver(FrameworkConfig.Browser);
            _context.Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _context.Driver.Quit();
        }
    }
}
