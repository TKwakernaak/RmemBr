using RmemBr.DataAccess;
using RmemBR.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RmemBr.Models;

namespace RmemBR.Service
{
  public class MemoryService : IMemoryService
  {

    private IMemoriesDbClient _client;
    public MemoryService(IMemoriesDbClient memoriesDbClient)
    {
      _client = memoriesDbClient;
    }

    public Memory CreateMemory(Memory item)
    {
      MemoryDO item2 = new MemoryDO();
      item2.text = "FirstItem";


      var result = _client.CreateItem(item2);

      return item;
    }

    public IEnumerable<Memory> GetAllItems()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<MemoryDO> GetMemories()
    {
      var result = _client.ReadAllItems();
      return result;
    }
  }
}
