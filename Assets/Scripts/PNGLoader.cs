using UnityEngine;
using System.IO;

public class PNGLoader : MonoBehaviour {

    public SpriteRenderer imageRenderer;
    public string lessonPath = "Assets/LessonModules/Potatoes/";

    public void LoadRandomPNG() {
        if (!Directory.Exists(lessonPath)) {
            Debug.LogError("PNG folder not found: " + lessonPath);
            return;
        }

        //string[] pngFiles = Directory.GetFiles(pngFolderPath, "*.png");

        /*
        if (pngFiles.Length > 0) {
            int randomIndex = Random.Range(0, pngFiles.Length);
            string selectedFilePath = pngFiles[randomIndex];  // for now we do it random
            LoadPNGFromFile(selectedFilePath);
        } else {
            Debug.LogWarning("No PNG files found in: " + pngFolderPath);
        }
        */
    }

    /*
    public void LoadPNGFromFile(string filePath) {
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
    */
}