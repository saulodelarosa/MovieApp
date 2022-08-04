using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   
    public class Movie
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        [Column(TypeName ="varchar")]
        public string Title { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string? Overview { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(512)]
        public string? Tagline { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Budget { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Revenue { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(512)]
        public string? ImdbUrl { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(512)]
        public string? TmdbUrl { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(512)]
        public string? PosterUrl { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(512)]
        public string? BackdropUrl { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(64)]
        public string? OriginalLanguage { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal? Price { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(512)]
        public string? UpdatedBy { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(512)]
        public string? CreatedBy { get; set; }

     
        public List<Trailer> Trailers { get; set; }
        public List<MovieGenre> GernesOfMovie { get; set; }
        public List<MovieCast> MovieCast { get; set; }
        public List<MovieCrew> CrewesOfMovie { get; }
        public List<Review> ReviewOfMovie { get; set; }
        public List<Favorite> FavoriteOfMovie { get; set; }
        public List<Purchase> PurchaseOfMovie { get; set; }
    }
}
