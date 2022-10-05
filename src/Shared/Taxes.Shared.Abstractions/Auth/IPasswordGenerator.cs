namespace Taxes.Shared.Abstractions.Auth
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(int lengthOfPassword, bool includeLowercase = true, bool includeUppercase = true, bool includeNumeric = true, bool includeSpecial = false, bool includeSpaces = false);
    }
}
