using System.Text.RegularExpressions;

namespace Renamer
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();

            PerformClipboardOperations();
        }

        private void PerformClipboardOperations()
        {
            // Read text from clipboard
            string inputText = Clipboard.GetText();

            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Clipboard is empty or does not contain text.");
                Application.Exit();
                return;
            }

            // Convert text to lowercase and replace non-alphanumeric characters with underscores
            string processedText = Regex.Replace(inputText.ToLower(), @"[^a-z0-9]", "_");

            // Remove consecutive underscores
            processedText = Regex.Replace(processedText, @"_+", "_");

            // Remove leading and trailing underscores
            processedText = processedText.Trim('_');

            // Print the processed text
            Console.WriteLine(processedText);

            // Copy the result back to the clipboard
            Clipboard.SetText(processedText);

            // Simulate Alt+Tab to switch to the previous window
            SendKeys.SendWait("%{TAB}");
            Thread.Sleep(500); // Delay to ensure the window switch is complete


            // Simulate "Select All" and "Paste" keystrokes
            SendKeys.SendWait("^a"); // Ctrl+A (Select All)
            System.Threading.Thread.Sleep(100); // Short delay to ensure the select all action is complete
            SendKeys.SendWait("^v"); // Ctrl+V (Paste)

            // Exit the application after performing operations
            Application.Exit();
        }
    }
}
