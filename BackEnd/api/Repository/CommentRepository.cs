using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context )
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int Id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(s => s.Id == Id);
            if(commentModel == null)
            {
                return null;
            }
             _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
           return await _context.Comments.ToListAsync();
        }
        public async Task<Comment?> GetByIdAsync( int Id)
        {
           return await _context.Comments.FindAsync(Id);
        }
        public async Task<Comment?> UpdateAsync(int Id, CommentUpdateRequest updateRequest)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == Id);
            if(existingComment == null)
            {
                return null;
            }
            existingComment = updateRequest.ToCommentFromUpdateRequest(existingComment);
            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}