using System;

namespace Taxes.Shared.Infrastructure.Security.Encryption;

[AttributeUsage(AttributeTargets.Property)]
public class EncryptedAttribute : Attribute
{
}