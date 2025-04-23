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
	/// Логика взаимодействия для Patcients.xaml
	/// </summary>
	public partial class Patcients : UserControl
	{
		private readonly DatabaseManager dbManager;

		public Patcients(bool IsAdmin)
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
			dbManager = new DatabaseManager(@"Data Source=DESKTOP-S6TMSJN\SQLEXPRESS; Initial Catalog=MedicalOrganizations; Integrated Security=True");
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				PatcientDataGrid.ItemsSource = dbManager.Query("SELECT Karta.id, Patcient.Name AS PName, Bolezn.Name AS Bolezn, Doctor.Name AS DName, Karta.Vrema_Postuplenia FROM Karta JOIN Patcient ON Karta.IdPatcient = Patcient.Id JOIN Bolezn ON Karta.IdBolezni = Bolezn.Id JOIN Doctor ON Karta.IdDoctor = Doctor.Id;").DefaultView;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				MessageBox.Show(ex.Message);
			}
		}

		private void Insert(object sender, RoutedEventArgs e)
		{
			PatcientInsert PInsert = new PatcientInsert();
			PInsert.Title = "Добавление";
			PInsert.ShowDialog();
			if (PInsert.Save)
			{
				dbManager.GetForeinKey("Patcient","Name", PInsert.NamePatcientText);
				dbManager.Query($"Insert Into Karta values(\'{PInsert.VremaPText}\',{dbManager.GetForeinKey("Bolezn", "Name", PInsert.BoleznText)},{dbManager.GetForeinKey("Patcient", "Name", PInsert.NamePatcientText)},{dbManager.GetForeinKey("Doctor", "Name", PInsert.DoctorText)})");
			}
			LoadData();
		}

		private void Delete(object sender, RoutedEventArgs e)
		{
			var selectedItems = PatcientDataGrid.SelectedItems;
			if (selectedItems.Count == 0)
			{
				MessageBox.Show("Вы не выбрали ни одной записи.", "Удаление");
				return;
			}
			if (!dbManager.ShowYesNoMessageBox("Удаление", "Вы уверены что хотите удалить (" + selectedItems.Count.ToString() + ") записей?"))
			{
				LoadData();
				return;
			}
			List<int> PatcientsToDelete = new List<int>();

			foreach (var selectedItem in selectedItems)
			{
				if (selectedItem is DataRowView rowView)
				{
					DataRow row = rowView.Row;
					if (row.Table.Columns.Contains("id"))
					{
						int KartaId = Convert.ToInt32(row["id"]);
						PatcientsToDelete.Add(KartaId);
					}
				}
			}
			foreach (int KartaId in PatcientsToDelete)
			{
				try
				{
					DataRowView row = (DataRowView)selectedItems[0];
					dbManager.DeleteRecord("Karta", KartaId);
					LoadData();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void Update(object sender, RoutedEventArgs e)
		{
			var selectedItems = PatcientDataGrid.SelectedItems;
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
			PatcientInsert PInsert = new PatcientInsert();
			PInsert.Title = "Изменение";
			PInsert.Name.Text = Row["PName"].ToString();
			PInsert.Bolezn.Text = Row["Bolezn"].ToString();
			PInsert.Doctor.Text = Row["DName"].ToString();
			PInsert.Vrema_P.Text = Row["Vrema_Postuplenia"].ToString();
			PInsert.ShowDialog();
			if (PInsert.Save)
			{
				dbManager.Query($"Update Patcient SET Name = \'{PInsert.NamePatcientText}\' WHERE id = {dbManager.GetForeinKey("Patcient", "Name", PInsert.NamePatcientText)}");
				dbManager.Query($"Update Karta SET Vrema_Postuplenia = \'{PInsert.VremaPText}\', IdBolezni = {dbManager.GetForeinKey("Bolezn", "Name", PInsert.BoleznText)},IdPatcient = {dbManager.GetForeinKey("Patcient", "Name", PInsert.NamePatcientText)}, IdDoctor = {dbManager.GetForeinKey("Doctor", "Name", PInsert.DoctorText)} WHERE id = {Row["id"].ToString()}");
			}
			LoadData();
		}
	}
}