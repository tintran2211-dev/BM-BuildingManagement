using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public interface IDomainEvent : INotification
    {
        public DateTime CreatedAt { get; }
        IDictionary<string, object> MetaData { get; }
    }
    public interface IDomainEventContext
    {
        IEnumerable<IDomainEvent> GetDomainEvents();
    }

    public abstract class EventBase : IDomainEvent
    {
        public string EventType => GetType().FullName;
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public string CorrelationId { get; init; }
        public IDictionary<string, object> MetaData { get; } = new Dictionary<string, object>();

        public virtual void Flatten() { }
    }

    public class EventWrapper : INotification
    {
        public EventWrapper(IDomainEvent @event)
        {
            Event = @event;
        }

        public IDomainEvent Event { get; }
    }
}
