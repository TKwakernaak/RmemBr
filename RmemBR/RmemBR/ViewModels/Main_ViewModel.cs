using RmemBR.Core.Models.Navigation;
using RmemBR.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RmemBR.Core.ViewModels
{
  public class Main_ViewModel : ViewModelBase
  {

    public override Task InitializeAsync(object navigationData)
    {
      try
      {
        IsBusy = true;

        if (navigationData is TabParameter)
        {
          // Change selected application tab
          var tabIndex = ((TabParameter)navigationData);
          MessagingCenter.Send(this, MessageKeys.ChangeTab, tabIndex);
        }
        return base.InitializeAsync(navigationData);
      }
      catch (Exception e)
      {
        throw;
      }
    }

    private async Task SettingsAsync()
    {
      //await NavigationService.NavigateToAsync<SettingsViewModel>();
    }
  }
}
