using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domains
{
    public class TbBankAccount
    {
        [Key]
        [ValidateNever]
        public int BankAccountId { get; set; }

        [ValidateNever]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Account number is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Account number must be between 6 and 20 characters.")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Bank name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Bank name must be between 2 and 50 characters.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Branch number is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Branch number must be between 2 and 20 characters.")]
        public string BranchNumber { get; set; }

        [Required]
        [Range(0.000000000001, 9999999999.99, ErrorMessage = "Balance must be between 0.000000000001 and 9999999999.99.")]
        public decimal Balance { get; set; }

        [Required]
        public int CurrentState { get; set; } = 1;

        public virtual TbUser User { get; set; }// one(User) to one(Bank Account)
        public virtual ICollection<TbPayment> Payments { get; set; } = new List<TbPayment>();

    }

}
