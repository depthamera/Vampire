using Depthamera.Vampire.Service;
using VContainer;
using VContainer.Unity;

namespace Depthamera.Vampire.App
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PlayerInputProvider>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}