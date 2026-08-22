using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class PlayerMatchStatistics
    {
        private readonly List<string> _history = new();
        
        private readonly List<int> _throwValues = new();

        public double CurrentAverage => _throwValues.Count > 0 ? _throwValues.Average() : 0.0;
        public bool IsEmpty => _history.Count == 0;

        public void AddThrow(string scoreText, int scoreValue)
        {
            _history.Add(scoreText);
            _throwValues.Add(scoreValue);
        }

        public string? UndoLastThrow()
        {
            if (_history.Count == 0) return null;

            string lastScore = _history.Last();
            _history.RemoveAt(_history.Count - 1);

            if (_throwValues.Count > 0)
            {
                _throwValues.RemoveAt(_throwValues.Count - 1);
            }

            return lastScore;
        }

        public void Clear()
        {
            _history.Clear();
            _throwValues.Clear();
        }
    }
}