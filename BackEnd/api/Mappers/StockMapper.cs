using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockResponseDto ToStockResponseDto(this Stock stockModels)
        {
            return new StockResponseDto
            {
                Id = stockModels.Id,
                Symbol = stockModels.Symbol,
                CompanyName = stockModels.CompanyName,
                Purchase = stockModels.Purchase,
                LastDiv = stockModels.LastDiv,
                Industry = stockModels.Industry,
                MarketCap = stockModels.MarketCap,
                Comments = stockModels.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStockFromCreateRequest(this StockCreateRequest request)
        {
            return new Stock
            {
                Symbol = request.Symbol,
                CompanyName = request.CompanyName,
                Purchase = request.Purchase,
                LastDiv = request.LastDiv,
                Industry = request.Industry,
                MarketCap = request.MarketCap
            };
        }

        public static Stock ToStockFromUpdateRequest(this StockUpdateRequest updateRequest, Stock existingStock)
        {
            existingStock.Symbol = updateRequest.Symbol;
            existingStock.CompanyName = updateRequest.CompanyName;
            existingStock.Purchase = updateRequest.Purchase;
            existingStock.LastDiv = updateRequest.LastDiv;
            existingStock.Industry = updateRequest.Industry;
            existingStock.MarketCap = updateRequest.MarketCap;

            return existingStock;
        }

    }
}