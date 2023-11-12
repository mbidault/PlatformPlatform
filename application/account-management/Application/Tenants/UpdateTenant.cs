using PlatformPlatform.SharedKernel.ApplicationCore.Cqrs;

namespace PlatformPlatform.AccountManagement.Application.Tenants;

public sealed record UpdateTenantCommand : ICommand, ITenantValidation, IRequest<Result>
{
    [JsonIgnore] // Removes the Id from the API contract
    public TenantId Id { get; init; } = null!;

    public required string Name { get; init; }

    public string? Phone { get; init; }
}

[UsedImplicitly]
public sealed class UpdateTenantHandler : IRequestHandler<UpdateTenantCommand, Result>
{
    private readonly ITenantRepository _tenantRepository;

    public UpdateTenantHandler(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public async Task<Result> Handle(UpdateTenantCommand command, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(command.Id, cancellationToken);
        if (tenant is null) return Result.NotFound($"Tenant with id '{command.Id}' not found.");

        tenant.Update(command.Name, command.Phone);
        _tenantRepository.Update(tenant);
        return Result.Success();
    }
}

[UsedImplicitly]
public sealed class UpdateTenantValidator : TenantValidator<UpdateTenantCommand>
{
}