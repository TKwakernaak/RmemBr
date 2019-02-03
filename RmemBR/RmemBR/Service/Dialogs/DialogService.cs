using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RmemBR.Core.Service.Dialogs
{
  class DialogService : IDialogService
  {
    public Task ShowAlertAsync(string message, string title, string buttonLabel)
    {
      return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
    }

    public void ShowToastAsync(string message)
    {
      UserDialogs.Instance.Toast(message);
    }
  }
}
