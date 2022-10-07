using System;
using Taxes.Shared.Abstractions.Kernel.Entites;

namespace Taxes.Modules.Tax.Core.Domain.Entities
{
    internal class LoanRule
    { 
        public Guid Id { get; set; }
        public Country Country { get; set; } 
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal StatutoryRate { get; set; }
        public decimal GearingRatio { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid UserId { get; set; } 


        public LoanRule()
        {}

        public LoanRule(
            Guid id , Country country , string code, string name , decimal statutoryRate ,
            decimal gearingRatio , DateTime startDate , bool status , 
            DateTime createdAt , Guid userId
        )
        {
            Id = id;
            Country = country;
            Code = code;
            Name = name;
            StatutoryRate = statutoryRate;
            GearingRatio= gearingRatio;
            StartDate = startDate;
            Status = status;
            CreatedAt = createdAt;
            UserId = userId;
        }

        internal static LoanRule CreateLoanRule (
            Guid id , Country country , string code, string name , decimal statutoryRate ,
            decimal gearingRatio , DateTime startDate , bool status , 
            DateTime createdAt , Guid userId
            ) 
        => new(
                 id ,  country ,  code,  name ,  statutoryRate ,
                 gearingRatio ,  startDate ,  status , 
                 createdAt ,  userId
            );
    }
}
