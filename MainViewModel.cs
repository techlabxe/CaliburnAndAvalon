using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using Xceed.Wpf.AvalonDock;

namespace AvalondockPlus
{
    [Export(typeof(IShell))]
    public class MainViewModel : PropertyChangedBase, IShell
    {
        //[Import]
        //public IScreen DockContent { get; set; }
        public DockingManager dockManager { get; set; }

        public string Value { get { return "Hello,in ViewModel";  } }
    }
}
