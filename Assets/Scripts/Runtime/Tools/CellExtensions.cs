using Game.Gameplay;

namespace Game.Tools
{
    public static class CellExtensions
    {
        public static bool IsNotEmpty(this ICell cell)
        {
            return !cell.IsEmpty;
        }
    }
}