﻿using Bl.Interfaces;
using Domains;

namespace Bl.Services
{
    public class PaymentService : IBusinessLayer<TbPayment>
    {
        #region define DbContext
        private PaymentUserDbContext context;
        private readonly IUnitOfWork unitOfWork;
        public PaymentService(PaymentUserDbContext ctx, IUnitOfWork _unitOfWork)
        {
            context = ctx;
            unitOfWork = _unitOfWork;
        }
        #endregion

        #region Delete
        public bool Delete(int id)
        {
            try
            {

                var payment = GetById(id);
                payment.CurrentState = 0;
                unitOfWork.Commit(); //context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get All Payments
        public List<TbPayment> GetAll()
        {
            try
            {
                var lstPayments = context.TbPayments.Where(a => a.CurrentState == 1).ToList();
                return lstPayments;
            }
            catch
            {
                return new List<TbPayment>();
            }
        }
        #endregion

        #region Get Payment ById
        public TbPayment GetById(int id)
        {
            try
            {
                var ObjPayment = context.TbPayments.Where(a => a.PaymentId == id && a.CurrentState == 1).FirstOrDefault();
                return ObjPayment;
            }
            catch
            {
                return new TbPayment();
            }
        }
        #endregion

        #region Save
        public bool Save(TbPayment payment)
        {
            try
            {
                if (payment.PaymentId == 0)
                {
                    payment.CurrentState = 1;
                    context.TbPayments.Add(payment);
                }
                else
                {
                    context.Entry(payment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                unitOfWork.Commit(); //context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ProcessPayment
        public async Task<bool> ProcessPayment(int userId, decimal amount)
        {
            // Validate payment information
            bool isValid = ValidatePayment(userId, amount);
            if (!isValid)
            {
                return false;
            }

            try
            {
                // Authenticate payment method
                /*PaymentGateway gateway = new PaymentGateway();
                bool isAuthorized = await gateway.AuthorizePayment(userId, amount);
                if (!isAuthorized)
                {
                    return false;
                }

                // Process payment
                PaymentResult result = await gateway.ProcessPayment(userId, amount);
                if (result.Status != PaymentStatus.Successful)
                {
                    return false;
                }*/

                // Insert payment record into database
                var payment = new TbPayment
                {
                    UserId = userId,
                    Amount = amount,
                    Date = DateTime.UtcNow
                };
                await context.TbPayments.AddAsync(payment);
                unitOfWork.CommitAsync();//await _context.SaveChangesAsync();

                // Return true to indicate payment was successfully processed
                return true;
            }
            catch (Exception ex)
            {
                // Handle errors and exceptions
                // Log error information for troubleshooting purposes
                Console.WriteLine($"Payment processing error: {ex.Message}");
                return false;
            }
        }

        private bool ValidatePayment(int userId, decimal amount)
        {
            // TODO: Implement payment validation logic here
            // Check that user exists and has sufficient funds, and that amount is valid
            // Return true if payment is valid, false otherwise
            return true;
        }
        #endregion

        #region Hashed Function
        public bool Payments(TbPayment table)
        {
            throw new NotImplementedException();
        }

        public TbPayment AuthorizeUser(TbPayment table)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
