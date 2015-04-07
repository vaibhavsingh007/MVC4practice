using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Mvc4Architecture.Web
{
    public class UnityContainerFactory
    {
        public IUnityContainer CreateConfiguredContainer()
        {
            var container = new UnityContainer();
            LoadConfigurationOverrides(container);
            return container;
        }

        private static void LoadConfigurationOverrides(IUnityContainer container)
        {
            container.LoadConfiguration("container");
        }
    }
}