using UnityEngine;
using System.IO;

public class PNGLoader : MonoBehaviour {

    public SpriteRenderer imageRenderer;

    public void LoadImage(string filePath) {
        if (File.Exists(filePath)) {
            byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2); // Create an empty texture

            if (texture.LoadImage(fileData)) { // Load the image data into the texture
                Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                if (imageRenderer != null) {
                    imageRenderer.sprite = newSprite;
                } else {
                    Debug.LogError("Question Image object not assigned in the Inspector!");
                }
            } else {
                Debug.LogError("Failed to load image from: " + filePath);
            }
        } else {
            Debug.LogError("File not found: " + filePath);
        }
    }
}