using RmemBR.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RmemBR.Core.ViewModels
{
  public class Home_ViewModel : ViewModelBase
  {
    public List<string> Maincolors = new List<string>();
    public Home_ViewModel()
    {
      Maincolors.Add("a");
      Maincolors.Add("b");
    }



    public DateTime TodayDate => DateTime.Now;
    public DateTime MaxDate => DateTime.Now.AddYears(1);

    public ICommand SelectedDate => new Command<DateTime>(DoStuff);

    private void DoStuff(DateTime selectedDateTime)
    {

    }

    public override async Task InitializeAsync(object navigationData)
    {
      IsBusy = true;

      //initialize data here
      IsBusy = false;
    }
  }
}
