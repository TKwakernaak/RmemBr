using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RmemBr.Common.Extensions;
using RmemBr.Models;
using RmemBR.Core.ViewModels.Base;
using Xamarin.Forms;

namespace RmemBR.Core.ViewModels
{
  public class Home_ViewModel : ViewModelBase
  {
    public ObservableCollection<ListViewGrouping<MemoryGroup>> AllModulesGrouped { get; }



    public Home_ViewModel()
    {
      var newListGrouping = new List<ListViewGrouping<MemoryGroup>>();

      var grouping = new ListViewGrouping<MemoryGroup>("Group 1", "Group2");

      var item1 = new MemoryGroup()
      {
        Name = "Books",
        Description = "Add your favorite books",
        ImageName = "todo.jpeg",       
        
      };
      var item2 = new MemoryGroup()
      {
        Name = "Movies",
        Description = "Add your favorite Movies",
        ImageName = "todo.jpeg"
      };
      var item3 = new MemoryGroup
      {
        Name = "Ideas",
        Description = "Add your favorite ideas",
        ImageName = "todo.jpeg"
      };


      grouping.Add(item1);
      grouping.Add(item2);
      grouping.Add(item3);

      newListGrouping.Add(grouping);

      AllModulesGrouped = newListGrouping.ToObservableCollection();
    }





    public ICommand ModuleTappedCommand => new Command<MemoryGroup>(OnMemoryGroupTapped);




    private void OnMemoryGroupTapped(MemoryGroup selectedModule)

    {   
    //  NavigationService.NavigateToAsync(selectedModule.MainViewModelType, selectedModule.Config);

    }

  }
}
  
