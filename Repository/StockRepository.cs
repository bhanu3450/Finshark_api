using Finshark_api.Data;
using Finshark_api.Dtos;
using Finshark_api.Interfaces;
using Finshark_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Finshark_api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x=> x.Id == id); // first or default returns null
            
            if (stock == null) {return null;}

            _context.Stocks.Remove(stock);
            _context.SaveChangesAsync();

            return stock;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
           return await _context.Stocks.Include(c => c.Comments).ToListAsync();

        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c=> c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> StockExists(int id)
        {
            return await _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateDto updateDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x=> x.Id == id);

            if (existingStock == null) 
            { 
                return null;
            }

            existingStock.Purchase = updateDto.Purchase;
            existingStock.Symbol = updateDto.Symbol;
            existingStock.Purchase = updateDto.Purchase;
            existingStock.LastDiv = updateDto.LastDiv;
            existingStock.MarketCap = updateDto.MarketCap;
            existingStock.CompanyName = updateDto.CompanyName;
           
            await _context.SaveChangesAsync();

            return existingStock;

        }
    }
}
