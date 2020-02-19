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
using System.Windows.Shapes;
using System.Drawing;

using ColorD = System.Drawing.Color;
using ColorM = System.Windows.Media.Color;
using Brush = System.Windows.Media.Brush;

namespace WpfApp1
{
	/// <summary>
	/// Logique d'interaction pour ColorPalette.xaml
	/// </summary>
	public partial class ColorPalette : Window
	{
		Button but;
		ColorD colord;
		SolidColorBrush lineColor;


		public ColorPalette(ref SolidColorBrush lineColor, ref Button cButton)
		{
			InitializeComponent();

			this.lineColor = lineColor;
			this.but = cButton;
		}

		private void imageBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Bitmap bitmap = new Bitmap(Properties.Resources.Palette);

			System.Windows.Point p = Mouse.GetPosition(imageBox);
			p.X += (bitmap.Width - imageBox.Width) / 2;
			p.Y += (bitmap.Height - imageBox.Height) / 2;

			colord = bitmap.GetPixel(Convert.ToInt32(Math.Round(p.X)), Convert.ToInt32(Math.Round(p.Y)));
			ColorM colorm = ToMediaColor(colord);

			CouleurProTxt.Background = new SolidColorBrush(colorm);
			CouleurProTxt.Text = "#" + colord.R.ToString("X2") + colord.G.ToString("X2") + colord.B.ToString("X2");	
		}

		public static ColorM ToMediaColor(ColorD color)
		{
			return ColorM.FromArgb(color.A, color.R, color.G, color.B);
		}

		public static ColorM InterpolateColors(ColorM color1, ColorM color2, float percentage)
		{
			double a1 = color1.A / 255.0, r1 = color1.R / 255.0, g1 = color1.G / 255.0, b1 = color1.B / 255.0;
			double a2 = color2.A / 255.0, r2 = color2.R / 255.0, g2 = color2.G / 255.0, b2 = color2.B / 255.0;

			byte a3 = Convert.ToByte((a1 + (a2 - a1) * percentage) * 255);
			byte r3 = Convert.ToByte((r1 + (r2 - r1) * percentage) * 255);
			byte g3 = Convert.ToByte((g1 + (g2 - g1) * percentage) * 255);
			byte b3 = Convert.ToByte((b1 + (b2 - b1) * percentage) * 255);

			return ColorM.FromArgb(a3, r3, g3, b3);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SolidColorBrush d = new SolidColorBrush(ToMediaColor(colord));
			ColorM c = InterpolateColors(d.Color, Colors.Black, 0.2f);
			lineColor.Color = c;
			but.Background = d;
			
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			ColorM c = new ColorM();
			c = Colors.Black;
			lineColor.Color = c;
			CouleurProTxt.Background = new SolidColorBrush(Colors.Black);

			this.Close();
		}
	}
}
