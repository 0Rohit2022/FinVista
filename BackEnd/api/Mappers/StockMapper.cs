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
        public static StockDto ToStockDto(this Stock stockModels)
        {
            return new StockDto
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
    }
}