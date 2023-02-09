using Desafio_backend.Domain.Common;
using System.Threading.Tasks;

namespace Desafio_backend.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
