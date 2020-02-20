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

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for LineProperties.xaml
	/// </summary>
	public partial class LineProperties : Window
	{
		Line l;

		public LineProperties(ref Line line, int index)
		{
			InitializeComponent();

			this.l = line;

			NameTxt.Text = index.ToString();
			P1Txt.Text = "(" + line.X1 + "," + line.Y1 + ")";
			P2Txt.Text = "(" + line.X2 + "," + line.Y2 + ")";
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			new ColorPalette(ref l, ref Button).Show();
		}

		private void CloseBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
