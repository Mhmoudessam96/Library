﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.ViewModels
{
    public class CategoryVM
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CatgName { get; set; }

        public bool IsActive { get; set; }
    }
}