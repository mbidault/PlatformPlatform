using Microsoft.EntityFrameworkCore;
using PlatformPlatform.SharedKernel.InfrastructureCore.Persistence;

namespace PlatformPlatform.AccountManagement.Infrastructure.Users;

[UsedImplicitly]
internal sealed class UserRepository(AccountManagementDbContext accountManagementDbContext)
    : RepositoryBase<User, UserId>(accountManagementDbContext), IUserRepository
{
    public async Task<bool> IsEmailFreeAsync(TenantId tenantId, string email, CancellationToken cancellationToken)
    {
        return !await DbSet.AnyAsync(u => u.TenantId == tenantId && u.Email == email, cancellationToken);
    }

    public Task<int> CountTenantUsersAsync(TenantId tenantId, CancellationToken cancellationToken)
    {
        return DbSet.CountAsync(u => u.TenantId == tenantId, cancellationToken);
    }
}