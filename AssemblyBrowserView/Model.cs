using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoCollector;
using InfoCollector.Containers;

namespace AssemblyBrowserView
{
    public class Model
    {
        private AssemblyBrowser _browser;

        public Model()
        {
            _browser = new AssemblyBrowser();
        }

        public AssemblyResult GetResult(string filename)
        {
            return _browser.GetNamespaces(filename);
        }
    }
}
