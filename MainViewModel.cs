using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using Xceed.Wpf.AvalonDock;
using System.Diagnostics;

namespace AvalondockPlus
{
    [Export(typeof(IShell))]
    public class MainViewModel : PropertyChangedBase, IShell
    {
        //[Import]
        //public IScreen DockContent { get; set; }

        public string Value { get { return "Hello,in ViewModel";  } }

        public void hoge(string val)
        {
            int bp = 0;
        }

        public void Load(object v)
        {
            int bp = 0;
        }
        public void Load(DockingManager dockManager)
        {
            Debug.WriteLine($"Loaded. {dockManager} in ViewModel");
        }
        public void Unload(DockingManager dockManager)
        {
            Debug.WriteLine($"Unloaded.{dockManager} in ViewModel");
        }

        public void CallTest(DockingManager dockMgr)
        {
            Debug.WriteLine("aaa");
        }
    }
}
