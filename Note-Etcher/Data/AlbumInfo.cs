using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Note_Etcher.Data;

public class AlbumInfo
{
    [JsonPropertyName("Details")]
    public AlbumDetails Details { get; set; }
    
    public string FolderPath { get; set; } // not from JSON, set by AlbumLoader
}

public class AlbumDetails
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("Author")]
    public string Author { get; set; }
    [JsonPropertyName("Description")]
    public string Description { get; set; }
    [JsonPropertyName("Keywords")]
    public List<string> Keywords { get; set; }
    [JsonPropertyName("stages")]
    public List<Stage> Stages { get; set; }
}

public class Stage
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("Description")]
    public string Description { get; set; }
}