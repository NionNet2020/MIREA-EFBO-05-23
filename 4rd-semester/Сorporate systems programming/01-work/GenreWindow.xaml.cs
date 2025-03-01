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

    public partial class GenreWindow : Window
    {
        private Genre newgenre;
        public GenreWindow(Genre genre)
        {
            InitializeComponent();

            newgenre = genre ?? new Genre();

            DataContext = newgenre;

            Namebox.Text = newgenre.Name;
            Descriptionbox.Text = newgenre.Description;
        }

        private void GenreButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DataContext())
            {
                newgenre.Name = Namebox.Text;
                newgenre.Description = Descriptionbox.Text;

                if (newgenre.Id == 0)
                {
                    db.Genres.Add(newgenre);
                }
                else
                {
                    db.Genres.Update(newgenre);
                }
                db.SaveChanges();
            }

            
            this.DialogResult = true;
        }


    }
}
