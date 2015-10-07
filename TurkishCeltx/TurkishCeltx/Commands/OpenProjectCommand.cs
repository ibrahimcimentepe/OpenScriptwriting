using System;
using System.IO;
using System.Windows.Input;
using TurkishCeltx.ViewModel;

namespace TurkishCeltx.Commands
{
   public class OpenProjectCommand : ICommand
   {
      #region Fields

      // Member variables
      private MainWindowViewModel m_ViewModel;

      #endregion

      #region Constructor

      /// <summary>
      /// Default constructor.
      /// </summary>
      public OpenProjectCommand(MainWindowViewModel viewModel)
      {
         m_ViewModel = viewModel;
      }

      #endregion

      #region ICommand Members

      /// <summary>
      /// Whether the LoadDocumentCommand is enabled.
      /// </summary>
      public bool CanExecute(object parameter)
      {
         return true;
      }

      /// <summary>
      /// Actions to take when CanExecute() changes.
      /// </summary>
      public event EventHandler CanExecuteChanged
      {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }

      /// <summary>
      /// Executes the OpenNewProjectCommand
      /// </summary>
      public void Execute(object parameter)
      {
         m_ViewModel.OpenProject();
      }

      #endregion
   }
}