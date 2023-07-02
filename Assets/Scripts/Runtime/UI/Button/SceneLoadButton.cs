using System;
using Game.SceneManagement;

namespace Game.UI
{
    public class SceneLoadButton : IButton
    {
        private readonly IScene _scene;

        public SceneLoadButton(IScene scene)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
        }

        public void Press()
        {
            _scene.Load();
        }
    }
}