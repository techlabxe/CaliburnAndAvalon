using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace AvalondockPlus
{
    public class AvalondockPlusBootstrapper : BootstrapperBase
    {
        private CompositionContainer m_Container;

        public AvalondockPlusBootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //DisplayRootViewFor<MainViewModel>();
            DisplayRootViewFor<IShell>();
        }
        protected override void Configure()
        {
            m_Container = new CompositionContainer(
                new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>())
                );
            CompositionBatch batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(m_Container);
            m_Container.Compose(batch);
        }
        protected override object GetInstance(Type service, string key)
        {
            var contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
            var exports = m_Container.GetExportedValues<object>(contract);
            if (exports.Any())
            {
                return exports.First();
            }
            throw new Exception($"Could not locate any instance of contract {contract}");
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return m_Container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
        }
    }
}
