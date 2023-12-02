using Domain.Core.Enums;
using Domain.Core.Ports.Outbound;

namespace Domain.Core.Base
{
    public abstract class BaseUseCase
    {
        protected readonly IDBRepositoryPort _repo;
  

        public BaseUseCase(IServiceProvider serviceProvider)
        {
            _repo = serviceProvider.GetRequiredService<IDBRepositoryPort>();

        }

        protected BaseReturn handleReturn(object result, EnumReturnType returntype = EnumReturnType.SUCCESS)
        {
            return new BaseReturn(result, returntype);
        }
    }
}
