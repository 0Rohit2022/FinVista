using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 Characters")]
        public string Title{get; set;} = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage ="Content Length must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Content length cannot be over 280 Characters")]
        public string Content{get; set;} = string.Empty;
    }
}