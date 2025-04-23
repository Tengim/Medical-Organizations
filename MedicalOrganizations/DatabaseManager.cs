using System;
using System.Windows;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Linq;

namespace MedicalOrganizations
{
	public class DatabaseManager
	{
		private readonly string connStr;

		public DatabaseManager(string connectionString)
		{
			connStr = connectionString;
		}

		public DataTable Query(string Query)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				try
				{
					conn.Open();
					string selectSql = Query;
					SqlCommand selectCmd = new SqlCommand(selectSql, conn);
					SqlDataAdapter da = new SqlDataAdapter(selectCmd);

					DataTable dt = new DataTable();
					da.Fill(dt);
					return dt;
				}																																									
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					throw new Exception($"Ошибка при выполнении запроса {Query}: {ex.Message}");
				}
			}
		}

		public void DeleteRecord(string tableName, int recordId)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					conn.Open();
					string deleteSql = $"DELETE FROM {tableName} WHERE id = {recordId}";
					SqlCommand deleteCmd = new SqlCommand(deleteSql, conn);
					deleteCmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				throw new Exception($"Ошибка при удалении записи из таблицы {tableName}: {ex.Message}");
			}
		}

		public void UpdateRecord(string tableName, string values,int id)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					conn.Open();

					if (ShowYesNoMessageBox("Изменение", "Вы уверены что хотите изменить эту запись?"))
					{
						string updateSql = $"UPDATE {tableName} SET {values} WHERE id = {id}";
						SqlCommand updateCmd = new SqlCommand(updateSql, conn);
						updateCmd.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				throw new Exception($"Ошибка при обновлении записи в таблице {tableName}: {ex.Message}");
			}
		}

		public void FillComboBox(string tableName,string column, ComboBox combo)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connStr))
				{
					connection.Open();

					string query = "SELECT " + column + " FROM " + tableName;
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								string value = reader[column].ToString();
								combo.Items.Add(value);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}
		public int GetForeinKey(string tableName, string column, string value)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					conn.Open();
					string GetNewValue = $"SELECT id FROM {tableName} WHERE {column} = '{value}'";
					using (SqlCommand command = new SqlCommand(GetNewValue, conn))
					{
						object result = command.ExecuteScalar();
						if (result != null)
						{
							//уже существует
							return (int)result;
						}
						else
						{
							//не существует, добавляем новую запись в таблицу Degree
							string insertDegreeQuery = $"INSERT INTO {tableName} ({column}) VALUES ('{value}'); SELECT SCOPE_IDENTITY();";

							using (SqlCommand insertCommand = new SqlCommand(insertDegreeQuery, conn))
							{
								return Convert.ToInt32(insertCommand.ExecuteScalar());
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				throw new Exception($"Ошибка при получении значения {value} из таблицы {tableName}: {ex.Message}");
			}
		}	
		public bool ShowYesNoMessageBox(string title, string question)
		{
			MessageBoxResult result = MessageBox.Show(question, title, MessageBoxButton.YesNo, MessageBoxImage.Question);

			if (result == MessageBoxResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}