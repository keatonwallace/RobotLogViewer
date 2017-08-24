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
using System.IO;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace RobotLogViewer.ViewModels
{
    class Presenter
    {
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        //I don't have the focus tonight to do much. I will do better tomorrow
        private void bOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Open the selected file to read.
                System.IO.Stream fileStream = openFileDialog1.OpenFile();

                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    // Read the first line from the file and write it the textbox.
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        _history.Add(line);
                        //richTextBox1.AppendText(line);
                        //richTextBox1.AppendText(System.Environment.NewLine);
                    }

                }
                fileStream.Close();
            }
        }
    }
}
