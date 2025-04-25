using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour {
    public TMP_Text title;
    public TMP_Text text;
    
    public void Awake() {
        if( title == null || text == null ) {
            if( title == null ) {
                Debug.LogError( "Title not set!" );
            }

            if( text == null ) {
                Debug.LogError( "Text not set!" );
            }

            Errors.HaltAndCatchFire( "Required text tools not available." );
        }
    }

    public void SetTitleAndText( string setTitle, string setText ) {
        title.text = setTitle;
        text.text = setText;
    }

}
