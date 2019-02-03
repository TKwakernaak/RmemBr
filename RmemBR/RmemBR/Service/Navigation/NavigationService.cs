using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RmemBR.Core.ViewModels;
using RmemBR.Core.ViewModels.Base;
using RmemBR.Core.Views;
using Xamarin.Forms;

namespace RmemBR.Core.Service.Navigation
{
  public class NavigationService : INavigationService
  {


    public NavigationService()
    {
    }

    public ViewModelBase PreviousPageViewModel
    {
      get
      {
        var mainPage = Application.Current.MainPage as CustomNavigation_View;
        var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
        return viewModel as ViewModelBase;
      }
    }

    public Task InitializeAsync()
    {
      return NavigateToAsync<Main_ViewModel>();
    }


    public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
    {
      return InternalNavigateToAsync(typeof(TViewModel), null);
    }
    public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
    {
      return InternalNavigateToAsync(typeof(TViewModel), parameter);
    }

    public Task RemoveBackStackAsync()
    {
      var mainPage = Application.Current.MainPage as CustomNavigation_View;

      if (mainPage != null)
      {
        for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
        {
          var page = mainPage.Navigation.NavigationStack[i];
          mainPage.Navigation.RemovePage(page);
        }
      }

      return Task.FromResult(true);
    }

    public Task RemoveLastFromBackStackAsync()
    {
      var mainPage = Application.Current.MainPage as CustomNavigation_View;

      if (mainPage != null)
      {
        mainPage.Navigation.RemovePage(
            mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
      }

      return Task.FromResult(true);
    }

    private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
    {
      try
      {
        Page page = CreatePage(viewModelType, parameter);

        var navigationPage = Application.Current.MainPage as CustomNavigation_View;
        if (navigationPage != null)
        {
          await navigationPage.PushAsync(page);
        }
        else
        {
          Application.Current.MainPage = new CustomNavigation_View(page);
        }
        await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
      }
      catch (Exception e)
      {
        throw; 
      }

    }



    private Type GetPageTypeForViewModel(Type viewModelType)
    {
      var viewName = viewModelType.FullName.Replace("Model", string.Empty);
      var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
      var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
      var viewType = Type.GetType(viewAssemblyName);
      return viewType;
    }

    private Page CreatePage(Type viewModelType, object parameter)
    {
      Type pageType = GetPageTypeForViewModel(viewModelType);
      if (pageType == null)
      {
        throw new Exception($"Cannot locate page type for {viewModelType}");
      }

      Page page = Activator.CreateInstance(pageType) as Page;
      return page;
    }
  }
}
