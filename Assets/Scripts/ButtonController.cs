using UnityEngine;
using UnityEngine.UI;
using TMPro;

public delegate void ButtonCallback();

public class ButtonController : MonoBehaviour {
    public Button fullScreen;
    public Button correct;
    public Button incorrect;
    public Button answer1;
    public Button answer2;
    public Button answer3;

    private ButtonCallback fullScreenCallback = () => {};
    private ButtonCallback correctCallback = () => {};
    private ButtonCallback incorrectCallback = () => {};
    private ButtonCallback answer1Callback = () => {};
    private ButtonCallback answer2Callback = () => {};
    private ButtonCallback answer3Callback = () => {};

    private Button[] all;
    
    public void Awake() {
        all = new[]{ fullScreen, correct, incorrect, answer1, answer2, answer3 };
        ResetButtons();
    }

    private void ResetButtons( params Button[] buttons ) {
        foreach( Button button in all ) { button.gameObject.SetActive(false); }
        foreach( Button button in buttons ) { button.gameObject.SetActive(true); }
    }
    public void SetContinueSlideMode(ButtonCallback setFullScreen) {
        // validate not null
        ResetButtons(fullScreen);
        fullScreenCallback = setFullScreen;
    }

    public void SetMemoryCardMode(ButtonCallback setCorrectCallback, ButtonCallback setIncorrectCallback) {
        ResetButtons(correct, incorrect);
        correctCallback = setCorrectCallback;
        incorrectCallback = setIncorrectCallback;
    }
    public void SetAnswerCardMode(ButtonCallback setAnswer1, string a1Text, ButtonCallback setAnswer2, string a2Text, ButtonCallback setAnswer3, string a3Text) {
        ResetButtons(answer1, answer2, answer3);
        answer1.GetComponentsInChildren<TMP_Text>()[0].text = a1Text;
        answer1Callback = setAnswer1;
        answer2.GetComponentsInChildren<TMP_Text>()[0].text = a2Text;
        answer2Callback = setAnswer2;
        answer3.GetComponentsInChildren<TMP_Text>()[0].text = a3Text;
        answer3Callback = setAnswer3;
    }

    public void OnFullScreenButtonClick() { Debug.Log("Fullscreen clicked!"); fullScreenCallback(); }
    public void OnCorrectButtonClick() { Debug.Log("Correct clicked!"); correctCallback(); }
    public void OnIncorrectButtonClick() { Debug.Log("Incorrect clicked!"); incorrectCallback(); }
    public void OnAnswer1Click() { Debug.Log("Answer1 clicked!"); answer1Callback(); }
    public void OnAnswer2Click() { Debug.Log("Answer2 clicked!"); answer2Callback(); }
    public void OnAnswer3Click() { Debug.Log("Answer3 clicked!"); answer3Callback(); }
}