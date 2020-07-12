using System;
namespace Application.Interface
{
    public interface ICaptchaApplication
    {
        string GenerateRandomText(int v);
        string ComputeMd5Hash(string randomText);
        byte[] GenerateCaptchaImage(string randomText);
    }
}
