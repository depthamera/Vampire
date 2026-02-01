using UnityEngine;

namespace Depthamera.Vampire.Core.Events
{
    public readonly struct PlayerLifeCycleEvent
    {
        public readonly PlayerLifeCycleState State;
        public readonly Transform PlayerTransform;

        public PlayerLifeCycleEvent(PlayerLifeCycleState state, Transform playerTransform)
        {
            State = state;
            PlayerTransform = playerTransform;
        }
    }
}