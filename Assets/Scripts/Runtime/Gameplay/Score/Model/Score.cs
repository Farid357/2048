using System;

namespace Game.Gameplay
{
    public class Score : IScore
    {
        private readonly IScoreView _view;

        public Score(IScoreView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public int Count { get; private set; }
        
        public void Add(int count)
        {
            Count += count;
            _view.Show(Count);
        }
    }
}