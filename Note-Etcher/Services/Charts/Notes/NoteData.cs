namespace Note_Etcher.Services.Charts.Notes;

public class NoteData
{
    public NoteDirection Direction { get; set; }
    public float TrailLength { get; set; } = 0f;      // hold note duration
    public int Repeats { get; set; } = 0;              // number of repeats
    public float RepeatSpacing { get; set; } = 0f;     // space between repeats
    public float InteractionTime { get; set; } = 0f;   // timing window
}