using System;
using System.Collections.Generic;
using System.Text;

namespace RmemBr.Common.Dialogs
{
  public class Actionsheet
  {
    public static ActionSheetOptions<bool> TrueFalse()
    {
      var succesOptions = new Dictionary<string, bool>
      {
        { "Yes", true },
        { "No", false }
      };

      var options = new ActionSheetOptions<bool>(Translations.Global_Cancel, succesOptions);

      return options;
    }
  }
}
