using System.Collections.Generic;

namespace Note_Etcher.Services.Charts;

public class Chart
{
    public int LaneCount { get; set; } = 4;
    public List<ChartRow> Rows { get; set; } = new();
}