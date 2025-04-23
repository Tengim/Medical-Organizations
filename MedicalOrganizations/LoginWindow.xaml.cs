using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
	/// Логика взаимодействия для LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public bool IsAuthenticated { get; private set; }
		public bool isAdmin;

		public LoginWindow()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string username = Login.Text;
			string password = Password.Password;

			using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-S6TMSJN\SQLEXPRESS; Initial Catalog=MedicalOrganizations; Integrated Security=True"))
			{
				connection.Open();
				string query = "SELECT * FROM Users WHERE userlogin = @Username AND password = @Password";

				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Username", username);
					command.Parameters.AddWithValue("@Password", password);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							isAdmin = (bool)reader["AdministratorRights"];

							IsAuthenticated = true;
							Close();
						}
						else
						{
							MessageBox.Show("Неверные учетные данные. Попробуйте снова.");
							IsAuthenticated = false;
						}
					}
				}
			}
		}
	}
}
