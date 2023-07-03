namespace Game.Gameplay
{
    public interface IFieldRollback : IField
    {
        bool CanRollback { get; }
        
        void Rollback();
    }
}