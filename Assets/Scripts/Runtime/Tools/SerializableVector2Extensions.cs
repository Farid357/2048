using UnityEngine;

namespace Game.Tools
{
    public static class SerializableVector2Extensions
    {
        public static Vector2 ToUnity(this SerializableVector2 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        public static SerializableVector2 ToSerializable(this Vector2 vector)
        {
            return new SerializableVector2(vector.x, vector.y);
        }
    }
}