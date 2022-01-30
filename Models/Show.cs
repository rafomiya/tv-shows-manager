using System;
using System.Collections.Generic;

namespace shows.Models
{
    public class Show
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Genre> Genres { get; set; }
        public string Synopsis { get; set; }
        public ushort Year { get; set; }
        public bool IsDeleted { get; set; }
        public Show(string title, Genre genre, string synopsis, ushort year)
        {
            Id = Guid.NewGuid();
            Title = title;
            Genres = new List<Genre>() { genre };
            Synopsis = synopsis;
            Year = year;
            IsDeleted = false;
        }
        public Show(string title, List<Genre> genres, string synopsis, ushort year)
        {
            Id = Guid.NewGuid();
            Title = title;
            Genres = genres;
            Synopsis = synopsis;
            Year = year;
            IsDeleted = false;
        }
        public Show(Guid id, string title, List<Genre> genres, string synopsis, ushort year)
        {
            Id = id;
            Title = title;
            Genres = genres;
            Synopsis = synopsis;
            Year = year;
            IsDeleted = false;
        }
        public override string ToString()
        {
            string description;

            description = $"Id: {Id}\n";
            description += $"Title: {Title}\n";
            description += $"Genre(s): {string.Join(", ", Genres)}\n";
            description += $"Synopsis: {Synopsis}\n";
            description += $"Year: {Year}\n";

            return description;
        }
    }
}