
namespace Application.Interfaces
{
    internal interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordHash, string inputPassword);
    }
}
