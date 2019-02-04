using RmemBR.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using RmemBR.Service;
using RmemBR.Data;
using System.Linq;

namespace RmemBR.Core.ViewModels
{
  public class History_ViewModel : ViewModelBase
  {

    private IMemoryService _memoryService;

    public History_ViewModel(IMemoryService memoryService)
    {
      _memoryService = memoryService;
    }


    public IList<Data.MemoryDO> Memories
    {
      get => GetAllMemories();
    }





    public override async Task InitializeAsync(object navigationData)
    {
      IsBusy = true;

      //initialize data here
      IsBusy = false;
    }

    public ICommand ButtonClickedCommand => new Command(OnButtonClicked);

    private void OnButtonClicked()
    {
      var items = _memoryService.GetMemories();

      _memoryService.CreateMemory(new RmemBr.Models.Memory());
    }

    public IList<MemoryDO> GetAllMemories()
    {
      return _memoryService.GetMemories().ToList();
    }
  }
}
