using Bl.Interfaces;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Repositories
{
    public class PaymentRepository : IGenericRepository<TbPayment>
    {
        #region Dependency injection
        protected readonly PaymentUserDbContext context;
        public PaymentRepository(PaymentUserDbContext _context)
        {
            context = _context;
        }
        #endregion

        #region Add
        public void Add(TbPayment entity)
        {
            context.Set<TbPayment>().Add(entity);
        }
        #endregion

        #region Delete
        public void Delete(TbPayment entity)
        {
            context.Set<TbPayment>().Remove(entity);
        }
        #endregion

        #region Edit
        public void Edit(TbPayment entity)
        {
            context.Set<TbPayment>().Update(entity);
        }
        #endregion

        #region FindBy
        public IQueryable<TbPayment> FindBy(Expression<Func<TbPayment, bool>> predicate)
        {
            return context.Set<TbPayment>().Where(predicate);
        }
        #endregion

        #region GetAll
        public IQueryable<TbPayment> Get_All()
        {
            return context.Set<TbPayment>();
        }
        #endregion
    }
}
