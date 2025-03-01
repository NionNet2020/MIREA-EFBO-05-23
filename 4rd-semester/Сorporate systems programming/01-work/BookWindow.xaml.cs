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

    public partial class BookWindow : Window
    {
        private Book newbook;
        private List<Author> newauthors;
        private List<Genre> newgenres;
        public BookWindow(Book book)
        {


            InitializeComponent();
            newbook = book ?? new Book();

            LoadAuthorsAndGenres();

            DataContext = newbook;

            if (newbook.Author != null)
                Authorbox.Text = newbook.Author.LastName;
            if (newbook.Genre != null)
                Genrebox.Text = newbook.Genre.Name;

            NameBbox.Text = newbook.Title;
            Publishbox.Text = newbook.PublishYear.ToString();
            ISBNbox.Text = newbook.ISBN;
            Quantitybox.Text = newbook.QuantityInStock.ToString();

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string authorLastName = Authorbox.Text.Trim();
            string genreName = Genrebox.Text.Trim();

            // Ищем автора по фамилии в загруженном списке
            var foundAuthor = newauthors.FirstOrDefault(a =>
                a.LastName.Equals(authorLastName, StringComparison.OrdinalIgnoreCase));
            if (foundAuthor == null)
            {
                MessageBox.Show("Автор с такой фамилией не найден!");
                return;
            }

            // Ищем жанр по названию в загруженном списке
            var foundGenre = newgenres.FirstOrDefault(g =>
                g.Name.Equals(genreName, StringComparison.OrdinalIgnoreCase));
            if (foundGenre == null)
            {
                MessageBox.Show("Жанр с таким названием не найден!");
                return;
            }

            using (var db = new DataContext())
            {
                if (newbook != null)
                {
                    
                    newbook.Title = NameBbox.Text;

                    
                    newbook.Author = foundAuthor;
                    newbook.AuthorId = foundAuthor.Id;
                    newbook.Genre = foundGenre;
                    newbook.GenreId = foundGenre.Id;

                    newbook.PublishYear = Convert.ToInt32(Publishbox.Text);
                    newbook.ISBN = ISBNbox.Text;
                    newbook.QuantityInStock = Convert.ToInt32(Quantitybox.Text);

                    
                    db.Books.Update(newbook);
                    db.SaveChanges();
                }
            }

            this.DialogResult = true;
            this.Close(); 

        }
        private void LoadAuthorsAndGenres()
        {
            using (var db = new DataContext())
            {
                newauthors = db.Authors.ToList();
                newgenres = db.Genres.ToList();
            }
        }
    }

}
