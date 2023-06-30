using UnityEngine;

namespace Game.Tools
{
    public static class Vector2IntExtensions
    {
        public static bool IsHorizontal(this Vector2Int vector)
        {
            return vector.x != 0;
        }
    }
}