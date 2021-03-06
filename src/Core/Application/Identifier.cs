﻿// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using com.github.olo42.ROM.Core.Domain;

namespace com.github.olo42.ROM.Core.Application
{
  public class Identifier : IIdentifiable
  {
    private string _id;

    public Identifier(string id)
    {
      _id = Validate(id);
    }

    public string Id 
    {
      get { return _id;  }
      set { _id = Validate(value); } 
    }

    private static string Validate(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
        throw new System.ArgumentException("message", nameof(id));

      return id;
    }
  }
}
