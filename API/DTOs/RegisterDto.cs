using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]  // Annotation to plyu validation on padyload fields
    public required string Username { get; set; }
    public required string Password { get; set; }
}