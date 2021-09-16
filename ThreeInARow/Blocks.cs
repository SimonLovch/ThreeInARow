using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ThreeInARow
{
    public class Blocks
    {
        public enum Color
        {
            Red = 0,
            Orange,
            Yellow,
            Green,
            Blue,
            Purple
        }

        public enum TypeBlock
        {
            Usual = 0,
            Vertical,
            Horizontal,
            Bomb
        }

        public Color color;
        public TypeBlock type;
        public Image img;
        public int size;

        public Blocks(Blocks original)
        {
            color = original.color;
            type = original.type;
            img = original.img;
            size = original.size;
        }

        public void Change(Random rand, int colors = 5)
        {
            color = (Color) rand.Next(0, colors);
            type = TypeBlock.Usual;
            var path = @"pack://application:,,,/Resources/" + type.ToString("F") + "/" + color.ToString("F") + ".png";
            img.Source = new BitmapImage(new Uri(path));
        }

        public Blocks(Random rand, Canvas container, int row, int column, int size, int colors = 5)
        {
            color = (Color) rand.Next(0, colors);
            type = TypeBlock.Usual;
            var path = @"pack://application:,,,/Resources/" + type.ToString("F") + "/" + color.ToString("F") + ".png";
            this.size = size;
            img = new Image
            {
                Width = size,
                Height = size,
                Margin = new Thickness(0),
                Source = new BitmapImage(new Uri(path)),
                Stretch = Stretch.Fill,
            };
            img.MouseLeftButtonUp += ElementClicked;
            container.Children.Add(img);
            Canvas.SetLeft(img, size * column);
            Canvas.SetTop(img, size * row);
            Canvas.SetZIndex(img, 1);
        }

        public void ElementClicked(object sender, RoutedEventArgs e)
        {
            Animation.ResizeElement(sender, size);
        }

        public bool Compare(Blocks c)
        {
            return (this.color == c.color);
        }

        public bool IsHorizontal()
        {
            return this.type == TypeBlock.Horizontal;
        }

        public bool IsVertical()
        {
            return this.type == TypeBlock.Vertical;
        }

    }
}