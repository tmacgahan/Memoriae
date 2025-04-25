namespace ExternalModel {

    [System.Serializable]
    public class Lesson {
        public string title;
        public string splash;

        public Card[] cards;
        public Association[] associations;
        public QuizQuestion[] questions;
    }
}