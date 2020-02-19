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

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int nb = 0;
		List<Line> myLines = new List<Line>();
		SolidColorBrush linecolor = new SolidColorBrush(Colors.Black);

		private void Canvas_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Point p = Mouse.GetPosition(Canvas_1);
			//p.X += Canvas_1.;
			//p.Y += Canvas_1.Height / 2;

			int precision = (int)slider.Value;

			int isClose = 0;
			int nbLines = myLines.Count - 1;

			if (nbLines < 0) nbLines = 0;

			txt.Text = p.ToString() + "   " + precision;

			if (nb == 0)
			{
				Line temp = new Line
				{
					StrokeThickness = 1.5,
					Stroke = new SolidColorBrush(linecolor.Color),
					SnapsToDevicePixels = true
				};

				temp.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

				if ((isClose = IsPointCloseToAnotherOne(p.X, p.Y, precision)) > -1)
				{
					if (WhichPointIsClose(p.X, p.Y, myLines[isClose], precision) == 1)
					{
						txt.Text = myLines[isClose].X1.ToString() + myLines[isClose].Y1.ToString();

						temp.X1 = myLines[isClose].X1;
						temp.Y1 = myLines[isClose].Y1;
					}
					else
					if (WhichPointIsClose(p.X, p.Y, myLines[isClose], precision) == 2)
					{
						temp.X1 = myLines[isClose].X2;
						temp.Y1 = myLines[isClose].Y2;
					}
				}
				else
				{
					temp.X1 = p.X;
					temp.Y1 = p.Y;
				}

				myLines.Add(temp);
				nb++;
			}
			else
			{
				if((isClose = IsPointCloseToAnotherOne(p.X, p.Y, precision)) > -1)
				{
					if (WhichPointIsClose(p.X, p.Y, myLines[isClose], precision) == 1)
					{
						txt.Text = myLines[isClose].X1.ToString() + myLines[isClose].Y1.ToString();

						myLines[nbLines].X2 = myLines[isClose].X1;
						myLines[nbLines].Y2 = myLines[isClose].Y1;
					}
					else
					if (WhichPointIsClose(p.X, p.Y, myLines[isClose], precision) == 2)
					{
						myLines[nbLines].X2 = myLines[isClose].X2;
						myLines[nbLines].Y2 = myLines[isClose].Y2;
					}

				}
				else
				{
					myLines[nbLines].X2 = p.X;
					myLines[nbLines].Y2 = p.Y;

				}
				
				Canvas_1.Children.Add(myLines[nbLines]);
				listBox.Items.Add(nbLines + ": " + "(" + myLines[nbLines].X1 + "," + myLines[nbLines].Y1 + ")" + "\n" + "(" + myLines[nbLines].X2 + "," + myLines[nbLines].Y2 + ")");
				//linecolor.Color = Colors.Black;
				nb = 0;
			}
		}

		private void Canvas_1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (nb == 0)
			{
				int i = myLines.Count - 1;
				if (i >= 0)
				{
					Canvas_1.Children.Remove(myLines[i]);
					listBox.Items.RemoveAt(i);
					myLines.RemoveAt(i);
				}
			}
		}

		//								FONCTIONS
		private int IsPointCloseToAnotherOne(double x, double y, int precision)
		{
			if(myLines.Count > 1)
				for (int i = 0; i < myLines.Count; i++)
				{
					if (((myLines[i].X1 + precision >= x && myLines[i].X1 - precision <= x) && (myLines[i].Y1 + precision >= y && myLines[i].Y1 - precision <= y)) ||
						((myLines[i].X2 + precision >= x && myLines[i].X2 - precision <= x) && (myLines[i].Y2 + precision >= y && myLines[i].Y2 - precision <= y)))
							return i;
				}

			return -1;
		}

		private int WhichPointIsClose(double x, double y, Line line, int precision)
		{
			if (((line.X1 + precision >= x && line.X1 - precision <= x) && (line.Y1 + precision >= y && line.Y1 - precision <= y))) return 1;
			if (((line.X2 + precision >= x && line.X2 - precision <= x) && (line.Y2 + precision >= y && line.Y2 - precision <= y))) return 2;

			return -1;
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			TextScroll.Text = "" + slider.Value;
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			new ColorPalette(ref linecolor, ref ColorPalette).Show();
		}
	}
}
