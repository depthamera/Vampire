using System;
using Depthamera.Vampire.Core;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Depthamera.Vampire.Service
{
    /// <summary>
    /// 플레이어의 입력을 통해 정보를 제공하는 구현체입니다.
    /// New InputSystem에서 플레이어의 입력을 받아옵니다.
    /// </summary>
    public class PlayerInputProvider : IInputProvider, IDisposable
    {
        private readonly DefaultActions _defaultActions;
        private readonly ReactiveProperty<Vector2> _moveDirection;

        public ReadOnlyReactiveProperty<Vector2> MoveDirection => _moveDirection;

        public PlayerInputProvider()
        {
            _defaultActions = new DefaultActions();
            _moveDirection = new ReactiveProperty<Vector2>(Vector2.zero);

            var moveAction = _defaultActions.Player.Move;

            // 연속으로 같은 값이 입력되는 경우에도 한 번만 값을 갱신하여 무의미한 함수 호출을 방지합니다.
            moveAction.performed += OnMovePerformed;
            moveAction.canceled += OnMoveCanceled;

            _defaultActions.Enable();
        }

        private void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            _moveDirection.Value = ctx.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext ctx)
        {
            _moveDirection.Value = Vector2.zero;
        }

        public void Dispose()
        {
            _defaultActions.Disable();

            var moveAction = _defaultActions.Player.Move;
            moveAction.performed -= OnMovePerformed;
            moveAction.canceled -= OnMoveCanceled;

            _defaultActions.Dispose();
            _moveDirection.Dispose();
        }
    }
}