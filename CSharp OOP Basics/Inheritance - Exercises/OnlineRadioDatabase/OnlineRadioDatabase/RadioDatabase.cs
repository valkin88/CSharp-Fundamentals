using System;
using System.Collections.Generic;
using System.Linq;

public class RadioDatabase
{
    private long numberOfAddedSongs;
    private List<Song> songs;

    public RadioDatabase()
    {
        this.numberOfAddedSongs = 0;
        this.songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        this.songs.Add(song);
        this.numberOfAddedSongs++;
    }

    public override string ToString()
    {
        double totalSeconds = songs.Sum(s => s.Seconds) % 60;
        double totalMinutes = (songs.Sum(m => m.Minutes) + (songs.Sum(s => s.Seconds) / 60)) % 60;
        double totalHours = (songs.Sum(m => m.Minutes) + (songs.Sum(s => s.Seconds) / 60)) / 60;

        return $"Songs added: {this.numberOfAddedSongs}{Environment.NewLine}" +
            $"Playlist length: {totalHours}h {totalMinutes}m {totalSeconds}s";
    }
}
