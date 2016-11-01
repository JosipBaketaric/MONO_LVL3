using LVL3.Repository.Common;

namespace LVL3.Repository
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IUnitOfWork UnitOfWork;

        public UnitOfWorkFactory(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return this.UnitOfWork;
        }
    }
}
