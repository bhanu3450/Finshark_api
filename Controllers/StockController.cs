using Finshark_api.Dtos;
using Finshark_api.Mappers;
using Finshark_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finshark_api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocksModel = await _context.Stocks.ToListAsync()
                        
            var stocks = stocksModel.Select(s => s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _context.Stocks.FindAsync(id );

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public  async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stock = stockDto.ToStockFromCreateDTO();
           await _context.Stocks.AddAsync(stock);   
           await  _context.SaveChangesAsync();

            return CreatedAtAction( nameof(GetById), new { id = stock.Id}, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDto updateDto)
        {
            var stockModel = await _context.Stocks.FindAsync( id );
            
            if(stockModel == null)
            {
                return NotFound();
            }

            stockModel.Purchase = updateDto.Purchase;
            stockModel.Symbol = updateDto.Symbol;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.MarketCap = updateDto.MarketCap;
            stockModel.CompanyName = updateDto.CompanyName;

            await _context.SaveChangesAsync();

            return Ok(stockModel.ToStockDto());  
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            var stockModel = await _context
                .Stocks.FirstOrDefaultAsync( x=> x.Id == id);

            if(stockModel == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockModel);
             await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
