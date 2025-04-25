using ExternalModel;

public class SRSManager {
    private Lesson lesson;
    private int currentAssoc = 0;
    public SRSManager(Lesson _lesson) { lesson = _lesson; }

    public void Reset() { currentAssoc = 0; }
    public Association GetNextAssociation() {  // randomize!  actually do SRS things!
        if( currentAssoc  >= lesson.associations.Length ) {
            return null;  //bad!
        }

        Association assoc = lesson.associations[currentAssoc];
        currentAssoc++;
        return assoc;
    }
}
