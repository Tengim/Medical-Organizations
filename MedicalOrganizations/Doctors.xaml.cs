using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
	/// Логика взаимодействия для Doctors.xaml
	/// </summary>
	public partial class Doctors : UserControl
	{
		private readonly DatabaseManager databaseManager;

		public Doctors(bool IsAdmin)
		{
			InitializeComponent();
			if (!IsAdmin)
			{
				Grid parentGrid = ButtonRow.Parent as Grid;
				parentGrid.RowDefinitions.Remove(ButtonRow);
				Add.IsEnabled = false;
				Del.IsEnabled = false;
				Upd.IsEnabled = false;
			}
			databaseManager = new DatabaseManager(@"Data Source=DESKTOP-S6TMSJN\SQLEXPRESS; Initial Catalog=MedicalOrganizations; Integrated Security=True");
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				DoctorDataGrid.ItemsSource = databaseManager.Query("SELECT Doctor.id, Doctor.Name, Doctor.Specialization, Degree.Name AS Degree, Hospital.Name AS Hospital, Policlinic.Name AS Policlinic FROM Doctor JOIN Degree ON Doctor.Degree = Degree.id LEFT JOIN DoctorH ON Doctor.id = DoctorH.idDoctor LEFT JOIN Hospital ON DoctorH.idHospital = Hospital.id LEFT JOIN DoctorP ON Doctor.id = DoctorP.idDoctor LEFT JOIN Policlinic ON DoctorP.idPoliclinic = Policlinic.id;").DefaultView;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				MessageBox.Show(ex.Message);
			}
		}
		
		private void Insert(object sender, RoutedEventArgs e)
		{
			DoctorInsert DInsert = new DoctorInsert();
			DInsert.ShowDialog();
			if (DInsert.Save){
				databaseManager.Query("Insert Into Doctor values (\'" + DInsert.NameText + "\', \'" + DInsert.SpecializationText + "\', " + databaseManager.GetForeinKey("Degree","Name", DInsert.DegreeText) + ")");
			}
			LoadData();
		}

		private void Delete(object sender, RoutedEventArgs e)
		{
			var selectedItems = DoctorDataGrid.SelectedItems;
			if(selectedItems.Count == 0)
			{
				MessageBox.Show("Вы не выбрали ни одной записи.", "Удаление");
				return;
			}
			if (!databaseManager.ShowYesNoMessageBox("Удаление", "Вы уверены что хотите удалить (" + selectedItems.Count.ToString() + ") записей?"))
			{
				LoadData();
				return;
			}
			List<int> doctorsToDelete = new List<int>();

			foreach (var selectedItem in selectedItems)
			{
				if (selectedItem is DataRowView rowView)
				{
					DataRow row = rowView.Row;
					if (row.Table.Columns.Contains("id"))
					{
						int doctorId = Convert.ToInt32(row["id"]);
						doctorsToDelete.Add(doctorId);
					}
				}
			}
			foreach (int doctorId in doctorsToDelete)
			{
				DeleteDoctor(doctorId);
			}
		}

		private void Update(object sender, RoutedEventArgs e)
		{
			var selectedItems = DoctorDataGrid.SelectedItems;
			if (selectedItems.Count > 1)
			{
				MessageBox.Show("Вы не можете выбрать больше одной записи на изменение.", "Изменение");
				return;
			}
			else if (selectedItems.Count == 0)
			{
				MessageBox.Show("Выберите изменяемый элемент.", "Изменение");
				return;
			}
			DataRowView Row = (DataRowView)selectedItems[0];
			DoctorInsert DInsert = new DoctorInsert();
			DInsert.Title = "Изменение";
			DInsert.Name.Text = Row["Name"].ToString();
			DInsert.Specialization.Text = Row["Specialization"].ToString();
			DInsert.Degree.Text = Row["Degree"].ToString();
			DInsert.ShowDialog();
			if (DInsert.Save)
			{
				databaseManager.Query("UPDATE Doctor set Name = \'" + DInsert.NameText + "\', Specialization = \'" + DInsert.SpecializationText + "\', Degree = " + databaseManager.GetForeinKey("Degree", "Name", DInsert.DegreeText) + "Where id = " + Row["id"]);
			}
			LoadData();
		}

		private void DeleteDoctor(int doctorId)
		{
			try
			{
				databaseManager.DeleteRecord("Doctor", doctorId);
				LoadData();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				MessageBox.Show(ex.Message);
			}
		}
	}
}