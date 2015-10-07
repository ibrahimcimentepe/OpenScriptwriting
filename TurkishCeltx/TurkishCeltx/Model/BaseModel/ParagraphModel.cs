using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public abstract class ParagraphModel
   {
      public List<LineModel> Lines;
      public Dictionary<int, ParagraphModel> SubParagraphs; // lineNo, Paragraph
      public abstract string GetDocFormat();
      public abstract void ExtractFromDoc(string text);
   }
}
