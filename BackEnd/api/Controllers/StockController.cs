using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/Stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _repo;
        public StockController(ApplicationDBContext context, IStockRepository repository)
        {
            _context = context;
            _repo = repository;
        }

        [HttpGet("GetAllStocks")]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _repo.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockResponseDto());
            return Ok(stockDto);
        }

        [HttpGet("GetStockById/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _repo.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockResponseDto());
        }

        [HttpPost("CreateStock")]
        public async Task<IActionResult> CreateStock([FromBody] StockCreateRequest create)
        {
            var stockModel =  create.ToStockFromCreateRequest();
            await _repo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockResponseDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateStockById([FromRoute] int id, [FromBody] StockUpdateRequest updateRequest)
        {
            var stockModel = await _repo.UpdateAsync(id, updateRequest);
            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockResponseDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStockById([FromRoute] int id)
        {
            var stockModel =await  _repo.DeleteAsync(id);
            if(stockModel == null)
            {
                return NotFound();
            }
           return NoContent();
        }

    }
}