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

using Minesweeper.Properties;

namespace Minesweeper {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void field_Initialized(object sender, EventArgs e) {
            generateMinefield(10, 10, 1);
        }


        private void generateMinefield(int cols, int rows, int mines) {
          
            for (int r = 0; r < rows; r++) {
                // Create row
                var row = new RowDefinition();
                row.Height = new GridLength(0, GridUnitType.Auto);
                Field.RowDefinitions.Add(row);
                for (int c = 0; c < cols; c++) {
                    // Create column
                    var col = new ColumnDefinition();
                    col.Width = new GridLength(0, GridUnitType.Auto);
                    Field.ColumnDefinitions.Add(col);
                   
                    var index = r * cols + c;
                    var button = new Button();

                    var img = new Image();
                    var bitmap = Properties.Resources.InkIcon;
                    img.Source = Helpers.BitmapConverter.Convert(bitmap);
                    button.Content = img;
                    button.Name = string.Format("button_{0}_{1}", r, c);
                    button.Click += new RoutedEventHandler(button_onClick);
                    button.SetValue(Grid.ColumnProperty, c);
                    button.SetValue(Grid.RowProperty, r);
                    Field.Children.Add(button);
                }
                // Get button with specific name and change it
                //var butts = panel1.Controls.Find("button1", true);
                //(butts[0] as Button).Text = "yo";
            }
        }

        private void button_onClick(object sender, EventArgs e) {
            var butt = sender as Button;
            butt.Content = butt.Name;
        }
    }
}
