using VContainer;
using VContainer.Unity;

namespace Gameplay.Core
{
    public sealed class SettingsInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<Settings>(Lifetime.Singleton).AsSelf();
            builder.Register<SettingsScreenViewModel>(Lifetime.Singleton).AsSelf();
        }
    }
}