﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using NodaTime;

namespace Notifo.Infrastructure.Scheduling.Implementation.TimerBased;

public interface ISchedulerStore<T>
{
    Task CompleteAsync(string id,
        CancellationToken ct = default);

    Task<bool> CompleteByKeyAsync(string key,
        CancellationToken ct = default);

    Task<bool> CompleteByKeyAsync(string key, string groupKey,
        CancellationToken ct = default);

    Task<SchedulerBatch<T>?> DequeueAsync(Instant time,
        CancellationToken ct = default);

    Task EnqueueAsync(string key, T job, Instant dueTime, int retryCount = 0,
        CancellationToken ct = default);

    Task EnqueueGroupedAsync(string key, string groupKey, T job, Instant dueTime, int retryCount = 0,
        CancellationToken ct = default);

    Task ResetDeadAsync(Instant oldTime, Instant next,
        CancellationToken ct = default);

    Task RetryAsync(string id, Instant next,
        CancellationToken ct = default);
}
