using R3;
using UnityEngine;

namespace Depthamera.Vampire.Core
{
    /// <summary>
    /// 플레이어, AI, 컷신 등 외부에서 이동 입력을 공급하는 인터페이스입니다.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// 현재 프레임의 이동 방향 벡터입니다. (Normalized 된 값을 권장)
        /// </summary>
        ReadOnlyReactiveProperty<Vector2> MoveDirection { get; }
    }
}