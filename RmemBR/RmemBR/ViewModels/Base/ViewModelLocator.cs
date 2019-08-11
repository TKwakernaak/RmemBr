using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Autofac;
using System.Reflection;
using System.Globalization;
using RmemBR.Core.Service.Navigation;
using RmemBR.Core.Service.Dialogs;


namespace RmemBR.Core.ViewModels.Base
{
  public static class ViewModelLocator
  {
    private static IContainer _container;

    public static readonly BindableProperty AutoWireViewModelProperty =
        BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

    public static bool GetAutoWireViewModel(BindableObject bindable)
    {
      return (bool)bindable.GetValue(AutoWireViewModelProperty);
    }

    public static void SetAutoWireViewModel(BindableObject bindable, bool value)
    {
      bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
    }

    static ViewModelLocator()
    {
      var builder = new Autofac.ContainerBuilder();

      //      var dataAccess = Assembly.GetExecutingAssembly();
      //      builder.RegisterAssemblyTypes(dataAccess)
      //.public
      //             .Where(t => t.Name.ToLower().EndsWith("viewmodel"))
      //             .AsImplementedInterfaces();

      builder.RegisterType<Main_ViewModel>();
      builder.RegisterType<Home_ViewModel>();
      builder.RegisterType<TasksOverview_ViewModel>();    
      builder.RegisterType<NavigationService>().As<INavigationService>();
     // builder.RegisterType<DialogService>().As<IDialogService>();

     _container = builder.Build(); 
    }

     public static T Resolve<T>() where T : class
    {
      return _container.Resolve<T>();
    }

    private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
      var view = bindable as Element;
      if (view == null)
      {
        return;
      }

      var viewType = view.GetType();
      var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
      var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
      var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

      var viewModelType = Type.GetType(viewModelName);
      if (viewModelType == null)
      {
        return;
      }
      var viewModel = _container.Resolve(viewModelType);
      view.BindingContext = viewModel;
    }
  }
}
