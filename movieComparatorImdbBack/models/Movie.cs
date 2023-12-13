using Microsoft.EntityFrameworkCore.Metadata.Internal;
using movieComparatorImdbBack.dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieComparatorImdbBack.models
{
    [Index(nameof(TmdbId),IsUnique=true)]
    [PrimaryKey(nameof(Id))]
    public class Movie
    {
        public Movie() { }
        public Movie(MovieImdbDto dto)
        {
            this.TmdbId = dto.Id;
            this.original_title = dto.original_title;
            this.title = dto.title;
            this.overview = dto.overview;
            this.poster_path = dto.poster_path;
            //this.votePosId = new List<int>();
            //this.voteNegId = new List<int>();
        }
        public int Id { get; set; }

        public int? TmdbId { get; set; } = null!;

        public string original_title { get; set; } = null!;

        public string title { get; set; } = null!;

        public string overview { get; set; } = null!;

        public string? poster_path { get; set; } = null!;
    }
}
