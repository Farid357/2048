using System;
using Game.Gameplay;

namespace Game.UI
{
    public class RollbackButton : IButton
    {
        private readonly IFieldRollback _field;

        public RollbackButton(IFieldRollback field)
        {
            _field = field ?? throw new ArgumentNullException(nameof(field));
        }

        public void Press()
        {
            if (_field.CanRollback)
                _field.Rollback();
        }
    }
}