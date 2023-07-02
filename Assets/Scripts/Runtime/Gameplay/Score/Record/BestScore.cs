using System;
using SaveSystem;

namespace Game.Gameplay
{
    public class BestScore : IBestScore
    {
        private readonly IScore _score;
        private readonly IBestScoreView _view;
        private readonly ISaveStorage<int> _recordStorage;
        
        public BestScore(IScore score, ISaveStorage<int> recordStorage, IBestScoreView view)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _recordStorage = recordStorage ?? throw new ArgumentNullException(nameof(recordStorage));

            Record = _recordStorage.HasSave() ? _recordStorage.Load() : 0;
            _view.Show(Record);
        }
        
        public int Record { get; private set; }

        public void Update(float deltaTime)
        {
            if (Record < _score.Count)
            {
                Record = _score.Count;
                _recordStorage.Save(Record);
                _view.Show(Record);
            }
        }
    }
}