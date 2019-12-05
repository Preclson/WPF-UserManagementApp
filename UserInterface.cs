using System;
using System.Windows;

namespace listApp
{
    public partial class MainWindow
    {
        public void UI_XMLSave()
        {
            switch (XMLSave())
            {
                case true:
                    MessageBox.Show("Files saved succesfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    break;

                case false:
                    MessageBox.Show("Unable to save files!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                    break;
            }
        }


        public void UI_XMLLoad()
        {
            switch (XMLLoad())
            {
                case true:
                    //MessageBox.Show("Files loaded succesfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);;;;;
                    break;

                case false:
                    MessageBox.Show("Unable to load files!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                    break;
            }
        }


        public void UI_AppExit(object sender, System.ComponentModel.CancelEventArgs e = null)
        {
            switch (MessageBox.Show("You are going to exit the program!" + Environment.NewLine + "Do you want to save your changes?", "Warning!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel))
            {
                case MessageBoxResult.Yes:
                    UI_XMLSave();
                    System.Windows.Application.Current.Shutdown();
                    break;

                case MessageBoxResult.No:
                    System.Windows.Application.Current.Shutdown();
                    break;

                case MessageBoxResult.Cancel:
                    try { e.Cancel = true; }
                    catch { }
                    break;
            }


        }
    }
}
