using NetCore31Skeleton.Library.Repository;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.Repository
{
    public class TransactionRepository : GenericRepository<long, Transaction, CoreDbContext>, ITransactionRepository
    {
        public TransactionRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
