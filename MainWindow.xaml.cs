using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace listApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Regular> users = new ObservableCollection<Regular>();
        private ObservableCollection<Manager> managers = new ObservableCollection<Manager>();
        private ObservableCollection<Administrator> administrators = new ObservableCollection<Administrator>();
        private User selectedUser = null;


        public MainWindow()
        {
            InitializeComponent();
            UI_XMLLoad();

            RUsersListbox.ItemsSource = users;
            ManagersListbox.ItemsSource = managers;
            AdministratorsListbox.ItemsSource = administrators;
        }



        public void AddUserButton_Click(object sender, RoutedEventArgs e)
        {

            if (this.FirstnameTextbox.Text.Length == 0 || this.LastnameTextbox.Text.Length == 0)
            {
                MessageBox.Show("You have to enter user's First and Last Name!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //Console.WriteLine(this.RoleCombobox.SelectedValue);

                if (((ComboBoxItem)RoleCombobox.SelectedItem).Content.ToString() == "Regular User")
                {
                    users.Add(new Regular(FirstnameTextbox.Text, LastnameTextbox.Text));
                }

                if (((ComboBoxItem)RoleCombobox.SelectedItem).Content.ToString() == "Manager")
                {
                    managers.Add(new Manager(FirstnameTextbox.Text, LastnameTextbox.Text));
                }

                if (((ComboBoxItem)RoleCombobox.SelectedItem).Content.ToString() == "Administrator")
                {
                    administrators.Add(new Administrator(FirstnameTextbox.Text, LastnameTextbox.Text));
                }


                FirstnameTextbox.Text = null;
                LastnameTextbox.Text = null;

            }

        }


        public void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (RUsersListbox.SelectedItems.Count == 0 && ManagersListbox.SelectedItems.Count == 0 && AdministratorsListbox.SelectedItems.Count == 0)
            {
                MessageBox.Show("You didn't select any users to delete!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                switch (MessageBox.Show("Do you really want to delete " + (RUsersListbox.SelectedItems.Count + ManagersListbox.SelectedItems.Count + AdministratorsListbox.SelectedItems.Count) + " user(s)?" + Environment.NewLine + "After that you won't be able to recover their accounts!", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No))
                {
                    case MessageBoxResult.Yes:

                        while (RUsersListbox.SelectedItems.Count != 0)
                        {
                            users.Remove((Regular)RUsersListbox.SelectedItems[0]);
                        }


                        while (ManagersListbox.SelectedItems.Count != 0)
                        {
                            managers.Remove((Manager)ManagersListbox.SelectedItems[0]);
                        }

                        while (AdministratorsListbox.SelectedItems.Count != 0)
                        {
                            administrators.Remove((Administrator)AdministratorsListbox.SelectedItems[0]);
                        }

                        break;

                    case MessageBoxResult.No:

                        break;

                }
            }

        }



        //
        //  INFORMATION PANEL
        //  Shows informations about selected (clicked) user in textboxes.
        //  You can edit this informations after clicking 'Edit' button.
        //

        private void Listbox_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoStackPanel.Visibility = Visibility.Visible;
            selectedUser = (User)(sender as ListBoxItem).DataContext;

            if (selectedUser.firstname != null)
                InfoFirstNameTextbox.Text = selectedUser.firstname;
            else
                InfoFirstNameTextbox.Text = null;

            if (selectedUser.lastname != null)
                InfoLastNameTextbox.Text = selectedUser.lastname;
            else
                InfoLastNameTextbox.Text = null;

            if (selectedUser.birthdate != null)
                InfoBirthDateTextbox.Text = selectedUser.birthdate;
            else
                InfoBirthDateTextbox.Text = null;

            if (selectedUser.employmentdate != null)
                InfoEmploymentDateTextbox.Text = selectedUser.employmentdate;
            else
                InfoEmploymentDateTextbox.Text = null;
        }

        private void InfoEditButton_Click(object sender, RoutedEventArgs e)
        {
            InfoSaveButton.Visibility = Visibility.Visible;
            InfoFirstNameTextbox.IsEnabled = true;
            InfoLastNameTextbox.IsEnabled = true;
            InfoBirthDateTextbox.IsEnabled = true;
            InfoEmploymentDateTextbox.IsEnabled = true;
        }

        private void InfoSaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (InfoFirstNameTextbox.Text.Length == 0 || InfoLastNameTextbox.Text.Length == 0)
            {
                MessageBox.Show("You have to enter user's First and Last Name!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                InfoSaveButton.Visibility = Visibility.Collapsed;

                InfoFirstNameTextbox.IsEnabled = false;
                InfoLastNameTextbox.IsEnabled = false;
                InfoBirthDateTextbox.IsEnabled = false;
                InfoEmploymentDateTextbox.IsEnabled = false;

                selectedUser.firstname = InfoFirstNameTextbox.Text;
                selectedUser.lastname = InfoLastNameTextbox.Text;
                selectedUser.birthdate = InfoBirthDateTextbox.Text;
                selectedUser.employmentdate = InfoEmploymentDateTextbox.Text;

                RUsersListbox.Items.Refresh();
                ManagersListbox.Items.Refresh();
                AdministratorsListbox.Items.Refresh();
            }
        }



        //
        //  MENU PANEL
        //  Splitted into 'File' and 'About'.
        //  From 'File' panel you can save changes, load from file(TODO) and Exit program.
        //

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {

            switch (MessageBox.Show("Do you really want to save your changes?", "Save?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel))
            {
                case MessageBoxResult.Yes:
                    UI_XMLSave();
                    break;

                default:
                    break;
            }
        }


        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            UI_AppExit(sender);
        }



        //
        //  WINDOW CLOSING
        //  Event is firing when 'X' button was clicked.
        //  
        //

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UI_AppExit(sender, e);
        }

    }
}
