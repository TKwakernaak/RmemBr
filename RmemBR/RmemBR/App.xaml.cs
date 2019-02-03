using RmemBR.Core;
using RmemBR.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RmemBR
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();
      InitNavigation();
    }

    private Task InitNavigation()
    {
      try
      {
        var navigationService = ViewModelLocator.Resolve<INavigationService>();
        return navigationService.InitializeAsync();
      }
      catch (Exception e)
      {
        throw;
      }

    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}
