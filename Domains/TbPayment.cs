using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class TbPayment
    {
        [Key]
        [ValidateNever]
        public int PaymentId { get; set; }

        [ValidateNever]
        public int UserId { get; set; }

        [ValidateNever]
        public int BankAccountId { get; set; }

        [Required(ErrorMessage = "Transaction number is required.")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Transaction Number must be between 10 and 20 characters.")]
        public string TransactionNumber { get; set; }

        [Required(ErrorMessage = "Payment date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.000000000001, 9999999999.99, ErrorMessage = "Balance must be between 0.000000000001 and 9999999999.99.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency code must be 3 characters.")]
        public string Currency { get; set; }

        public virtual TbUser User { get; set; }
        public virtual TbBankAccount BankAccount { get; set; } //one(Bank Account) to many(Payments)
    }

}
