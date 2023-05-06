using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Interfaces
{
    public interface  IBusinessLayer<t>
        {
            List<t> GetAll();
            t GetById(int id);
            bool Save(t table);
            bool Delete(int id);
            bool Payments(t table);
            t AuthorizeUser(t table);
        
    }
}
