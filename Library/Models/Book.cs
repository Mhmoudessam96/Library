using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
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
        public DateTime AddedDate { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        

        public Book()
        {
            AddedDate = DateTime.Now;
        }
    }
}