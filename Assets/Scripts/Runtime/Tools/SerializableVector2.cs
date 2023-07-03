using System;
using UnityEngine;

namespace Game.Tools
{
    [Serializable]
    public struct SerializableVector2
    {
        public SerializableVector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; private set; }
        
        public float Y { get; private set; }
    }
}