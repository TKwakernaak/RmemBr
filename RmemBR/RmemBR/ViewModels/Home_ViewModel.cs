using RmemBR.Core.ViewModels.Base;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RmemBR.Core.ViewModels
{
  public class Home_ViewModel : ViewModelBase
  {

    private ConcurrentQueue<string> _tags;

    private string _tag;

    public Home_ViewModel()
    {
      _tags = new ConcurrentQueue<string>();
    }

    public string Tags
    {
      get
      {
        string x = "";
        _tags.TryPeek(out x);
        return x;
      }
      set
      {
        _tags.Enqueue(value);
      }
    }

    public string Tag
    {
      get
      {
        return _tag;
      }
      set
      {
        _tag = value;
        OnPropertyChanged("Tag");
       }
    }

    public ICommand TagAddedCommand => new Command(TagAdded);


    public void TagAdded()
    {
      _tags.Enqueue(_tag);
      RaisePropertyChanged(() => Tags);
    }

    public override async Task InitializeAsync(object navigationData)
    {
      IsBusy = true;

      //initialize data here
      IsBusy = false;
    }
  }
}
