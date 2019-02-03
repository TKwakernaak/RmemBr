using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RmemBR.Core.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class CustomNavigation_View : NavigationPage
  {
    public CustomNavigation_View()
    {
      InitializeComponent();
    }

    public CustomNavigation_View(Page root) : base(root)
    {
      InitializeComponent(); 
    }
  }
}