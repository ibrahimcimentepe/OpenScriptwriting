using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public class TextRun : RunModel
   {
      string Text;

      public override string GetDocFormat()
      {
         return Text;
      }

      public override void ExtractFromDoc(string text)
      {
         Text = text;
      }
   }
}
