using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TurkishCeltx.Model;

namespace TurkishCeltx.Doc
{
   public class FileConverter
   {
      public static void UpdateProjectInFile(Project selectedProject)
      {
         string mainPath = Configuration.getMainPath() + selectedProject.ScriptName + "\\";
         string titlePath = mainPath + "TITLE.txt";
         string scenePathFormat = mainPath + "SCENE_{0}.txt";

         File.WriteAllText(titlePath, selectedProject.ScriptName + "_" + selectedProject.Author);

         for (int i = 1; i < selectedProject.Scenes.Count + 1; i++)
         {
            string scenePath = string.Format(scenePathFormat, i);
            string sceneText = selectedProject.Scenes[i].GetDocFormat();

            File.WriteAllText(scenePath, sceneText);
         }
      }
   }
}