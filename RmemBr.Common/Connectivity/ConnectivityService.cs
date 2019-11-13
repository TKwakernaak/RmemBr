using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RmemBr.Common.Connectivity
{
  public class ConnectivityService : IConnectivityService
  {
    public bool IsThereInternet => Xamarin.Essentials.Connectivity.NetworkAccess == NetworkAccess.Internet;
  }
}
