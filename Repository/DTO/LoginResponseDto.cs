namespace Repository.DTO;

public class LoginResponseDto
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public string? Avatar { get; set; }
}