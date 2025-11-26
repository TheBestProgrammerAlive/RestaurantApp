namespace Restaurant.Infrastructure.Options;

public sealed class JwtOptions
{
    public const string SectionName = "JwtSettings";
    public string? SecretKey { get; init; }
    public string? Secret { get; init; }
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}