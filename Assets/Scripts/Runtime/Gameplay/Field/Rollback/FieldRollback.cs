using System;
using System.Collections.Generic;
using SaveSystem;
using UnityEngine;

namespace Game.Gameplay
{
    public class FieldRollback : IFieldRollback
    {
        private readonly IField _field;
        private readonly ISaveStorage<Stack<FieldSnapshot>> _snapshotsStorage;
        private readonly Stack<FieldSnapshot> _snapshots;
        
        public FieldRollback(IField field, ISaveStorage<Stack<FieldSnapshot>> snapshotsStorage)
        {
            _field = field ?? throw new ArgumentNullException(nameof(field));
            _snapshotsStorage = snapshotsStorage ?? throw new ArgumentNullException(nameof(snapshotsStorage));

            if (_snapshotsStorage.HasSave())
            {
                _snapshots = _snapshotsStorage.Load();
               
                if (_snapshots.Count > 0)
                    Load(_snapshots.Peek());
            }

            else
            {
                _snapshots = new Stack<FieldSnapshot>();
                Save();
            }
        }

        public bool CanRollback => _snapshots.Count > 1;
        
        public bool HasWinningTile => _field.HasWinningTile;

        public void MoveCells(Vector2Int direction)
        {
            _field.MoveCells(direction);
            Save();
        }

        public void Load(FieldSnapshot snapshot)
        {
            _field.Load(snapshot);
        }

        public FieldSnapshot Save()
        {
            FieldSnapshot snapshot = _field.Save();
            _snapshots.Push(snapshot);
            _snapshotsStorage.Save(_snapshots);
            return snapshot;
        }

        public void Rollback()
        {
            if (CanRollback == false)
                throw new InvalidOperationException($"Field can't rollback!");
            
            _snapshots.Pop();
            _snapshotsStorage.Save(_snapshots);
            Load(_snapshots.Peek());
        }
    }
}