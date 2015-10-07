using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx
{
   public class Configuration
   {
      private static string mTabSpace = "";
      public static string TabSpace
      {
         get
         {
            if (mTabSpace == "")
            {
               for (int j = 0; j < CeltxSettings.Default.TabSize; j++)
               {
                  mTabSpace += " ";
               }
            }

            return mTabSpace;
         }
      }

      public static string getMainPath()
      {
         CeltxSettings settings = CeltxSettings.Default;

         return settings.MainPath;
      }

      public static int getTabSize()
      {
         CeltxSettings settings = CeltxSettings.Default;

         return settings.TabSize;
      }

      public static string getTabSpace(int tabCount)
      {
         string spaces = "";

         for(int i = 0; i < tabCount; i++)
         {
            spaces += TabSpace;
         }

         return spaces;
      }
   }
}
