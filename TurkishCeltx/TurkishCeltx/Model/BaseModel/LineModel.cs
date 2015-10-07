using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public class LineModel
   {
      public LineModel()
      {
         Runs = new List<RunModel>();
      }

      public LineModel(string text)
      {
         Runs = new List<RunModel>();
         ExtractFromDoc(text);
      }

      public List<RunModel> Runs;
      private string dummyText;
      public string GetDocFormat()
      {
         return dummyText;
      }
      public void ExtractFromDoc(string text)
      {
         dummyText = text;
      }
   }
}
