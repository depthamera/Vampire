using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Depthamera.Vampire.Core;
using Depthamera.Vampire.Core.Events;
using MessagePipe;
using UnityEngine;
using VContainer.Unity;

namespace Depthamera.Vampire.Gameplay
{
    public class GameLoop : IAsyncStartable
    {
        private readonly IPublisher<GameStateChangedEvent> _statePublisher;

        public GameLoop(IPublisher<GameStateChangedEvent> statePublisher)
        {
            _statePublisher = statePublisher;
        }


        /// <summary>
        /// 임시적으로 임의의 시간만큼 대기하기로 만들었습니다.
        /// 추후 각 기능들이 구현되고 나면, 해당 기능들에 대해 초기화를 대기하도록 만들 예정입니다.
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            Debug.Log("Initializing game loop");
            _statePublisher.Publish(new GameStateChangedEvent(GameState.Initializing));

            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: cancellationToken);

            Debug.Log("Playing game loop");
            _statePublisher.Publish(new GameStateChangedEvent(GameState.Playing));
        }
    }
}