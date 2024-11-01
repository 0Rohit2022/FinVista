using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepo = commentRepository;
            _stockRepo = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }
        [HttpGet("GetCommentById/{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var comment = await _commentRepo.GetByIdAsync(Id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("Create/{StockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int StockId, CreateCommentDto createCommentdto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _stockRepo.StockExists(StockId))
            {
                return BadRequest("Stock Does Not Exist");
            }
            
            var commentModel = createCommentdto.ToCommentFromCreate(StockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new {id  = commentModel}, commentModel.ToCommentDto());

        }
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int Id)
        {
            var commentModel = await _commentRepo.DeleteAsync(Id);
            if(commentModel == null)
            {
                return NotFound("Comment Does Not Exist");
            }
            return Ok(commentModel);
        }
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateStockById([FromRoute] int Id, [FromBody] CommentUpdateRequest updateRequest)
        {
            var commentModel = await _commentRepo.UpdateAsync(Id, updateRequest);
            if(commentModel == null)
            {
                return NotFound();
            }

            return Ok(commentModel.ToCommentDto());
        }
    }
}