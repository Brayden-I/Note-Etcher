using System.Collections.Generic;
using Note_Etcher.Services.Charts.Notes;

namespace Note_Etcher.Services.Charts;

public class ChartRow
{
    public float Time { get; set; }                    // when this row triggers
    public List<NoteData> Notes { get; set; } = new(); // one per lane, null = empty
}