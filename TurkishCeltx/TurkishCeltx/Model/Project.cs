using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkishCeltx.Model
{
   public class Project
   {
      public Project(string projectName)
      {
         ScriptName = projectName;
         Scenes = new List<SceneModel>();
      }

      public string Author
      {
         get;
         set;
      }

      public string ScriptName
      {
         get;
         set;
      }

      public List<SceneModel> Scenes
      {
         get;
         set;
      }
   }
}
