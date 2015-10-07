using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TurkishCeltx.Model
{
   public class MenuItemObject
   {
      public string Header { get; set; }
      public ICommand Command { get; set; }
   }
}
