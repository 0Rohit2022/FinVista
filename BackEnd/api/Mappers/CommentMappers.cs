using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModels)
        {
            return new CommentDto
            {
                Id = commentModels.Id,
                Title = commentModels.Title, 
                Content = commentModels.Content,
                CreatedDate = commentModels.CreatedDate,
                StockId = commentModels.StockId
            };
        }
    }
}