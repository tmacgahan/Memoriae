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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start() {
        pngLoader = gameObject.AddComponent<PNGLoader>();
        pngLoader.imageRenderer = imageRenderer;
        lesson = LessonLoader.LoadLesson();
        
        Debug.Log(string.Format("Lesson plan loaded: {0} / {1}", lesson.title, lesson.splash));
        foreach( Card card in lesson.cards ) {
            Debug.Log(string.Format("{0} / {1} / {2}", card.title, card.text, card.img));
        }

        StartLesson();
    }

    private void StartLesson() {
        Initialize();
    }

    private void Initialize() {
        currentLesson = -1;

        pngLoader.LoadImage(imgPath + lesson.splash);
        textController.SetTitleAndText(lesson.title, "");
        Debug.Log("splash set!");

        buttonController.SetContinueSlideMode(NextSlide);
    }

    public void NextSlide() {
        currentLesson++;
        if( currentLesson >= lesson.cards.Length ) {
            Debug.Log("done with lesson!");
            return;
        }

        Card card = lesson.cards[currentLesson];
        pngLoader.LoadImage(imgPath + card.img);
        textController.SetTitleAndText(card.title, card.text);

        if( currentLesson == lesson.cards.Length - 1 ) {
            buttonController.SetContinueSlideMode(Initialize);
        } else {
            buttonController.SetContinueSlideMode(NextSlide);
        }
    }
}