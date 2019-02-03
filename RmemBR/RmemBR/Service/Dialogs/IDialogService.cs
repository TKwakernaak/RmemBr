using System;
using System.Collections.Generic;
using System.Text;

namespace RmemBR.Core.Service.Dialogs
{
  public interface IDialogService
  {
    void ShowToastAsync(string message);
  }
}
