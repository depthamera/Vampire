using System;
using Depthamera.Vampire.Core;
using R3;
using UnityEngine;
using VContainer;

namespace Depthamera.Vampire.Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        private IInputProvider _inputProvider;

        [Inject]
        public void Build(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        private void Update()
        {
            Move(_inputProvider.MoveDirection.CurrentValue, 1f);
        }

        /// <summary>
        /// 부착된 오브젝트의 실제 이동을 담당합니다.
        /// 이동의 책임을 분리하기 위해서 방향이 없는 이동을 무시하고, 정규화되지 않은 값을 정제합니다.
        /// </summary>
        private void Move(Vector2 rawDirection, float speed)
        {
            if (rawDirection == Vector2.zero) return;

            Vector2 direction = Vector2.ClampMagnitude(rawDirection, 1f);

            transform.position += new Vector3(direction.x, 0, direction.y) * (Time.deltaTime * speed);
        }
    }
}