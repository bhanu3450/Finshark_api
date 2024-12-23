using Finshark_api.Dtos;
using Finshark_api.Models;

namespace Finshark_api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                Name = commentModel.Name,
                StockId = commentModel.StockId,                
            };
        }

        public static Comment CreateCommentToComment(this CreateCommentDto commentDto, int stockId) 
        {
            return new Comment
            {
                Name = commentDto.Name,
                Content = commentDto.Content,
                StockId = stockId,
            };
        }

        public static Comment ToCommentFromUpdate(this UpdateCommentDto commentDto)
        {
            return new Comment
            {
                Name = commentDto.Name,
                Content = commentDto.Content,
            };
        }
    }
}
