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

namespace WpfApp5
{
  
    public partial class UserWindow : Window
    {
        private Author newauthor;

        public UserWindow(Author author)
        {

            InitializeComponent();

            newauthor = author ?? new Author();

            DataContext = newauthor;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(LastName.Text) || string.IsNullOrWhiteSpace(Country.Text))
            {
                MessageBox.Show("Введите корректные данные!");
                return;
            }

            if (!DateOnly.TryParse(BirthDate.Text, out DateOnly parsedDate))
            {
                MessageBox.Show("Введите корректную дату!");
                return;
            }

            using (var db = new DataContext())
            {
                newauthor.FirstName = NameTextBox.Text;
                newauthor.LastName = LastName.Text;
                newauthor.BirthDate = parsedDate; 
                newauthor.Country = Country.Text;

                if (newauthor.Id == 0)
                {
                    db.Authors.Add(newauthor);
                }
                else
                {
                    db.Authors.Update(newauthor);
                }
                db.SaveChanges();
            }

            this.DialogResult = true;
        }


    }
}
