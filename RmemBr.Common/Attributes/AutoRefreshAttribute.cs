using System;
using System.Collections.Generic;
using System.Text;

namespace RmemBr.Common.Attributes
{
  /// <summary>
  /// shows that an field or property should be included in a mass calling of
  /// propertyChanged();
  /// </summary>
  [AttributeUsage(validOn: AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  public class AutoRefreshAttribute : Attribute
  {
  }
}
