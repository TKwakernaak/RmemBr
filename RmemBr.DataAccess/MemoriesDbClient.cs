using LiteDB;
using RmemBR.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RmemBr.DataAccess
{
  public class MemoriesDbClient : LiteDBService<MemoryDO>, IMemoriesDbClient
  {

    public MemoriesDbClient()
    {
      var mapper = BsonMapper.Global;

      mapper.Entity<MemoryDO>()
           .Id(x => x.Id);
    }

    public override MemoryDO CreateItem(MemoryDO item)
    {
      item.Id = Guid.NewGuid().ToString(); 
      return base.CreateItem(item);
    }

    public override MemoryDO DeleteItemAsync(MemoryDO item)
    {
      var c = _collection.Delete(i => i.Id == item.Id);
      return c == 0 ? null : item;
    }

    public override MemoryDO UpdateItem(MemoryDO item)
    {
      return base.UpdateItem(item);
    }

    public override IEnumerable<MemoryDO> ReadAllItems()
    {
      return base.ReadAllItems();
    }

  }
}
