using Domain.Core.Contracts;
using Domain.Core.Enums;
using System;

namespace Domain.Core.Base
{
    public abstract class BaseUseCase
    {
        protected readonly IDBRepository _repo;
        protected readonly IIdentityProviderService _identityService;



        public BaseUseCase(IServiceProvider serviceProvider)
        {
            _repo = serviceProvider.GetRequiredService<IDBRepository>();
            _identityService = serviceProvider.GetRequiredService<IIdentityProviderService>();
        }

        protected BaseReturn handleReturn(object result, EnumReturnType returntype = EnumReturnType.SUCCESS)
        {
            return new BaseReturn(result, returntype);
        }
    }
}
