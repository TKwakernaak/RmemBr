using RmemBR.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RmemBR.Core.ViewModels
{
  public class History_ViewModel : ViewModelBase
  {

    private bool _toggle { get; set; }
    public string toggle
    {
      get => _toggle.ToString();
      set
      {
        _toggle = Convert.ToBoolean(value);
      }
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
      _toggle = !_toggle;
    }
  }
}
