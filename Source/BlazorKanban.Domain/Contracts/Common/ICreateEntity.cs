﻿using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.Common
{
    public interface ICreateEntity<T> : IBaseCreateEntity
    {
        public Task<string> CreateAsync(T entity, CancellationToken cancellationToken);
    }
}