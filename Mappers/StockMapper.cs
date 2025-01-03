﻿using Finshark_api.Dtos.Stock;
using Finshark_api.Models;

namespace Finshark_api.Mappers
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock stockModel) 
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Purchase = stockModel.Purchase,
                Comments = stockModel.Comments.Select( x => x.ToCommentDto() ).ToList()
            };
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                LastDiv = stockDto.LastDiv,
                Purchase = stockDto.Purchase,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,
            };
        }
    }
}
