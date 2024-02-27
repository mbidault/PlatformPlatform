using PlatformPlatform.SharedKernel.DomainCore.DomainEvents;

namespace PlatformPlatform.AccountManagement.Domain.Tenants;

[UsedImplicitly]
public sealed record TenantCreatedEvent(TenantId TenantId, string Email, string FirstName, string LastName)
    : IDomainEvent;