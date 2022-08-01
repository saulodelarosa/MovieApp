﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(256)")]
        public string Title { get; set; }

        public string Overview { get; set; }

        [Column(TypeName = "Varchar(512)")]
        public string Tagline { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Revenue { get; set; }

        [Column(TypeName = "Varchar(2084)")]
        public string ImdbUrl { get; set; }

        [Column(TypeName = "Varchar(2084)")]
        public string TmdbUrl { get; set; }

        [Column(TypeName = "Varchar(2084)")]
        public string PosterUrl { get; set; }

        [Column(TypeName = "Varchar(2084)")]
        public string BackdropUrl { get; set; }

        [Column(TypeName = "Varchar(64)")]
        public string OriginalLanguage { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime ReleaseDate { get; set; }

        public int RunTime { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string CreatedBy { get; set; }
    }
}
