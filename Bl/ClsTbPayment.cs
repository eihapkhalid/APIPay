﻿using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bl.IBusinessLayer;

namespace Bl
{
    public class ClsTbPayment : IBusinessLayer<TbPayment>
    {
        #region define DbContext
        PaymentUserDbContext context;
        public ClsTbPayment(PaymentUserDbContext ctx)
        {
            context = ctx;
        }
        #endregion

        #region Delete
        public bool Delete(int id)
        {
            try
            {

                var payment = GetById(id);
                payment.CurrentState = 0;
                context.SaveChanges();
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
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
