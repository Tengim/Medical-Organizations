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
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MedicalOrganizations
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool IsAdmin;
		Hospitals HospitalWindow;
		Doctors DoctorWindow;
		Patcients PatcientWindow;
		Quers QuerWindow;
		public MainWindow()
		{
			LoginWindow logwin = new LoginWindow();
			logwin.ShowDialog();
			if(logwin.IsAuthenticated)
			{
				InitializeComponent();
				IsAdmin = logwin.isAdmin;
				WindowStartupLocation = WindowStartupLocation.CenterScreen;
				HospitalWindow = new Hospitals(IsAdmin);
				DoctorWindow = new Doctors(IsAdmin);
				PatcientWindow = new Patcients(IsAdmin);
				QuerWindow = new Quers();
				ContentControl.Content = HospitalWindow;
			}
			else
			{
				Close();
			}
		}
		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			Button1.Style = (Style)Application.Current.FindResource("CustomButtonActiveStyle");
			Button2.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button3.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button4.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			ContentControl.Content = HospitalWindow;
		}
		private void Button2_Click(object sender, RoutedEventArgs e)
		{
			Button1.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button2.Style = (Style)Application.Current.FindResource("CustomButtonActiveStyle");
			Button3.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button4.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			ContentControl.Content = DoctorWindow;
		}
		private void Button3_Click(object sender, RoutedEventArgs e)
		{
			Button1.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button2.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button3.Style = (Style)Application.Current.FindResource("CustomButtonActiveStyle");
			Button4.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			ContentControl.Content = PatcientWindow;
		}

		private void Button4_Click(object sender, RoutedEventArgs e)
		{
			Button1.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button2.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button3.Style = (Style)Application.Current.FindResource("CustomButtonStyle");
			Button4.Style = (Style)Application.Current.FindResource("CustomButtonActiveStyle");
			ContentControl.Content = QuerWindow;
		}
	}
}
