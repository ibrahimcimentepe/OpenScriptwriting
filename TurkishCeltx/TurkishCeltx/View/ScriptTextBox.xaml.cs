using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TurkishCeltx.ViewModel;

namespace TurkishCeltx.View
{
   /// <summary>
   /// Interaction logic for ScriptTextBox.xaml
   /// </summary>
   public partial class ScriptTextBox : UserControl
   {
      public ScriptTextBox()
      {
         InitializeComponent();
      }

      #region Fields

      // Member variables
      private int m_InternalUpdatePending;
      private bool m_TextHasChanged;

      #endregion

      #region Dependency Property Declarations

      // Document property
      public static readonly DependencyProperty DocumentProperty =
         DependencyProperty.Register("Document", typeof(FlowDocument),
                                     typeof(ScriptTextBox), new PropertyMetadata(OnDocumentChanged));

      #endregion

      #region Properties

      /// <summary>
      /// The WPF FlowDocument contained in the control.
      /// </summary>
      public FlowDocument Document
      {
         get
         {
            return (FlowDocument)GetValue(DocumentProperty);
         }
         set
         {
            SetValue(DocumentProperty, value);
         }
      }

      #endregion

      #region PropertyChanged Callback Methods

      /// <summary>
      /// Called when the Document property is changed
      /// </summary>
      private static void OnDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         /* For unknown reasons, this method gets called twice when the
          * Document property is set. Until we figure out why, we initialize
          * the flag to 2 and decrement it each time through this method. */

         // Initialize
         var thisControl = (ScriptTextBox)d;

         // Exit if this update was internally generated
         if(thisControl.m_InternalUpdatePending > 0)
         {

            // Decrement flags and exit
            thisControl.m_InternalUpdatePending--;
            return;
         }

         // Set Document property on RichTextBox
         thisControl.TextBox.Document = (e.NewValue == null) ? new FlowDocument() : (FlowDocument)e.NewValue;

         // Reset flag
         thisControl.m_TextHasChanged = false;
      }

      #endregion

      #region Event Handlers

      /// <summary>
      ///  Invoked when the user changes text in this user control.
      /// </summary>
      private void OnTextChanged(object sender, TextChangedEventArgs e)
      {
         // Set the TextChanged flag
         m_TextHasChanged = true;
         UpdateDocumentBindings();
      }

      /// <summary>
      /// Updates the toolbar when the text selection changes.
      /// </summary>
      private void OnTextBoxSelectionChanged(object sender, RoutedEventArgs e)
      {
      }

      #endregion

      #region Public Methods

      /// <summary>
      /// Forces an update of the Document property.
      /// </summary>
      public void UpdateDocumentBindings()
      {
         // Exit if text hasn't changed
         if(!m_TextHasChanged)
         {
            return;
         }

         // Set 'Internal Update Pending' flag
         m_InternalUpdatePending = 2;

         // Set Document property
         SetValue(DocumentProperty, this.TextBox.Document);
      }

      #endregion

      private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
      {
         switch(e.Key)
         {
            case Key.Enter:
               
               break;
         }
      }
   }
}
