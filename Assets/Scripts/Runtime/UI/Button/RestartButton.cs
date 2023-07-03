using System;
using System.Collections.Generic;
using Game.Gameplay;
using Game.SceneManagement;
using SaveSystem;

namespace Game.UI
{
    public class RestartButton : IButton
    {
        private readonly ISaveStorage<Stack<FieldSnapshot>> _snapshotsStorage;
        private readonly IScene _scene;

        public RestartButton(ISaveStorage<Stack<FieldSnapshot>> snapshotsStorage, IScene scene)
        {
            _snapshotsStorage = snapshotsStorage ?? throw new ArgumentNullException(nameof(snapshotsStorage));
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
        }

        public void Press()
        {
            if(_snapshotsStorage.HasSave())
                _snapshotsStorage.DeleteSave();
            
            _scene.Load();
        }
    }
}