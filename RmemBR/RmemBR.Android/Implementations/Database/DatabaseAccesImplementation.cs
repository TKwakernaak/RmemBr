using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RmemBR.Core;
using RmemBR.Droid.Implementations.Database;
using RmemBR.Core.Constants;
using RmemBR.SharedDependencies;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseAccesImplementation))]
namespace RmemBR.Droid.Implementations.Database
{
  public class DatabaseAccesImplementation : IDataBaseAccess
  {
    public string DatabasePath()
    {
      var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DatabaseConstants.OFFLINE_DATABASE_NAME);

      if (!File.Exists(path))
      {
        File.Create(path).Dispose();
      }

      return path;
    }
  }
}