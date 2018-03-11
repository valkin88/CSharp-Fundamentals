using System;

public class Song
{
    private string artist;
    private string songName;
    private int minutes;
    private int seconds;

    public string Artist
    {
        get { return this.artist; }
        private set
        {
            if (value == null || value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            this.artist = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        private set
        {
            if (value == null || value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }
            this.songName = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        private set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get { return this.seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            this.seconds = value;
        }
    }

    public Song(string artist, string songName, int minutes, int seconds)
    {
        this.Artist = artist;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }
}
