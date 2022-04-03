using System.Windows;
using System.Windows.Input;
using System.Windows.Documents;

namespace DQ8
{
	/// <summary>
    /// AboutWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class AboutWindow : Window
	{
		public AboutWindow()
		{
			InitializeComponent();
		}

		private void LabelHP_MouseDown(object sender, MouseButtonEventArgs e)
		{
			System.Diagnostics.Process.Start("http://turtleinsect.php.xdomain.jp/");
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			Hyperlink hyperlink = sender as Hyperlink;

			if (hyperlink != null && hyperlink.NavigateUri != null && hyperlink.NavigateUri.ToString() != "")
			{
				string target = hyperlink.NavigateUri.ToString();

				System.Diagnostics.Process.Start(target);
			}
		}
	}
}
