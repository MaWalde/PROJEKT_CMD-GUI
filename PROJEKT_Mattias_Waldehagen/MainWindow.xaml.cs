using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using System.Diagnostics;

namespace PROJEKT_Mattias_Waldehagen
{
    public partial class MainWindow : Window
    {
        // Globala variabler
        Process cmdProc = new Process();
        string language = "EN";

        public MainWindow()
        {
            InitializeComponent();
            InitCmdProcess();       //Startar CMD
            ToggleLanguage();       //Ställer in allt efter standardspråket i uppstart
        }

        //Metoden som startar cmd och relaterade processer
        private void InitCmdProcess()
        {

            cmdProc.StartInfo.FileName = "cmd.exe";
            cmdProc.StartInfo.RedirectStandardInput = true;
            cmdProc.StartInfo.RedirectStandardOutput = true;
            cmdProc.StartInfo.RedirectStandardError = true;
            cmdProc.StartInfo.CreateNoWindow = true;
            cmdProc.StartInfo.UseShellExecute = false;

            //Handlers för output och errors
            cmdProc.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);
            cmdProc.ErrorDataReceived += new DataReceivedEventHandler(CmdErrorDataHandler);

            //Kod för att stänga processer OCH applikationen vid "exit"-kommando
            cmdProc.EnableRaisingEvents = true;
            cmdProc.Exited += (sender, args) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    System.Windows.Application.Current.Shutdown();
                });
            };

            cmdProc.Start();

            cmdProc.BeginOutputReadLine();
            cmdProc.BeginErrorReadLine();
        }

        //Handler för outputdatan
        private void CmdOutputDataHandler(object sendingProc, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            { 
                AppendText(outLine.Data);
            }
        }

        //Handler för felmeddelandedata
        private void CmdErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if(!String.IsNullOrEmpty(outLine.Data))
            {
                AppendText(outLine.Data);
            }
        }

        //Lägger till text i output-textblocket
        private void AppendText(string text)
        {
            Dispatcher.Invoke(() =>
            {
                outputTextBlock.Text += text + Environment.NewLine;
            });
        }

        //Utför det kommando som står i input mot den aktiva cmd'n
        private void ExecuteCommand(string command)
        {
            if (cmdProc != null && !cmdProc.HasExited)
            {
                cmdProc.StandardInput.WriteLine(command);
                cmdProc.StandardInput.Flush();
            }
        }

        //Togglar valt språk
        private void ToggleLanguage()
        {
            if (language == "EN")
            {
                cdButton.ToolTip = "Change Directory - Navigate to a different folder.";
                cdBackButton.ToolTip = "Go up one directory level.";
                dirButton.ToolTip = "List Directory Contents - Display files and folders in the current directory.";
                clsButton.ToolTip = "Clear Screen - Clears the command prompt screen.";
                deleteButton.ToolTip = "Delete File - Removes chosen file from your unit.";
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
                deleteButton.ToolTip = "Radera fil - Raderar vald fil från din enhet.";
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

        //Läser av enterknappen på tangentbordet
        private void inputTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ExecuteCommand(inputTextBox.Text);
            }
        }

        //Läser av enterknappen i programmet
        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(inputTextBox.Text);
        }

        //Läser cd-knapp
        private void cdButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "cd ";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser cd..-knapp
        private void cdBackButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "cd..";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser dir-knapp
        private void dirButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "dir ";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser cls-knapp
        private void clsButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "cls ";
            inputTextBox.Focus(); 
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser copy-knapp
        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "copy ";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser del-knapp
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "del ";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser move-knapp
        private void moveButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "move ";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser rename-knapp
        private void renameButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "rename ";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser type-knapp
        private void typeButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "type ";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser exit-knapp
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "exit";
            inputTextBox.Focus();
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
        }

        //Läser help-knapp och visar HelpWindow sida vid sida med MainWindow
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();

            helpWindow.Left = this.Width + this.Left;
            helpWindow.Top = this.Top;

            helpWindow.UpdateLanguage(language);
            helpWindow.Show();
        }

        //Läser path-knapp och startar GUI för val av folder
        private void pathButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    SendToCMD(selectedPath);
                }  
            }
        }

        //Skickar vald folder till cmd och navigerar cmd till valet
        private void SendToCMD(string path)
        {
            string command = $"cd \"{path}\"";
            ExecuteCommand(command);
        }

        //Hanterar språkvals-knappar och byte av språk
        private void LangButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button)
            {
                language = button.Tag.ToString();
                ToggleLanguage();
            }
        }
    }
}
