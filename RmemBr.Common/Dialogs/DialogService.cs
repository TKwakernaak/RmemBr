using System;
using System.Collections.Generic;
using System.Text;

namespace RmemBr.Common.Dialogs
{
  public class DialogService : IDialogService
  {

    public async Task<ActionSheetResult<T>> ShowActionSheet<T>(string titleText, ActionSheetOptions<T> actionsheetOptions)
    {
      var selectoptions = actionsheetOptions.SelectOptions.Keys.ToArray();
      var cancelOption = actionsheetOptions.CancelOption;

      var selectedOption = await UserDialogs.Instance.ActionSheetAsync(titleText, cancelOption, null, null, selectoptions);

      if (selectedOption == cancelOption)
        return new ActionSheetResult<T> { isCancelled = true, SelectedOption = default };

      var options = actionsheetOptions.SelectOptions.First(e => e.Key == selectedOption);

      return new ActionSheetResult<T> { isCancelled = false, SelectedOption = options.Value };
    }

    public async Task<bool> ShowConfirmDialog(string message)
    {
      var confirmConfig = ConfirmConfigs.GetBaseConfig(androidConfirmDialogresourceID, message);
      var selectedOption = await UserDialogs.Instance.ConfirmAsync(confirmConfig);

      return selectedOption;
    }

    public async Task<bool> ShowDialog(string title, string message, string okText, string cancelText)
    {
      return await UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText);
    }

    public Task ShowAlertAsync(string message, string title, string buttonLabel)
    {
      return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
    }

    public void ShowInfoToast(string message, int durationInMs = 3000)
    {

      UserDialogs.Instance.Toast(ToastConfigs.GetInfoToast(message, durationInMs));
    }

    public void ShowSuccessToast(string message, int durationInMs = 2000)
    {
      UserDialogs.Instance.Toast(ToastConfigs.GetSuccessToast(message, durationInMs));
    }

    public void ShowErrorToast(string message, int durationInMs = 2000)
    {
      UserDialogs.Instance.Toast(ToastConfigs.GetErrorToast(message, durationInMs));
    }


    public void ShowLoading(bool show)
    {
      if (show)
        UserDialogs.Instance.ShowLoading();
      else
        UserDialogs.Instance.HideLoading();
    }

    private static class ConfirmConfigs
    {
      public static ConfirmConfig GetBaseConfig(int androidStyleId, string message)
      {

        return new ConfirmConfig() { AndroidStyleId = androidStyleId, Message = message, OkText = Translations.Global_Ok, CancelText = Translations.Global_Cancel };
      }

    }

    private class ToastConfigs
    {

      public static ToastConfig GetErrorToast(string message, int durationInMs)
      {
        var toastConfig = getBaseToastConfig(message, System.Drawing.Color.DarkRed);
        toastConfig.SetDuration(durationInMs);

        return toastConfig;
      }

      public static ToastConfig GetInfoToast(string message, int durationInMs)
      {
        var toastConfig = getBaseToastConfig(message, System.Drawing.Color.DarkGoldenrod);
        toastConfig.SetDuration(durationInMs);

        return toastConfig;
      }

      public static ToastConfig GetSuccessToast(string message, int durationInMs)
      {
        var toastConfig = getBaseToastConfig(message, System.Drawing.Color.DarkGreen);
        toastConfig.SetDuration(durationInMs);

        return toastConfig;
      }

      private static ToastConfig getBaseToastConfig(string message, System.Drawing.Color color)
      {
        return new ToastConfig(message)
        {
          BackgroundColor = color
        };
      }
    }
  }
}
}
