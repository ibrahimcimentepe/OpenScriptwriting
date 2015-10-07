using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using TurkishCeltx.Commands;
using TurkishCeltx.Model;

namespace TurkishCeltx.ViewModel
{
   public class MainWindowViewModel : ViewModelBase
   {
      #region MEMBERS

      public Project CurrentProject;

      public MainTextAreaViewModel mainTextAreaVm
      {
         get;
         private set;
      }

      #endregion MEMBERS

      #region Constructor

      public MainWindowViewModel()
      {
         CurrentProject = new Project("ÇAPRAZ NEYLİ HİKAYE");
         mainTextAreaVm = new MainTextAreaViewModel(CurrentProject);

         this.NewProjectCommand = new NewProjectCommand(this);
         this.OpenProjectCommand = new OpenProjectCommand(this);
         this.SaveProjectCommand = new SaveProjectCommand(mainTextAreaVm);
         this.SaveProjectAsCommand = new SaveProjectAsCommand(this);
         this.ExitCommand = new ExitCommand(this);
         this.UndoCommand = new UndoCommand(this);
         this.RedoCommand = new RedoCommand(this);
         this.CutCommand = new CutCommand(this);
         this.CopyCommand = new CopyCommand(this);
         this.PasteCommand = new PasteCommand(this);
         this.SelectAllCommand = new SelectAllCommand(this);
         this.FindCommand = new FindCommand(this);
         this.ReplaceCommand = new ReplaceCommand(this);
         this.ImportScriptCommand = new ImportScriptCommand(this);
         this.ExportScriptCommand = new ExportScriptCommand(this);
         this.OpenAboutPageCommand = new OpenAboutPageCommand(this);
      }

      #endregion

      #region COMMANDS

      public ICommand NewProjectCommand
      {
         get;
         set;
      }
      public ICommand OpenProjectCommand
      {
         get;
         set;
      }
      public ICommand SaveProjectCommand
      {
         get;
         set;
      }
      public ICommand SaveProjectAsCommand
      {
         get;
         set;
      }
      public ICommand ExitCommand
      {
         get;
         set;
      }
      public ICommand UndoCommand
      {
         get;
         set;
      }
      public ICommand RedoCommand
      {
         get;
         set;
      }
      public ICommand CutCommand
      {
         get;
         set;
      }
      public ICommand CopyCommand
      {
         get;
         set;
      }
      public ICommand PasteCommand
      {
         get;
         set;
      }
      public ICommand SelectAllCommand
      {
         get;
         set;
      }
      public ICommand FindCommand
      {
         get;
         set;
      }
      public ICommand ReplaceCommand
      {
         get;
         set;
      }
      public ICommand ImportScriptCommand
      {
         get;
         set;
      }
      public ICommand ExportScriptCommand
      {
         get;
         set;
      }
      public ICommand OpenAboutPageCommand
      {
         get;
         set;
      }

      #endregion

      #region METHODS

      public void NewProject()
      {
         throw new NotImplementedException();
      }

      public void Exit()
      {
         throw new NotImplementedException();
      }

      public void Cut()
      {
         throw new NotImplementedException();
      }

      public void Copy()
      {
         throw new NotImplementedException();
      }

      public void ExportScript()
      {
         throw new NotImplementedException();
      }

      public void Find()
      {
         throw new NotImplementedException();
      }

      public void ImportScript()
      {
         throw new NotImplementedException();
      }

      public void OpenAboutPage()
      {
         throw new NotImplementedException();
      }

      public void OpenProject()
      {
         throw new NotImplementedException();
      }

      public void Paste()
      {
         throw new NotImplementedException();
      }

      public void Redo()
      {
         throw new NotImplementedException();
      }

      public void Replace()
      {
         throw new NotImplementedException();
      }

      public void SaveProjectAs()
      {
         throw new NotImplementedException();
      }

      public void SelectAll()
      {
         throw new NotImplementedException();
      }

      public void Undo()
      {
         throw new NotImplementedException();
      }

      #endregion
   }
}
