namespace Depthamera.Vampire.Core.Events
{
    public readonly struct GameStateChangedEvent
    {
        public readonly GameState CurrentState;

        public GameStateChangedEvent(GameState currentState)
        {
            CurrentState = currentState;
        }
    }
}