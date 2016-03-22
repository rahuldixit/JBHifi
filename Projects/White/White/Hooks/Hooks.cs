using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using White.Steps;

namespace White.Hooks
{
    [Binding]
    class BeforeAfterTestRun
    {
        [AfterTestRun]
        public static void After()
        {
            WhiteSteps.application.Close();

        }
    }
}
