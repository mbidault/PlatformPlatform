using NSubstitute;
using PlatformPlatform.AccountManagement.Application.Tenants.Queries;
using PlatformPlatform.AccountManagement.Domain.Tenants;

namespace PlatformPlatform.AccountManagement.Tests.Application.Tenants.Queries;

public class GetTenantByIdQueryTests
{
    [Fact]
    public async Task GetTenantByIdQuery_WhenTenantFound_ShouldReturnTenantResponseDto()
    {
        // Arrange
        var expectedTenantId = TenantId.NewId();
        var expectedTenantName = "TestTenant";

        var tenant = new Tenant {Id = expectedTenantId, Name = expectedTenantName};
        var tenantRepository = Substitute.For<ITenantRepository>();
        tenantRepository.GetByIdAsync(expectedTenantId, default).Returns(tenant);

        var query = new GetTenantByIdQuery(expectedTenantId);
        var handler = new GetTenantQueryHandler(tenantRepository);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(expectedTenantId.AsRawString());
        result.Name.Should().Be(expectedTenantName);
        await tenantRepository.Received().GetByIdAsync(expectedTenantId, default);
    }

    [Fact]
    public async Task GetTenantByIdQuery_WhenTenantNotFound_ShouldReturnNull()
    {
        // Arrange
        var nonExistingTenantId = new TenantId(999);

        var tenantRepository = Substitute.For<ITenantRepository>();
        tenantRepository.GetByIdAsync(nonExistingTenantId, default).Returns((Tenant?) null);

        var query = new GetTenantByIdQuery(nonExistingTenantId);
        var handler = new GetTenantQueryHandler(tenantRepository);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.Should().BeNull();
        await tenantRepository.Received().GetByIdAsync(nonExistingTenantId, default);
    }
}