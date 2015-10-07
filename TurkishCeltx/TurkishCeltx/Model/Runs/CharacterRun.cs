using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public class CharacterRun : RunModel
   {
      string Name;

      public override string GetDocFormat()
      {
         return "<ch " + Name + "/>";
      }

      public override void ExtractFromDoc(string text)
      {
         Name = text.Trim().Substring(4, text.Length - 6);
      }
   }
}
