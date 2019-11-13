using System;
using System.Collections.Generic;
using System.Text;

namespace RmemBr.Common.Attributes
{
  [AttributeUsage(validOn: AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  public class AutoResetAttribute : Attribute
  {
  }
}
