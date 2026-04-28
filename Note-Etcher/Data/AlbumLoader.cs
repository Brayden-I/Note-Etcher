// Data/AlbumLoader.cs
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Note_Etcher.Data;

public static class AlbumLoader
{
    private const string AlbumsPath = "Data/Albums";

    public static List<AlbumInfo> LoadAll()
    {
        var albums = new List<AlbumInfo>();
        if (!Directory.Exists(AlbumsPath)) return albums;

        foreach (var albumDir in Directory.GetDirectories(AlbumsPath))
        {
            var infoPath = Path.Combine(albumDir, "info.json");
            if (!File.Exists(infoPath)) continue;

            var json = File.ReadAllText(infoPath);
            var album = JsonSerializer.Deserialize<AlbumInfo>(json);
            if (album != null)
            {
                album.FolderPath = albumDir;
                albums.Add(album);
            }
        }

        return albums;
    }
}