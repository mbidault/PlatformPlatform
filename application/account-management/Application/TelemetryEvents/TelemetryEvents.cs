using PlatformPlatform.SharedKernel.ApplicationCore.TelemetryEvents;

namespace PlatformPlatform.AccountManagement.Application.TelemetryEvents;

/// This file contains all the telemetry events that are collected by the application. Telemetry events are important
/// to understand how the application is being used and collect valuable information for the business. Quality is
/// important, and keeping all the telemetry events in one place makes it easier to maintain high quality.
/// This particular includes the naming of the telemetry events (which should be in past tense) and the properties that
/// are collected with each telemetry event. Since missing or bad data cannot be fixed, it is important to have a good
/// data quality from the start.
public sealed class AccountRegistrationStarted()
    : TelemetryEvent(nameof(AccountRegistrationStarted));

public sealed class AccountRegistrationEmailConfirmed()
    : TelemetryEvent(nameof(AccountRegistrationEmailConfirmed));

public sealed class AccountRegistrationEmailConfirmationAttemptFailed(int retryCount)
    : TelemetryEvent(nameof(AccountRegistrationEmailConfirmationAttemptFailed), ("RetryCount", retryCount.ToString()));

public sealed class AccountRegistrationEmailConfirmedButBlocked(int retryCount)
    : TelemetryEvent(nameof(AccountRegistrationEmailConfirmedButBlocked), ("RetryCount", retryCount.ToString()));

public sealed class AccountRegistrationEmailConfirmedButExpired(int secondsFromCreation)
    : TelemetryEvent(nameof(AccountRegistrationEmailConfirmedButExpired),
        ("SecondsFromCreation", secondsFromCreation.ToString()));

public sealed class TenantCreated(TenantId tenantId, TenantState state, int registrationTimeInSeconds)
    : TelemetryEvent(nameof(TenantCreated), ("TenantId", tenantId), ("TenantState", state.ToString()),
        ("RegistrationTimeInSeconds", registrationTimeInSeconds.ToString()));

public sealed class TenantDeleted(TenantId tenantId, TenantState tenantState)
    : TelemetryEvent(nameof(TenantDeleted), ("TenantId", tenantId), ("TenantState", tenantState.ToString()));

public sealed class TenantUpdated(TenantId tenantId)
    : TelemetryEvent(nameof(TenantUpdated), ("TenantId", tenantId));

public sealed class UserCreated(TenantId tenantId)
    : TelemetryEvent(nameof(UserCreated), ("TenantId", tenantId));

public sealed class UserDeleted()
    : TelemetryEvent(nameof(UserDeleted));

public sealed class UserUpdated()
    : TelemetryEvent(nameof(UserUpdated));