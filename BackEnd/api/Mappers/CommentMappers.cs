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

        public static Comment ToCommentFromCreate(this CreateCommentDto createCommentdto, int stockId)
        {
            return new Comment
            {
                Title = createCommentdto.Title, 
                Content = createCommentdto.Content, 
                StockId = stockId
            };
        }

        public static Comment ToCommentFromUpdateRequest(this CommentUpdateRequest UpdateRequest, Comment existingComment)
        {
            existingComment.Title = UpdateRequest.Title;
            existingComment.Content = UpdateRequest.Content;
            existingComment.CreatedDate = UpdateRequest.CreatedOn;

            return existingComment;
        }
    }
}