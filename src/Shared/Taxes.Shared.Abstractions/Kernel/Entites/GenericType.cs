using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxes.Shared.Abstractions.Kernel.Entites
{
    public class GenericType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public bool IsCustomType { get; set; }
        public bool Status  { get; set; }


    }
}
