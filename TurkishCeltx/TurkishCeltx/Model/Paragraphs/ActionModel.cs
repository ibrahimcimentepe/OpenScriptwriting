using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public class ActionModel : ParagraphModel
   {
      public ActionModel()
      {
         Lines = new List<LineModel>();
         SubParagraphs = new Dictionary<int, ParagraphModel>();
      }

      public ActionModel(string text)
      {
         Lines = new List<LineModel>();
         SubParagraphs = new Dictionary<int, ParagraphModel>();
         ExtractFromDoc(text);
      }

      public override string GetDocFormat()
      {
         string text = "<ac\n";

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

         return text;
      }

      public override void ExtractFromDoc(string text)
      {
         string[] textLines = text.Split(new char[] {'\n'});

         if(!textLines[0].Trim(' ').StartsWith("<ac") || textLines[textLines.Length - 1].Trim(' ') != "/>")
         {
            throw new FormatException();
         }

         for(int i = 1; i < textLines.Length - 1; i++)
         {
            string currentLine = textLines[i].Trim();

            if(currentLine.StartsWith("<cm"))
            {
               string commentText = currentLine;

               int indentCount = 1;

               while (currentLine != "/>" && indentCount != 0)
               {
                  i++;
                  currentLine = textLines[i];
                  commentText += "\n" + currentLine;

                  if (currentLine.Contains('<'))
                  {
                     indentCount++;
                  }

                  if (currentLine.Contains('>'))
                  {
                     indentCount--;
                  }
               }

               CommentModel newComment = new CommentModel(commentText);
               SubParagraphs[Lines.Count] = newComment;
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

// <ac
//    <ch ENES/>, Bogaziçi Üniversitesi kampüs içinde bir binanin terasinda oturmaktadir.
//    Dizlerini çenesine çekmis, cenin pozisyonuna yakin bir pozisyona sahiptir.
//    Sirtinda çapraz asili bir ney vardir ve atletine kan bulasmistir,
//    fakat üzerinde yaralandigina dair herhangi bir iz yoktur.
//    Yüzüne sirayla yansiyan degisik renklerdeki isiklar bir ambulans ya da polis arabasinin sirenlerini andirmaktadir.
//    Gözlerinden belli belirsiz yaslar akmakta ve elinde yeni yakilmis bir sigara vardir.

//    Sahne <ch ENES/>’in bu durusuyla ayni durusa sahip <ch KÜÇÜK ENES/>’le devam eder.
// />
