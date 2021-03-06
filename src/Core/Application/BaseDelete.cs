﻿// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Domain;
using System;
using System.Threading.Tasks;

namespace com.github.olo42.ROM.Core.Application
{
  public class BaseDelete<T> : IDelete<T> where T : IIdentifiable, IDeletable
  {
    protected readonly IRepository<T> _repository;

    public BaseDelete(IRepository<T> repository)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public virtual async Task Execute(T input)
    {
      input.Deleted = true;
      await _repository.WriteAsync(input);
    }
  }
}
