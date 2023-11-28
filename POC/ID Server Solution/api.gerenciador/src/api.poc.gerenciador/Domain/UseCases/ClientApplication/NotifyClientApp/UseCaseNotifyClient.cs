﻿using Domain.Core.Base;
using Domain.Core.Ports.Inbound;
using Domain.Core.Ports.Outbound;
using Newtonsoft.Json;

namespace Domain.UseCases.ClientApplication.NotifyClientApp
{
    public class UseCaseNotifyClient : BaseUseCase,  IUseCaseNotifyClientPort
    {

        //mock de serviços d notificação
        private readonly INotifyServicePort _notifyService;
       
        public UseCaseNotifyClient(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _notifyService = serviceProvider.GetRequiredService<INotifyServicePort>();
        }

        public async Task<BaseReturn> ExecuteTransaction(TransactionNotifyClientApp transaction)
        {

            try
            {
                transaction.TransactionLog = await _repo.SaveLogTransaction(transaction.TransactionLog, transaction);

                var _retRealm = await _identityService.GetClientByClienId(transaction.Realm, transaction.ClientId);

                await _notifyService.SendEmail(transaction.Email,"ClientInfo",JsonConvert.SerializeObject(_retRealm));

                transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(_retRealm);
                transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.CONFIRMED;

                return handleReturn(_retRealm);
            }
            catch (Exception ex)
            {
                transaction.TransactionLog.tranresponseinfo = JsonConvert.SerializeObject(ex);
                transaction.TransactionLog.transtatus = Core.Enums.EnumStatusLog.PENDING;
                return handleReturn(ex);
            }
            finally
            {
                await _repo.UpdateLogTransaction(transaction);
            }

        }


    }
}
