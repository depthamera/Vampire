using Depthamera.Vampire.Core.Events;
using Depthamera.Vampire.Gameplay;
using Depthamera.Vampire.Service;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Depthamera.Vampire.App
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();

            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            builder.RegisterMessageBroker<DamageReportEvent>(options);
            builder.RegisterMessageBroker<GameStateChangedEvent>(options);
            builder.RegisterMessageBroker<PlayerLifeCycleEvent>(options);

            builder.RegisterEntryPoint<GameLoop>();
        }
    }
}