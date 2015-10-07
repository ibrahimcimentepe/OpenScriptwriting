using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public class CommentModel : ParagraphModel
   {
      public DateTime Date;
      public string Author;

      public CommentModel()
      {
         Lines = new List<LineModel>();
      }

      public CommentModel(string text)
      {
         Lines = new List<LineModel>();
         // SubParagraphs = new Dictionary<int, ParagraphModel>();

         ExtractFromDoc(text);
      }

      public override string GetDocFormat()
      {
         string text = "<cm\n";

         for (int i = 0; i < Lines.Count; i++)
         {
            text += "\n" + Configuration.TabSpace + Lines[i].GetDocFormat();
         }

         text += "\n" + "/>";

         return text;
      }

      public override void ExtractFromDoc(string text)
      {
         string[] textLines = text.Split(new char[] { '\n' });

         if (!textLines[0].Trim(' ').StartsWith("<cm") || textLines[textLines.Length - 1].Trim(' ') != "/>")
         {
            throw new FormatException();
         }
         
         // TODO Extract Date and Author

         for (int i = 1; i < textLines.Length - 1; i++)
         {
            string currentLine = textLines[i].Trim();

            LineModel newLine = new LineModel(currentLine);
            Lines.Add(newLine);
         }
      }
   }
}
