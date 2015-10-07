using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TurkishCeltx.View
{
   /// <summary>
   /// Interaction logic for MainTextAreaView.xaml
   /// </summary>
   public partial class MainTextAreaView : UserControl
   {
      // Timer updateTimer = new Timer(5000);
      
      public MainTextAreaView()
      {
         InitializeComponent();
         //updateTimer.Elapsed += updateTimer_Elapsed;
         //updateTimer.Start();
      }

      #region Event Handlers

      /// <summary>
      /// Forces an update of the FsRichTextBox.Document property.
      /// </summary>
      private void OnForceUpdateClick(object sender, RoutedEventArgs e)
      {
         this.EditBox.UpdateDocumentBindings();

      }

      #endregion
   }
}
