using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public class SceneModel : ParagraphModel
   {
      public SceneModel()
      {
         Lines = new List<LineModel>();
         SubParagraphs = new Dictionary<int, ParagraphModel>();
      }

      public override string GetDocFormat()
      {
         string text = "<sc\n";

         for(int i = 0; i < Lines.Count; i++)
         {
            if(SubParagraphs.ContainsKey(i))
            {
               text += "\n" + SubParagraphs[i].GetDocFormat();
            }

            text += "\n" + Lines[i].GetDocFormat();
         }

         if(SubParagraphs.ContainsKey(Lines.Count))
         {
            text += "\n" + SubParagraphs[Lines.Count].GetDocFormat();
         }

         text += "\n" + "/>";

         List<string> textLines = text.Split(new char[] { '\n' }).ToList();

         int indent = 1;

         text = "<sc";

         for(int i = 1; i < textLines.Count; i++)
         {
            string currentLine = textLines[i].Trim();
            text += "\n" + Configuration.getTabSpace(indent) + currentLine;

            if(currentLine.Contains("<"))
            {
               indent++;
            }

            if(currentLine.Contains(">"))
            {
               indent--;
            }
         }

         return text;
      }

      public override void ExtractFromDoc(string text)
      {
         string[] textLines = text.Split(new char[] { '\n' });

         if(!textLines[0].Trim(' ').StartsWith("<ac") || textLines[textLines.Length - 1].Trim(' ') != "/>")
         {
            throw new FormatException();
         }

         // Extract DIS_TERAS_GECE

         for(int i = 1; i < textLines.Length - 1; i++)
         {
            string currentLine = textLines[i].Trim();

            if(currentLine.StartsWith("<ac"))
            {
               string actionText = currentLine;

               int indentCount = 1;

               while(currentLine != "/>" && indentCount != 0)
               {
                  i++;
                  currentLine = textLines[i];
                  actionText += "\n" + currentLine;

                  if(currentLine.Contains('<'))
                  {
                     indentCount++;
                  }

                  if(currentLine.Contains('>'))
                  {
                     indentCount--;
                  }
               }

               ActionModel newAction = new ActionModel(actionText);
               SubParagraphs[Lines.Count] = newAction;
            }
            else if(currentLine.StartsWith("<di"))
            {
               string dialogText = currentLine;

               int indentCount = 1;

               while(currentLine != "/>" && indentCount != 0)
               {
                  i++;
                  currentLine = textLines[i];
                  dialogText += "\n" + currentLine;

                  if(currentLine.Contains('<'))
                  {
                     indentCount++;
                  }

                  if(currentLine.Contains('>'))
                  {
                     indentCount--;
                  }
               }

               DialogModel newDialog = new DialogModel(dialogText);
               SubParagraphs[Lines.Count] = newDialog;
            }
            else
            {
               LineModel newLine = new LineModel(currentLine);
               Lines.Add(newLine);
            }
         }
      }
   }
}
