using RmemBR.Data;
using System.Collections.Generic;

namespace RmemBr.DataAccess
{
  public interface IMemoriesDbClient
  {
    MemoryDO CreateItem(MemoryDO item);

    MemoryDO DeleteItemAsync(MemoryDO item);

    MemoryDO UpdateItem(MemoryDO item);

    IEnumerable<MemoryDO> ReadAllItems();
  }
}