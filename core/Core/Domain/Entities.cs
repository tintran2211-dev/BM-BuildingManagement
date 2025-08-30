using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Domain
{
    ///Entities are the core of the domain model, representing the main objects in the system.
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }

    }

    ///Aggregate Roots are special entities that encapsulate a cluster of related entities and value objects.
    public interface IAggregateRoot : IEntity
    {
        public HashSet<IDomainEvent> DomainEvents { get; }
    }

    /// Domain events are used to notify other parts of the system about changes in the state of an aggregate root.
    public interface ITxRequest { }

    // EntityRootBase is the base class for aggregate roots, providing a collection for domain events.
    public abstract class EntityRootBase : EntityBase, IAggregateRoot
    {
        [JsonIgnore]
        public HashSet<IDomainEvent>? DomainEvents { get; private set; }
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            DomainEvents ??= new HashSet<IDomainEvent>();
            DomainEvents.Add(domainEvent);
        }
        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            if (DomainEvents != null)
            {
                DomainEvents.Remove(domainEvent);
            }
        }
    }

    public abstract class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
    }

    public interface IClientScoped
    {
       Guid ClientId { get; set; }
    }

    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left?.Equals(right) != false;
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }

    public static class AggregateRootExtensions
    {
        public static async Task RelayAndPublishEvents(
            this IAggregateRoot aggregateRoot,
            IPublisher publisher,
            CancellationToken cancellationToken = default
        )
        {
            if (aggregateRoot.DomainEvents is not null)
            {
                var @events = new IDomainEvent[aggregateRoot.DomainEvents.Count];
                aggregateRoot.DomainEvents.CopyTo(@events);
                aggregateRoot.DomainEvents.Clear();

                foreach (var @event in @events)
                {
                    await publisher.Publish(new EventWrapper(@event), cancellationToken);
                }
            }
        }
    }
}
