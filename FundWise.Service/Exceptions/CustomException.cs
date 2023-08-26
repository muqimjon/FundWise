namespace FundWise.Service.Exceptions;

public class CustomException : Exception
{
    public CustomException(int statusCode, string message) : base(message) 
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; set; } = 403;
}