namespace PrimeDrive.Realizations.Domain.Tests.Extensions;

using DomainDrivenDesign.BuildingBlocks.Blocks;

internal static class DomainEventExtension
{
    internal static TEvent? GetEvent<TEvent>(this IReadOnlyCollection<IDomainEvent> events) where TEvent : IDomainEvent =>
        events.OfType<TEvent>().FirstOrDefault();
}
