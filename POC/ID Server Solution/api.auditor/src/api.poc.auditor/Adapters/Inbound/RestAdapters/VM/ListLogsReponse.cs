using Domain.Core.Models.Entities;

namespace Adapters.Inbound.RestAdapters.VM
{
    public record ListLogsReponse
    {

        public List<LogTransaction> Logs { get; set; }
    }
}
