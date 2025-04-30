using System;

namespace ExternalModel {
    [System.Serializable]
    public class AssocStats {
        private string key;
        private int numberCorrect;
        private int numberIncorrect;
        private int correctSinceLastIncorrect;
        private DateTime showCardTime;

        public static readonly int BASE_SECONDS = 60 * 30; // thirty minutes

        public AssocStats() {
            numberCorrect = 0;
            numberIncorrect = 0;
            correctSinceLastIncorrect = 0;
            showCardTime = DateTime.UtcNow;
        }

        public void RecordCorrect() {
            numberCorrect++;
            correctSinceLastIncorrect++;
            RecalculateTime(correctSinceLastIncorrect);
        }

        public void RecordIncorrect() {
            correctSinceLastIncorrect = 0;
            numberIncorrect++;
            RecalculateTime(0);
        }

        private void RecalculateTime( int multiplier ) {
            showCardTime.AddSeconds(multiplier * BASE_SECONDS );
        }
    }
}