using System;
using Game.Loop;

namespace Game.Gameplay
{
    public class Victory : IGameLoopObject
    {
        private readonly IReadOnlyField _field;
        private readonly IVictoryView _view;
       
        private bool _isActive;

        public Victory(IReadOnlyField field, IVictoryView view)
        {
            _field = field ?? throw new ArgumentNullException(nameof(field));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Update(float deltaTime)
        {
            if (_isActive)
                return;

            if (_field.HasWinningTile)
            {
                _view.ShowVictory();
                _isActive = true;
            }
        }
    }
}