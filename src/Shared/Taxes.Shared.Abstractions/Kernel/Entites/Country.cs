using Taxes.Shared.Abstractions.Kernel.ValueObjects;

namespace Taxes.Shared.Abstractions.Kernel.Entites
{
    public class Country
    {
        public Code Code { get; set; }
        public Name Name { get; set; }
        public string Demonym { get; set; }

    }
}
