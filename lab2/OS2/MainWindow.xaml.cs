using System;
using System.Collections.Generic;
using System.Configuration;
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
using OS2.source;

namespace OS2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.TextBox1.Text = AppSetting.Default.WorkCollection.ToString();
			this.TextBox2.Text = AppSetting.Default.VirtualMemory.ToString();
			this.TextBox3.Text = AppSetting.Default.PhysicMemory.ToString();
			this.TextBox4.Text = AppSetting.Default.GenerateProcessTimeLimit.ToString();
			this.TextBox5.Text = AppSetting.Default.ReadDataTimeLimit.ToString();
			this.TextBox6.Text = AppSetting.Default.ProcessExpirationTimeLimit.ToString();
			this.TextBox7.Text = AppSetting.Default.SimulationTimeLimit.ToString();
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			AppSetting.Default.WorkCollection = int.Parse(this.TextBox1.Text);
			AppSetting.Default.VirtualMemory = int.Parse(this.TextBox2.Text);
			AppSetting.Default.PhysicMemory = int.Parse(this.TextBox3.Text);
			AppSetting.Default.GenerateProcessTimeLimit = int.Parse(this.TextBox4.Text);
			AppSetting.Default.ReadDataTimeLimit = int.Parse(this.TextBox5.Text);
			AppSetting.Default.ProcessExpirationTimeLimit = int.Parse(this.TextBox6.Text);
			AppSetting.Default.SimulationTimeLimit = int.Parse(this.TextBox7.Text);
			AppSetting.Default.Save();
			source.OperatingSystem os = new source.OperatingSystem();
			Log logwindow = new Log();
			logwindow.Show();
		}

		private void EndButton_Click(object sender, RoutedEventArgs e)
		{
			AppSetting.Default.WorkCollection = int.Parse(this.TextBox1.Text);
			AppSetting.Default.VirtualMemory = int.Parse(this.TextBox2.Text);
			AppSetting.Default.PhysicMemory = int.Parse(this.TextBox3.Text);
			AppSetting.Default.GenerateProcessTimeLimit = int.Parse(this.TextBox4.Text);
			AppSetting.Default.ReadDataTimeLimit = int.Parse(this.TextBox5.Text);
			AppSetting.Default.ProcessExpirationTimeLimit = int.Parse(this.TextBox6.Text);
			AppSetting.Default.SimulationTimeLimit = int.Parse(this.TextBox7.Text);
			AppSetting.Default.Save();
		}
	}
}
