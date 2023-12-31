﻿using Domain.Core.Base;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.UseCases.ClientApplication.ListClientsApp;

namespace Domain.Core.Ports.Inbound
{
    public interface IUseCaseListClientsAppPort
    {
        Task<BaseReturn> ExecuteTransaction(TransactionListClients transaction);
    }
}
