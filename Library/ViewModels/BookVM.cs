﻿using Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]        
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Author { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Descreption { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}