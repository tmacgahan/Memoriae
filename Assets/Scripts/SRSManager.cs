using ExternalModel;
using System.Collections.Generic;

public class SRSManager {
    private static readonly int DEFAULT_LESSON = 5; // default number of cards for a single lesson
    private Lesson lesson;
    private List<Association> batch;
    private Dictionary<Association,AssocStats> stats;
    public SRSManager(Lesson _lesson) {
        lesson = _lesson;
        LoadBatch();
        LoadStats();
    }

    private void LoadStats() {
    }

    private void LoadBatch() {
        List<Association> result = new List<Association>();

        // temporary naive implementation
        for( int ii = 0; ii < lesson.associations.Length && ii < DEFAULT_LESSON; ii++ ) {
            result.Add(lesson.associations[ii]);
            
        }

        batch = result;
    }

    public void Reset() { LoadBatch(); }
    public Association GetNextAssociation() {  // randomize!  actually do SRS things!
        if( batch.Count == 0 ) { return null; }

        // dequeue
        Association assoc = batch[0];
        batch.RemoveAt(0);

        return assoc;
    }

    public void Correct(Association assoc) {
        // todo: record correct
    }

    public void Incorrect(Association assoc) {
        // enqueue
        batch.Add(assoc);

        // todo: record incorrect
    }
}
