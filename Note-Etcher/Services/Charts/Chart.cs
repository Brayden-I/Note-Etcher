using System.Collections.Generic;

namespace Note_Etcher.Services.Charts;

public class Chart
{
    public int LaneCount { get; set; } = 4;
    public List<ChartRow> Rows { get; set; } = new();

    public Queue<ChartRow> ToPlaybackQueue()
    {
        var queue = new Queue<ChartRow>();
        foreach (var row in Rows)
            queue.Enqueue(row);
        return queue;
    }
}