using Mobilya.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private MobilyaDBContext _mobilyaDBContext;
        private CategoryRepository categoryRepository;
        private ProductRepository productRepository;
        private AdminRepository adminRepository;
        private OrderRepository orderRepository;
        private PaymentRepository paymentRepository;
        private UsersRepository usersRepository;

        public UnitOfWork(MobilyaDBContext mobilyaDBContext)
        {
            _mobilyaDBContext = mobilyaDBContext;
        }

        public ICategory category => categoryRepository = categoryRepository ?? new CategoryRepository(_mobilyaDBContext);
        public IProduct product => productRepository = productRepository ?? new ProductRepository(_mobilyaDBContext);
        public IAdmin admin => adminRepository = adminRepository ?? new AdminRepository(_mobilyaDBContext);
        public IOrder order => orderRepository= orderRepository?? new OrderRepository(_mobilyaDBContext);
        public IPayment payment  => paymentRepository= paymentRepository?? new PaymentRepository(_mobilyaDBContext);

        public IUsers users => usersRepository = usersRepository ?? new UsersRepository(_mobilyaDBContext);

        public async Task<int> CommitAsync()
        {
            return await _mobilyaDBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _mobilyaDBContext.Dispose();
        }
    }
}
