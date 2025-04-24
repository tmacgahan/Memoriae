using UnityEngine;
using System.IO;

public class LessonLoader : MonoBehaviour {

    public SpriteRenderer imageRenderer;
    public string lessonModule = "Potatoes/";
    private readonly string lessonDirectory = "Assets/LessonModules/
    private readonly string lessonFileName = "lesson.json";
    private string lessonPath = lessonDirectory + lessonModule + lessonFile;

    public Lesson LoadLesson() {
        if( !Directory.Exists(lessonDirectory) ) {
            Errors.HaltAndCatchFire("Lessons folder not found: " + lessonPath);
        }

        if( !Directory.Exists(lessonDirectory + lessonModule) ) {
            Errors.HaltAndCatchFire("Module folder not found: " + lessonPath + lessonModule);
        }

        if( !File.Exists(lessonPath) ) {
            Errors.HaltAndCatchFire("Lesson json not found: " + lessonPath);
        }

        string jsonData = File.ReadAllText(lessonDirectory);

        // validation

        Lesson lesson = JsonUtility.FromJson<Lesson>(jsonData);

        // validation

        return Lesson;
    }