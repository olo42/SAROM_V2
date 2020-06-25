
// Copyright (c) Oliver Appel. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using com.github.olo42.SAROnion.Core.Domain;

namespace com.github.olo42.SAROnion.Infrastructure.FileStorage
{
  public class LogTypeRepository : BaseRepository<LogType>
  {
    public LogTypeRepository(string directoryPath) : base(directoryPath) { }

    public override async Task<LogType> ReadAsync(string id)
    {
      var logTypes = await this.ReadAsync();

      return logTypes.ToList().Find(x => x.Id == id);
    }

    public override async Task WriteAsync(LogType input)
    {
      var logTypes = await AddOrUpdateAsync(input);
      var json = JsonSerializer.Serialize(logTypes);
      await File.WriteAllTextAsync(base.GetFilePath(), json);
    }

    private async Task<List<LogType>> AddOrUpdateAsync(LogType input)
    {
      var logTypes = (await this.ReadAsync()).ToList();
      var origin = logTypes.Find(x => x.Id == input.Id);

      if (origin == null)
        logTypes.Add(input);
      else
        this.Update(origin, input);

      return logTypes;
    }

    private void Update(LogType origin, LogType input)
    {
      origin.Name = input.Name;
    }
  }
}
