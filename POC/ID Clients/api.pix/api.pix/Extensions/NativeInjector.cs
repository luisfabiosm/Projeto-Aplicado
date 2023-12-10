
using Domain.Contracts;
using Domain.UseCases;

namespace Extensions
{
    public static class NativeInjector
    {

        public static IServiceCollection AddDomainAdapter(this IServiceCollection service)
        {

            service.AddScoped<IUseCaseConsultarChavePort, UseCaseConsultarChave>();
            service.AddScoped<IUseCaseRealizarPagamentoPort, UseCaseRealizarPagamento>();

            return service;
        }
    }
}
