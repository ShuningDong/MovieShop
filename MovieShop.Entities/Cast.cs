﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Entities
{
    [Table("Cast")]
    public class Cast
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        public string Gender { get; set; }

        public string TmdbUrl { get; set; }

        [StringLength(2084)]
        public string ProfilePath { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
