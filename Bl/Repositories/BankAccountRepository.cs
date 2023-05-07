using System;
using System.Collections.Generic;
using System.Linq;
using Bl.Interfaces;
using Domains;
using System.Linq.Expressions;

namespace Bl.Repositories
{
    public class BankAccountRepository : IGenericRepository<TbBankAccount>
    {
        #region Dependency injection
        protected readonly PaymentUserDbContext context;
        public BankAccountRepository(PaymentUserDbContext _context)
        {
            context = _context;
        }
        #endregion

        #region Add
        public void Add(TbBankAccount entity)
        {
            context.Set<TbBankAccount>().Add(entity);
        }
        #endregion

        #region Delete
        public void Delete(TbBankAccount entity)
        {
            context.Set<TbBankAccount>().Remove(entity);
        }
        #endregion

        #region Edit
        public void Edit(TbBankAccount entity)
        {
            context.Set<TbBankAccount>().Update(entity);
        }
        #endregion

        #region FindBy
        public IQueryable<TbBankAccount> FindBy(Expression<Func<TbBankAccount, bool>> predicate)
        {
            return context.Set<TbBankAccount>().Where(predicate);
        }
        #endregion

        #region GetAll
        public IQueryable<TbBankAccount> Get_All()
        {
            return context.Set<TbBankAccount>();
        }
        #endregion
    }
}
