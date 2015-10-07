using System;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using TurkishCeltx;
using TurkishCeltx.Commands;
using TurkishCeltx.Model;

namespace TurkishCeltx.ViewModel
{
   public class MainTextAreaViewModel : ViewModelBase
   {
      #region Fields

      // Property variables
      private string p_DocumentXaml;
      public Project CurrentProject;

      #endregion

      #region Constructor

      //public MainTextAreaViewModel()
      //{
      //   this.LoadDocument = new LoadDocumentCommand(this);
      //}

      public MainTextAreaViewModel(Project project)
      {
         // TODO: Complete member initialization
         this.CurrentProject = project;
         this.LoadDocument = new LoadDocumentCommand(this);
         this.SaveProjectCommand = new SaveProjectCommand(this);
      }

      #endregion

      #region Command Properties

      /// <summary>
      /// Command to simulate loading a document from the app back-end
      /// </summary>
      public ICommand LoadDocument
      {
         get;
         set;
      }

      public ICommand SaveProjectCommand
      {
         get;
         set;
      }

      #endregion

      #region Data Properties

      /// <summary>
      /// The text from the FsRichTextBox, as a XAML markup string.
      /// </summary>
      public string DocumentXaml
      {
         get
         {
            return p_DocumentXaml;
         }

         set
         {
            p_DocumentXaml = value;
            base.OnPropertyChanged("DocumentXaml");
            UpdateTabbedDocumentXaml();
         }
      }

      private string mTabbedDocumentXaml;
      public string TabbedDocumentXaml
      {
         get
         {
            return mTabbedDocumentXaml;
         }
         set
         {
            mTabbedDocumentXaml = value;
            base.OnPropertyChanged("TabbedDocumentXaml");
         }
      }

      private void UpdateTabbedDocumentXaml()
      {
         string[] splitted = p_DocumentXaml.Split(new char[] {'<'}, StringSplitOptions.RemoveEmptyEntries);

         mTabbedDocumentXaml = "";

         foreach(var s in splitted)
         {
            mTabbedDocumentXaml += "<" + s + "\n";
         }

         base.OnPropertyChanged("TabbedDocumentXaml");
      }

      #endregion

      #region Methods

      public void SaveProject()
      {
         string xamlText = this.DocumentXaml;

         if(xamlText != null && CurrentProject != null)
         {
            var flowDocument = (FlowDocument)XamlReader.Parse(xamlText);
            File.WriteAllText(Configuration.getMainPath() + CurrentProject.ScriptName + "\\temp.txt", xamlText);
         }
      }

      #endregion
   }
}
