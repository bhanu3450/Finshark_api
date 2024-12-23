using System.ComponentModel.DataAnnotations;

namespace Finshark_api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters ")]
        [MaxLength(280, ErrorMessage = "Name can not be over 280 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be at least 5 characters ")]
        [MaxLength(280, ErrorMessage = "Content can not be over 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
