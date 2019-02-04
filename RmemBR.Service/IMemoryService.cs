using RmemBr.Models;
using RmemBR.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RmemBR.Service
{
 public interface IMemoryService
  {
    Memory CreateMemory(Memory item);

    IEnumerable<MemoryDO> GetMemories();


  }
}
