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
    /// Логика взаимодействия для DoctorInsert.xaml
    /// </summary>
    public partial class DoctorInsert : Window
    {
		DatabaseManager dbManager;
		public string NameText;
		public string SpecializationText;
		public string DegreeText;
		public bool Save;
		public DoctorInsert()
        {
            InitializeComponent();
			dbManager = new DatabaseManager(@"Data Source=DESKTOP-S6TMSJN\SQLEXPRESS; Initial Catalog=MedicalOrganizations; Integrated Security=True");
			dbManager.FillComboBox("Degree", "Name", Degree);
		}

		private void Accept(object sender, RoutedEventArgs e)
		{
			if (Name.Text.Length == 0 || Specialization.Text.Length == 0 || Degree.Text.Length == 0)
			{
				MessageBox.Show("Заполните все поля.");
				return;
			}
			Save = true;
			NameText = Name.Text;
			SpecializationText = Specialization.Text;
			DegreeText = Degree.Text;
			Close();
		}

		private void Canel(object sender, RoutedEventArgs e)
		{
			Save = false;
			Close();
		}
	}
}
