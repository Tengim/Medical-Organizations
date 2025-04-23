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
    /// Логика взаимодействия для Hospitals.xaml
    /// </summary>
    public partial class Hospitals : UserControl
    {
		private readonly DatabaseManager databaseManager;
		public Hospitals(bool IsAdmin)
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
				HospitalDataGrid.ItemsSource = databaseManager.Query("SELECT * FROM Hospital").DefaultView;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				MessageBox.Show(ex.Message);
			}
		}

		private void Insert(object sender, RoutedEventArgs e)
		{
			HospitalInsert HInsert = new HospitalInsert();
			HInsert.Title = "Добавление";
			HInsert.ShowDialog();
			if (HInsert.Save)
			{
				databaseManager.Query("Insert Into Hospital values (\'" + HInsert.NameText + "\', \'" + HInsert.AdressText + "\')");
			}
			LoadData();
		}

		private void Delete(object sender, RoutedEventArgs e)
		{
			var selectedItems = HospitalDataGrid.SelectedItems;
			if (selectedItems.Count == 0)
			{
				MessageBox.Show("Вы не выбрали ни одной записи.", "Удаление");
				return;
			}
			if (!databaseManager.ShowYesNoMessageBox("Удаление", "Вы уверены что хотите удалить (" + selectedItems.Count.ToString() + ") записей?"))
			{
				LoadData();
				return;
			}
			List<int> HospitalsToDelete = new List<int>();

			foreach (var selectedItem in selectedItems)
			{
				if (selectedItem is DataRowView rowView)
				{
					DataRow row = rowView.Row;
					if (row.Table.Columns.Contains("id"))
					{
						int HospitalId = Convert.ToInt32(row["id"]);
						HospitalsToDelete.Add(HospitalId);
					}
				}
			}
			foreach (int HospitalId in HospitalsToDelete)
			{
				DeleteHospital(HospitalId);
			}
		}

		private void Update(object sender, RoutedEventArgs e)
		{
			var selectedItems = HospitalDataGrid.SelectedItems;
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
			HospitalInsert HInsert = new HospitalInsert();
			HInsert.Title = "Изменение";
			HInsert.Name.Text = Row["Name"].ToString();
			HInsert.Adress.Text = Row["Adress"].ToString();
			HInsert.ShowDialog();
			if (HInsert.Save)
			{
				databaseManager.Query("UPDATE Hospital set Name = \'" + HInsert.NameText + "\', Adress = \'" + HInsert.AdressText + "\' Where id = " + Row["id"]);
			}
			LoadData();
		}

		private void DeleteHospital(int HospitalId)
		{
			try
			{
				databaseManager.DeleteRecord("Hospital", HospitalId);
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
