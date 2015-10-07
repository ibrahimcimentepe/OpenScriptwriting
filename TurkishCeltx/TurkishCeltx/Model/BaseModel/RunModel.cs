using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public abstract class RunModel
   {
      public abstract string GetDocFormat();
      public abstract void ExtractFromDoc(string text);
   }
}
