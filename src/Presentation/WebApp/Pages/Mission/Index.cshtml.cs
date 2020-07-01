﻿// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Application;
using AutoMapper;

namespace com.github.olo42.ROM.Presentation.WebApp.Pages.Mission
{
  public class IndexModel : BaseIndexModel<Core.Domain.Mission, Core.Domain.Mission>
  {
    public IndexModel(IRead<Core.Domain.Mission> readAction, IMapper mapper) 
      : base(readAction, mapper)
    {
    }
  }
}