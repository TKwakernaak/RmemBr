using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RmemBR.Core.ViewModels;
using RmemBR.Core.ViewModels.Base;
using RmemBR.Core.Views;
using RmemBR.Core.Models.Navigation;

namespace RmemBR.Core.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Main_View : TabbedPage
  {
    public Main_View()
    {
      InitializeComponent();
      CreateTabs();


    }
    /// <summary>
    /// todo: Refactor to factory method.
    /// </summary>
    private async void CreateTabs()
    {
      var Home    = await CreateHomePage();
      var History = await CreateHistoryPage(); 

      this.Children.Add(Home);
      this.Children.Add(History);
    }

    private async Task<Page> CreateHomePage()
    {
      var Home      = new Home_View();
      Home.Title    = "Home";
      Home.TabIndex = (int)TabParameter.Home;

   //   await((Home_ViewModel)Home.BindingContext).InitializeAsync(null);

      return await Task.FromResult(Home);
    }

    private async Task<Page> CreateHistoryPage()
    {
      var History = new History_View();
      History.Title = "History";
      History.TabIndex = (int)TabParameter.History;

      //await ((History_ViewModel)History.BindingContext).InitializeAsync(null);

      return await Task.FromResult(History);
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();


      MessagingCenter.Subscribe<Main_ViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
      {
        switch (arg)
        {
          case (int)TabParameter.Home:
            CurrentPage = Children[1];
            break;
          case (int)TabParameter.History:
              break;
          case (int)TabParameter.Settings:
            break;
        }
      });
    }

    protected override async void OnCurrentPageChanged()
    {
      base.OnCurrentPageChanged();

      //if (CurrentPage is BasketView)
      //{
      //  // Force basket view refresh every time we access it
      //  await (BasketView.BindingContext as ViewModelBase).InitializeAsync(null);
      //}
      //else if (CurrentPage is CampaignView)
      //{
      //  // Force campaign view refresh every time we access it
      //  await (CampaignView.BindingContext as ViewModelBase).InitializeAsync(null);
      //}
      //else if (CurrentPage is ProfileView)
      //{
      //  // Force profile view refresh every time we access it
      //  await (ProfileView.BindingContext as ViewModelBase).InitializeAsync(null);
      //}
    }
  }
}