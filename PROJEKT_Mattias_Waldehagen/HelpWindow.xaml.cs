﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PROJEKT_Mattias_Waldehagen
{
    public partial class HelpWindow : Window
    {
        Dictionary<string, string> helpTexts = new Dictionary<string, string>();
        string lang;

        public HelpWindow()
        {
            InitializeComponent();
            SetupHelpTexts();
            UpdateLanguage("EN");
        }

        //Uppdaterar språket samt startar uppdateringsprocessen
        public void UpdateLanguage(string language)
        {
            lang = language;
            UpdateDisplayTexts();
        }

        //Uppdaterar de "statiska" textblocken
        private void UpdateDisplayTexts()
        {
            DescriptonTextBlock.Text = helpTexts["DescriptionText_" + lang];
            UsageTextBlock.Text = helpTexts["UsageText_" + lang];
            ExampleTextBlock.Text = helpTexts["ExampleText_" + lang];
        }

        //Visar den efterfrågade informationen i angivna textblock
        private void UpdateCommandHelp(string command)
        {
            DescriptionContainer.Text = helpTexts[command + "_Description_" + lang];
            UsageContainer.Text = helpTexts[command + "_Usage_" + lang];
            ExampleContainer.Text = helpTexts[command + "_Example_" + lang];
        }

        //Hanterar samtliga knapptryck och skickar vidare commandot till uppdaterings metoden
        private void CommandButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string command = button.Tag.ToString();
                UpdateCommandHelp(command);
            }
        }

        //Sätter upp allt innehåll på samtliga språk, kan och bör kanske refaktoreras till en eller flera externa filer för att slippa ladda språk som inte valts
        private void SetupHelpTexts()
        {
            helpTexts["DescriptionText_EN"] = "Description:";
            helpTexts["UsageText_EN"] = "Usage:";
            helpTexts["ExampleText_EN"] = "Example:";

            helpTexts["cd_Description_EN"] = "Navigate to a different folder in your file system.";
            helpTexts["cd_Usage_EN"] = "cd path\\to\\directory";
            helpTexts["cd_Example_EN"] = "If you want to navigate to the Documents folder, you would type 'cd Documents' if it's a direct child of the current directory.";

            helpTexts["cd.._Description_EN"] = "Moves up one level in the directory hierarchy.";
            helpTexts["cd.._Usage_EN"] = "cd..";
            helpTexts["cd.._Example_EN"] = "If you are in C:\\Users\\Username\\Documents and want to go back to C:\\Users\\Username, you would type 'cd..'";

            helpTexts["dir_Description_EN"] = "Display files and folders in the current directory.";
            helpTexts["dir_Usage_EN"] = "dir";
            helpTexts["dir_Example_EN"] = "Simply type 'dir' to see a list of all files and folders in your current directory.";

            helpTexts["cls_Description_EN"] = "Clears the command prompt screen of all previously entered commands and output.";
            helpTexts["cls_Usage_EN"] = "cls";
            helpTexts["cls_Example_EN"] = "After executing several commands, type 'cls' to clear the screen and start fresh.";

            helpTexts["copy_Description_EN"] = "Copies one or more files from one location to another.";
            helpTexts["copy_Usage_EN"] = "copy source\\path\\file destination\\path\\file";
            helpTexts["copy_Example_EN"] = "To copy a file from C:\\text.txt to D:\\backup\\text.txt, you would type copy C:\\text.txt D:\\backup\\text.txt";

            helpTexts["del_Description_EN"] = "Deletes one or more files.";
            helpTexts["del_Usage_EN"] = "del path\\to\\file";
            helpTexts["del_Example_EN"] = "To delete a file named example.txt from the current directory, you would type 'del example.txt'";

            helpTexts["move_Description_EN"] = "Moves one or more files from one location to another.";
            helpTexts["move_Usage_EN"] = "move source\\path\\file destination\\path\\file";
            helpTexts["move_Example_EN"] = "To move a file from C:\\text.txt to D:\\backup\\text.txt, you would type 'move C:\\text.txt D:\\backup\\text.txt'.";

            helpTexts["rename_Description_EN"] = "Changes the name of a file or directory.";
            helpTexts["rename_Usage_EN"] = "rename original\\path\\filename.ext newfilename.ext";
            helpTexts["rename_Example_EN"] = "To rename a file from text.txt to document.txt, you would type 'rename text.txt document.txt'.";

            helpTexts["type_Description_EN"] = "Shows the contents of a text file.";
            helpTexts["type_Usage_EN"] = "type filename";
            helpTexts["type_Example_EN"] = "To display the contents of a file named text.txt, you would type 'type text.txt'.";

            helpTexts["exit_Description_EN"] = "Closes the command prompt window or terminates the batch script, in this setting it also exits the application.";
            helpTexts["exit_Usage_EN"] = "exit";
            helpTexts["exit_Example_EN"] = "Simply type 'exit' to close the command prompt window.";

            helpTexts["DescriptionText_SV"] = "Beskrivning:";
            helpTexts["UsageText_SV"] = "Användning:";
            helpTexts["ExampleText_SV"] = "Exempel:";

            helpTexts["cd_Description_SV"] = "Navigera till en annan mapp i ditt filsystem.";
            helpTexts["cd_Usage_SV"] = "cd sökväg\\till\\mapp";
            helpTexts["cd_Example_SV"] = "Om du vill navigera till mappen Dokument, skulle du skriva 'cd Dokument' om den är direkt under aktuell katalog.";

            helpTexts["cd.._Description_SV"] = "Flyttar upp en nivå i kataloghierarkin.";
            helpTexts["cd.._Usage_SV"] = "cd..";
            helpTexts["cd.._Example_SV"] = "Om du är i C:\\Användare\\Användarnamn\\Dokument och vill gå tillbaka till C:\\Användare\\Användarnamn, skulle du skriva 'cd..'";

            helpTexts["dir_Description_SV"] = "Visar filer och mappar i den aktuella katalogen.";
            helpTexts["dir_Usage_SV"] = "dir";
            helpTexts["dir_Example_SV"] = "Skriv bara 'dir' för att se en lista över alla filer och mappar i din aktuella katalog.";

            helpTexts["cls_Description_SV"] = "Rensar kommandotolkens skärm från alla tidigare inmatade kommandon och utdata.";
            helpTexts["cls_Usage_SV"] = "cls";
            helpTexts["cls_Example_SV"] = "Efter att ha kört flera kommandon, skriv 'cls' för att rensa skärmen och börja om.";

            helpTexts["copy_Description_SV"] = "Kopierar en eller flera filer från en plats till en annan.";
            helpTexts["copy_Usage_SV"] = "copy källsökväg\\fil destinationssökväg\\fil";
            helpTexts["copy_Example_SV"] = "För att kopiera en fil från C:\\text.txt till D:\\backup\\text.txt, skulle du skriva 'copy C:\\text.txt D:\\backup\\text.txt'.";

            helpTexts["del_Description_SV"] = "Tar bort en eller flera filer.";
            helpTexts["del_Usage_SV"] = "del sökväg\\till\\fil";
            helpTexts["del_Example_SV"] = "För att ta bort en fil som heter example.txt från den aktuella katalogen, skulle du skriva 'del example.txt'";

            helpTexts["move_Description_SV"] = "Flyttar en eller flera filer från en plats till en annan.";
            helpTexts["move_Usage_SV"] = "move källsökväg\\fil destinationssökväg\\fil";
            helpTexts["move_Example_SV"] = "För att flytta en fil från C:\\text.txt till D:\\backup\\text.txt, skulle du skriva 'move C:\\text.txt D:\\backup\\text.txt'.";

            helpTexts["rename_Description_SV"] = "Ändrar namnet på en fil eller katalog.";
            helpTexts["rename_Usage_SV"] = "rename ursprunglig\\sökväg\\filnamn.ext nyttfilnamn.ext";
            helpTexts["rename_Example_SV"] = "För att byta namn på en fil från text.txt till document.txt, skulle du skriva 'rename text.txt document.txt'.";

            helpTexts["type_Description_SV"] = "Visar innehållet i en textfil.";
            helpTexts["type_Usage_SV"] = "type filnamn";
            helpTexts["type_Example_SV"] = "För att visa innehållet i en fil som heter text.txt, skulle du skriva 'type text.txt'.";

            helpTexts["exit_Description_SV"] = "Stänger kommandotolksfönstret eller avslutar batchskriptet. I denna setting avslutas även applikationen";
            helpTexts["exit_Usage_SV"] = "exit";
            helpTexts["exit_Example_SV"] = "Skriv bara 'exit' för att stänga kommandotolksfönstret.";
        }
    }
}
