using UnityEngine;
using ExternalModel;

public class GameManager : MonoBehaviour {
    public SpriteRenderer imageRenderer;
    public TextController textController;
    public ButtonController buttonController;
    private PNGLoader pngLoader;
    private string imgPath = LessonLoader.lessonDirectory + LessonLoader.lessonModule;
    private Lesson lesson;
    private int currentLesson = -1;
    private SRSManager srsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start() {
        pngLoader = gameObject.AddComponent<PNGLoader>();
        pngLoader.imageRenderer = imageRenderer;
        lesson = LessonLoader.LoadLesson();

        
        Debug.Log(string.Format("Lesson plan loaded: {0} / {1}", lesson.title, lesson.splash));
        foreach( Card card in lesson.cards ) {
            Debug.Log(string.Format("{0} / {1} / {2}", card.title, card.text, card.img));
        }

        srsManager = new SRSManager(lesson);

        StartMenu();
    }

    private void StartMenu() {
        Debug.Log( "Starting up!" );
        pngLoader.LoadImage(imgPath + lesson.splash);
        textController.SetTitleAndText("", "");
        buttonController.SetAnswerCardMode(StartLesson, "Lesson", StartSRS, "SRS", StartQuiz, "Quiz");
    }

    private void StartLesson() {
        currentLesson = -1;

        pngLoader.LoadImage(imgPath + lesson.splash);
        textController.SetTitleAndText(lesson.title, "");
        Debug.Log("splash set!");

        buttonController.SetContinueSlideMode(NextSlide);
    }

    private void NextSlide() {
        currentLesson++;
        if( currentLesson >= lesson.cards.Length ) {
            Debug.Log("done with lesson!");
            return;
        }

        Card card = lesson.cards[currentLesson];
        pngLoader.LoadImage(imgPath + card.img);
        textController.SetTitleAndText(card.title, card.text);

        if( currentLesson == lesson.cards.Length - 1 ) {
            buttonController.SetContinueSlideMode(StartMenu);
        } else {
            buttonController.SetContinueSlideMode(NextSlide);
        }
    }

    private void StartSRS() {
        srsManager.Reset();
        NextSRS();
    }

    private void NextSRS() {
        Association assoc = srsManager.GetNextAssociation();
        if( assoc == null ) {
            StartMenu();
            return;
        }

        textController.SetTitleAndText("", assoc.front);
        buttonController.SetContinueSlideMode(() => SRSAnswer(assoc));
    }

    private void SRSAnswer(Association assoc) {
        textController.SetTitleAndText("", assoc.back);
        buttonController.SetMemoryCardMode(
            () => { Debug.Log("correct!"); srsManager.Correct(assoc); NextSRS(); },
            () => { Debug.Log("incorrect!"); srsManager.Incorrect(assoc); NextSRS(); }
        );
    }

    private void StartQuiz() {
    }
}