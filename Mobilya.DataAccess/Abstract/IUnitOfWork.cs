using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public  interface IUnitOfWork:IDisposable
    {
        ICategory category { get; }
        IProduct product { get; }
        IAdmin admin { get; }
        IOrder order { get; }
        IPayment payment { get; }
        IUsers users { get; }


        Task<int> CommitAsync();
    }
}
