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

namespace MedicalOrganizations
{
	/// <summary>
	/// Логика взаимодействия для Quers.xaml
	/// </summary>
	public partial class Quers : UserControl
	{
		public DatabaseManager dbManager;
		public Quers()
		{
			InitializeComponent();
			dbManager = new DatabaseManager(@"Data Source=DESKTOP-S6TMSJN\SQLEXPRESS; Initial Catalog=MedicalOrganizations; Integrated Security=True");
			
			ChoseQuery.Items.Add(	"Получить перечень и общее число врачей указанного\n" +
									"профиля для конкретного медицинского учреждения,\n" +
									"больницы, либо поликлиники, либо всех медицинских\n" +
									"учреждений города.");

			ChoseQuery.Items.Add(	"Получить перечень и общее число врачей указанного\n" +
									"профиля со степенью кандидата или доктора медицинских\n" +
									"наук конкретного медицинского учреждения, либо больницы,\n" +
									"либо поликлиники, либо всех медицинских учреждений города");

			ChoseQuery.Items.Add(	"Получить перечень пациентов, наблюдающихся у врача\n" +
									"в конкретном медицинском учреждении");

			ChoseQuery.Items.Add(	"Вывести выработку врачей(пациенты в день)");

			ChoseQuery.Items.Add(	"Вывести загруженность врачей(пациенты на лечении)");
		}
		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (ChoseQuery.SelectedItem.ToString())
			{
				case "Получить перечень и общее число врачей указанного\nпрофиля для конкретного медицинского учреждения,\nбольницы, либо поликлиники, либо всех медицинских\nучреждений города.":
					if (Filter.Text != "")
					{
						QueryDataGrid.ItemsSource = dbManager.Query("SELECT Doctor.Name AS Доктор, Doctor.Specialization AS Специализация, Degree.Name AS Ученая_степень FROM Doctor JOIN Degree ON Doctor.Degree = Degree.id LEFT JOIN DoctorH ON Doctor.id = DoctorH.idDoctor LEFT JOIN Hospital ON DoctorH.idHospital = Hospital.id WHERE Hospital.Name = \'" + Filter.Text + "\'").DefaultView;
					}
					else
					{
						QueryDataGrid.ItemsSource = dbManager.Query("SELECT Doctor.Name AS Доктор, Doctor.Specialization AS Специализация, Degree.Name AS Ученая_степень, Hospital.Name AS Больница, Policlinic.Name AS Поликлиника FROM Doctor JOIN Degree ON Doctor.Degree = Degree.id LEFT JOIN DoctorH ON Doctor.id = DoctorH.idDoctor LEFT JOIN Hospital ON DoctorH.idHospital = Hospital.id LEFT JOIN DoctorP ON Doctor.id = DoctorP.idDoctor LEFT JOIN Policlinic ON DoctorP.idPoliclinic = Policlinic.id;").DefaultView;
					}
					break;
				case "Получить перечень и общее число врачей указанного\nпрофиля со степенью кандидата или доктора медицинских\nнаук конкретного медицинского учреждения, либо больницы,\nлибо поликлиники, либо всех медицинских учреждений города":
					if (Filter.Text != "")
					{
						QueryDataGrid.ItemsSource = dbManager.Query("SELECT Doctor.Name AS Доктор, Doctor.Specialization AS Специализация, Degree.Name AS Ученая_степень, COUNT(Doctor.id) AS Количество_врачей FROM Doctor JOIN Degree ON Doctor.Degree = Degree.id LEFT JOIN DoctorH ON Doctor.id = DoctorH.idDoctor LEFT JOIN Hospital ON DoctorH.idHospital = Hospital.id LEFT JOIN DoctorP ON Doctor.id = DoctorP.idDoctor LEFT JOIN Policlinic ON DoctorP.idPoliclinic = Policlinic.id WHERE Hospital.Name = '" + Filter.Text + "' OR Policlinic.Name = '" + Filter.Text + "' GROUP BY Doctor.Name, Doctor.Specialization, Degree.Name;").DefaultView;
					}
					else
					{
						QueryDataGrid.ItemsSource = dbManager.Query("SELECT Doctor.Name AS Доктор, Doctor.Specialization AS Специализация, Degree.Name AS Ученая_степень, Hospital.Name AS Больница, Policlinic.Name AS Поликлиника FROM Doctor JOIN Degree ON Doctor.Degree = Degree.id LEFT JOIN DoctorH ON Doctor.id = DoctorH.idDoctor LEFT JOIN Hospital ON DoctorH.idHospital = Hospital.id LEFT JOIN DoctorP ON Doctor.id = DoctorP.idDoctor LEFT JOIN Policlinic ON DoctorP.idPoliclinic = Policlinic.id;").DefaultView;
					}
					break;
				case "Получить перечень пациентов, наблюдающихся у врача\nв конкретном медицинском учреждении":
					QueryDataGrid.ItemsSource = dbManager.Query("SELECT Patcient.Name AS Пациент, Doctor.Name AS Врач, Hospital.Name AS Больница, Policlinic.Name AS Поликлиника FROM Karta JOIN Doctor ON Karta.IdDoctor = Doctor.id JOIN Patcient ON Karta.IdPatcient = Patcient.id LEFT JOIN DoctorH ON Doctor.id = DoctorH.idDoctor LEFT JOIN Hospital ON DoctorH.idHospital = Hospital.id LEFT JOIN DoctorP ON Doctor.id = DoctorP.idDoctor LEFT JOIN Policlinic ON DoctorP.idPoliclinic = Policlinic.id WHERE Hospital.Name = 'Название_учреждения' OR Policlinic.Name = '" + Filter.Text + "';").DefaultView;
					break;
				case "Вывести загруженность врачей(пациенты на лечении)":
					QueryDataGrid.ItemsSource = dbManager.Query("SELECT Doctor.Name AS Доктор, Doctor.Specialization AS Специализация, Degree.Name AS Ученая_Cтепень, (SELECT COUNT(*) FROM Karta Where Doctor.id = Karta.IdDoctor) AS Загруженность FROM Doctor JOIN Degree ON Doctor.Degree = Degree.id").DefaultView;
					break;
				case "Вывести выработку врачей(пациенты в день)":
					QueryDataGrid.ItemsSource = dbManager.Query("SELECT Doctor.Name AS Доктор, Karta.Vrema_Postuplenia AS Дата, SUM(1) AS Пациент FROM Karta JOIN Doctor ON Karta.IdDoctor = Doctor.Id GROUP BY Karta.Vrema_Postuplenia, Doctor.Name ORDER BY Karta.Vrema_Postuplenia;").DefaultView;
					break;
			}
		}
	}
}
