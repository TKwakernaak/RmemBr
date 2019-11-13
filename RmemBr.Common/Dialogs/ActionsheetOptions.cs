using System;
using System.Collections.Generic;

namespace RmemBr.Common.Dialogs
{
  public class ActionSheetOptions<T>
  {
    public string CancelOption { get; }
    public Dictionary<string, T> SelectOptions { get; }

    public ActionSheetOptions(string cancelOption, Dictionary<string, T> SelectOptions)
    {
      if (string.IsNullOrEmpty(cancelOption))
        throw new ArgumentException("cancelOption must be defined");
      if (!SelectOptions.Any())
        throw new ArgumentException("Actionsheetoptions cannot be empty");

      CancelOption = cancelOption;
      this.SelectOptions = SelectOptions;
    }


  }
}