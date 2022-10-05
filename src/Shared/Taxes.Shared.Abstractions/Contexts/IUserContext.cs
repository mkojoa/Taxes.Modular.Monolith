using System;


namespace Taxes.Shared.Abstractions.Contexts
{
    public interface IUserContext
    {
        public Guid Id { get; }
        public bool IsAvailable { get; }

        public Guid CompanyId { get; }
        public string CompanyName { get; }
        public string FullName { get; }

    }
}
