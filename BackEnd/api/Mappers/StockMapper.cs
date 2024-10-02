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
        public static StockResponseDto  ToStockResponseDto(this Stock stockModels)
        {
            return new StockResponseDto 
            {
                Id = stockModels.Id,
                Symbol = stockModels.Symbol,
                CompanyName = stockModels.CompanyName,
                Purchase = stockModels.Purchase,
                LastDiv = stockModels.LastDiv,
                Industry = stockModels.Industry,
                MarketCap = stockModels.MarketCap
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
    }
}