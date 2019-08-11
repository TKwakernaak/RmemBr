using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RmemBR.Core.Service.Dialogs;
using RmemBR.Droid.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly:Dependency(typeof(Dialogs))]
namespace RmemBR.Droid.Implementations
{
  public class Dialogs : IDialogService
  {
    public void ShowToastAsync(string message)
    {
           Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
    }
  }
}