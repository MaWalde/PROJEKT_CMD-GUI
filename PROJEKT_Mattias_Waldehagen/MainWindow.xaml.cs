using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROJEKT_Mattias_Waldehagen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExecuteCommand(string command)
        {
            //TBD: CMD logik
        }

        private void ToggleLanguage(string language)
        {
            if (language == "EN")
            {
                cdButton.ToolTip = "Change Directory - Navigate to a different folder.";
                cdBackButton.ToolTip = "Go up one directory level.";
                dirButton.ToolTip = "List Directory Contents - Display files and folders in the current directory.";
                clsButton.ToolTip = "Clear Screen - Clears the command prompt screen.";
                copyButton.ToolTip = "Copy Files - Copies one or more files from one location to another.";
                moveButton.ToolTip = "Move Files - Moves one or more files from one location to another.";
                renameButton.ToolTip = "Rename - Changes the name of a file or directory.";
                typeButton.ToolTip = "Display Contents - Shows the contents of a text file.";
                exitButton.ToolTip = "Exit - Closes the command prompt window.";
                helpButton.ToolTip = "More information on commands, with examples.";
                pathButton.ToolTip = "Set where your interaction with CMD will start.";
                helpButton.Content = "HELP";
                pathButton.Content = "PATH";
            }
            else if (language == "SV")
            {
                cdButton.ToolTip = "Byt katalog - Navigera till en annan mapp.";
                cdBackButton.ToolTip = "Gå upp en katalognivå.";
                dirButton.ToolTip = "Lista kataloginnehåll - Visar filer och mappar i den aktuella katalogen.";
                clsButton.ToolTip = "Rensa skärm - Rensar kommandotolkens skärm.";
                copyButton.ToolTip = "Kopiera filer - Kopierar en eller flera filer från en plats till en annan.";
                moveButton.ToolTip = "Flytta filer - Flyttar en eller flera filer från en plats till en annan.";
                renameButton.ToolTip = "Byt namn - Ändrar namnet på en fil eller katalog.";
                typeButton.ToolTip = "Visa innehåll - Visar innehållet i en textfil.";
                exitButton.ToolTip = "Avsluta - Stänger kommandotolksfönstret.";
                helpButton.ToolTip = "Mer information om kommandon, med exempel.";
                pathButton.ToolTip = "Ställ in var din interaktion med CMD ska starta.";
                helpButton.Content = "HJÄLP";
                pathButton.Content = "SÖKVÄG";
            }
        }


        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ExecuteCommand(inputTextBox.Text);
            }
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(inputTextBox.Text);
        }

        private void cdButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "cd ";
            inputTextBox.Focus();
        }

        private void cdBackButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "cd..";
            inputTextBox.Focus();
        }

        private void dirButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "dir ";
            inputTextBox.Focus();
        }

        private void clsButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "cls ";
            inputTextBox.Focus();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "copy ";
            inputTextBox.Focus();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "del ";
            inputTextBox.Focus();
        }

        private void moveButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "omve ";
            inputTextBox.Focus();
        }

        private void renameButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "rename ";
            inputTextBox.Focus();
        }

        private void typeButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "type ";
            inputTextBox.Focus();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "exit";
            inputTextBox.Focus();
        }
    }
}
