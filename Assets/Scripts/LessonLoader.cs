using UnityEngine;
using System.IO;
using ExternalModel;

public class LessonLoader {

    // refactor path stuff for configurability
    public static readonly string lessonDirectory = "Assets/LessonModules/";
    public static readonly string lessonFileName = "lesson.json";
    public static readonly string lessonModule = "Potatoes/";
    private static string lessonPath = lessonDirectory + lessonModule + lessonFileName;

    public static Lesson LoadLesson() {
        if( !Directory.Exists(lessonDirectory) ) {
            Errors.HaltAndCatchFire("Lessons folder not found: " + lessonPath);
        }

        if( !Directory.Exists(lessonDirectory + lessonModule) ) {
            Errors.HaltAndCatchFire("Module folder not found: " + lessonPath + lessonModule);
        }

        if( !File.Exists(lessonPath) ) {
            Errors.HaltAndCatchFire("Lesson json not found: " + lessonPath);
        }

        string jsonData = File.ReadAllText(lessonPath);

        // validation

        Lesson lesson = JsonUtility.FromJson<Lesson>(jsonData);

        // validation

        return lesson;
    }
}