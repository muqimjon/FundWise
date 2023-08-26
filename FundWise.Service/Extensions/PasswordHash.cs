namespace FundWise.Service.Extensions;

public static class PasswordHash
{
    public static string Encrypt(this string password)
    {
        password = BCrypt.Net.BCrypt.HashPassword(password);
        return password;
    }

    public static bool Verify(this string hashedPassword, string password)
        => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
