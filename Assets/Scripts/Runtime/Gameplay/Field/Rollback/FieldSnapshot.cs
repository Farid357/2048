using System;
using System.Collections.Generic;
using Game.Tools;

namespace Game.Gameplay
{
    [Serializable]
    public struct FieldSnapshot
    {
        public FieldSnapshot(Dictionary<SerializableVector2, int> cells)
        {
            Cells = cells ?? throw new ArgumentNullException(nameof(cells));
        }

        public Dictionary<SerializableVector2, int> Cells { get; }
    }
}