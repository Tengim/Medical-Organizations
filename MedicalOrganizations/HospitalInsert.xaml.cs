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
    /// Логика взаимодействия для HospitalInsert.xaml
    /// </summary>
    public partial class HospitalInsert : Window
    {
		DatabaseManager dbManager;
		public string NameText;
		public string AdressText;
		public bool Save;
		public HospitalInsert()
		{
			InitializeComponent();
			dbManager = new DatabaseManager(@"Data Source=DESKTOP-S6TMSJN\SQLEXPRESS; Initial Catalog=MedicalOrganizations; Integrated Security=True");
		}

		private void Accept(object sender, RoutedEventArgs e)
		{
			if(Name.Text.Length == 0 || Adress.Text.Length == 0)
			{
				MessageBox.Show("Заполните все поля.");
				return;
			}
			Save = true;
			NameText = Name.Text;
			AdressText = Adress.Text;
			Close();
		}

		private void Canel(object sender, RoutedEventArgs e)
		{
			Save = false;
			Close();
		}
    }
}
