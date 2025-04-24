using UnityEngine;

public class GameManager : MonoBehaviour {
    public SpriteRenderer imageRenderer;
    private PNGLoader pngLoader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        pngLoader = gameObject.AddComponent<PNGLoader>();
        pngLoader.imageRenderer = imageRenderer;
        pngLoader.LoadRandomPNG();
    }

    // Update is called once per frame
    void Update() {
    }
}
