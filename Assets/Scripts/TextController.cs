using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour {
    public TMP_Text title;
    public TMP_Text text;
    
    public void Start() {
        if( title == null || text == null ) {
            if( title == null ) {
                Debug.LogError( "Title not set!" );
            }

            if( text == null ) {
                Debug.LogError( "Text not set!" );
            }

            Errors.HaltAndCatchFire( "Required text tools not available." );
        }

        title.text = "Hello";
        text.text = "World!";
    }

}
