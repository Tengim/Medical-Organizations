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

namespace MedicalOrganizations
{
	/// <summary>
	/// Логика взаимодействия для PatcientInsert.xaml
	/// </summary>
	public partial class PatcientInsert : Window
	{
		DatabaseManager dbManager;
		public string NamePatcientText;
		public string BoleznText;
		public string VremaPText;
		public string DoctorText;
		public bool Save;
		public PatcientInsert()
		{
			InitializeComponent();
			dbManager = new DatabaseManager(@"Data Source=DESKTOP-S6TMSJN\SQLEXPRESS; Initial Catalog=MedicalOrganizations; Integrated Security=True");
			dbManager.FillComboBox("Bolezn", "Name", Bolezn);
			dbManager.FillComboBox("Doctor", "Name", Doctor);
		}
		private void Accept(object sender, RoutedEventArgs e)
		{
			if (Name.Text.Length == 0 || Bolezn.Text.Length == 0 || Vrema_P.Text.Length == 0 || Doctor.Text.Length == 0)
			{
				MessageBox.Show("Заполните все поля.");
				return;
			}
			Save = true;
			NamePatcientText = Name.Text;
			BoleznText = Bolezn.Text;
			VremaPText = Vrema_P.Text;
			DoctorText = Doctor.Text;
			Close();
		}

		private void Canel(object sender, RoutedEventArgs e)
		{
			Save = false;
			Close();
		}
	}
}
