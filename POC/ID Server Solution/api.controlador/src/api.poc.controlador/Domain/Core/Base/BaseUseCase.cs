using Domain.Core.Enums;
using Domain.Core.Ports.Outbound;

namespace Domain.Core.Base
{
    public abstract class BaseUseCase
    {
        protected readonly IDBRepositoryPort _repo;
        protected readonly IIdentityServerServicePort _identityService;



        public BaseUseCase(IServiceProvider serviceProvider)
        {
            _repo = serviceProvider.GetRequiredService<IDBRepositoryPort>();
            _identityService = serviceProvider.GetRequiredService<IIdentityServerServicePort>();
        }

        protected BaseReturn handleReturn(object result, EnumReturnType returntype = EnumReturnType.SUCCESS)
        {
            return new BaseReturn(result, returntype);
        }
    }
}
