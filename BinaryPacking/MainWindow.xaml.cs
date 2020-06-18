using BinaryPacking.Models;
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


namespace BinaryPacking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Add Delete of Detail
        // When no elements added have exception
        private readonly Sheet _sheet;

        public MainWindow()
        {
            InitializeComponent();
           _sheet = new Sheet();
        }

        private void CreateDetail_Click(object sender, RoutedEventArgs e)
        {
            uint detailHeight=100;
            uint detailWidth=100;
            if (!(UInt32.TryParse(DetailHeight.Text, out detailHeight) && UInt32.TryParse(DetailWidth.Text, out detailWidth)))
            {
                MessageBox.Show("Ширина и висота должны быть целыми числами!");
                return;
            }
            if(detailHeight<10 || detailWidth < 10)
            {
                MessageBox.Show("Ширина и висота должны быть > 10 !");
                return;
            }
            
            // Random Color
            var elem = new Rectangle()
            {
                Width = detailWidth,
                Height = detailHeight,
                Fill = new SolidColorBrush(Colors.Aqua),
                HorizontalAlignment = HorizontalAlignment.Left,
                StrokeThickness = 4,
                Stroke = new SolidColorBrush(Colors.DarkBlue)
            };
            Field.Children.Add(elem);
            if (detailHeight > detailWidth)
            {
                var elem1 = elem.CloneTurned();
                _sheet.DetailsUnpacked.Add(new Detail() { Height = detailWidth, Width = detailHeight, View = elem1 });
            }
            else
            {
                _sheet.DetailsUnpacked.Add(new Detail() { Height = detailHeight, Width = detailWidth, View = elem });
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SheetView.Children.Clear();
            
            
            uint sheetHeight = 0;
            uint sheetWidth = 0;
            if (!(UInt32.TryParse(SheetHeight.Text, out sheetHeight) && UInt32.TryParse(SheetHeight.Text, out sheetWidth)))
            {
                MessageBox.Show("Ширина и висота должны быть целыми числами!");
                return;
            }
            
            _sheet.Height = sheetHeight;
            _sheet.Width = sheetWidth;
            Field.Children.Clear();
            //Check if total area > sheetArea
            if (_sheet.DetailsUnpacked.Sum(x => x.Area) > _sheet.Area)
            {
                MessageBox.Show("Невозможно расположить детали!");
                _sheet.DetailsUnpacked.Clear();
                return;
            }
            foreach (var detail in _sheet.DetailsUnpacked)
            {
                if (detail.Width > sheetWidth || detail.Height > sheetHeight)
                {
                    MessageBox.Show("Невозможно расположить детали!");
                    _sheet.DetailsUnpacked.Clear();
                    return;
                }
            }
            var detailsPacked = BrukeAlgoritm.Bruke(_sheet);
            if (detailsPacked == null)
            {
                MessageBox.Show("Невозможно расположить детали!");
                _sheet.DetailsUnpacked.Clear();
                return;
            }
            _sheet.DetailsUnpacked.Clear();
            foreach(var detail in detailsPacked)
            {
               
                SheetView.Children.Add(new Rectangle() {
                    Width = detail.View.Width,
                    Height = detail.View.Height,
                    Fill = detail.View.Fill,
                   
                    StrokeThickness = detail.View.StrokeThickness,
                    Stroke = detail.View.Stroke,
                    Margin = detail.View.Margin
                });
            }
            

        }

        private void SheetBorder_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SheetView.Children.Clear();
        }

        
    }
}
