using RmemBR.Core.Service.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RmemBR.Core.ViewModels.Base
{
  public abstract class ViewModelBase : ExtendedBindableObject
  {

    protected readonly INavigationService NavigationService;
    protected IDialogService DialogService; 

    private bool _isBusy;

    public bool IsBusy
    {
      get
      {
        return _isBusy;
      }

      set
      {
        _isBusy = value;
        RaisePropertyChanged(() => IsBusy);
      }
    }

    public ViewModelBase()
    {
      NavigationService = ViewModelLocator.Resolve<INavigationService>();
      DialogService = ViewModelLocator.Resolve<IDialogService>();

    }

    public virtual Task InitializeAsync(object navigationData)
    {
      return Task.FromResult(false);
    }
  }
}
