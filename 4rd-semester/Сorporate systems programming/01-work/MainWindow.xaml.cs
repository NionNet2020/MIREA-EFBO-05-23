using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            InitializeComponent();

            

            LoadData();
        }

        private void LoadData()
        {
            using (DataContext db = new DataContext())
            {
                BookGrid.ItemsSource = db.Books.Include(b => b.Author).Include(b => b.Genre).ToList();
                GenreGrid.ItemsSource = db.Genres.ToList();
                myDataGrid.ItemsSource = db.Authors.ToList();
            }
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedAuthor = myDataGrid.SelectedItem as Author ?? new Author();
            var userwindow = new UserWindow(selectedAuthor);

            if (userwindow.ShowDialog() == true)
            {
                using (var db = new DataContext())
                {
                    if (selectedAuthor.Id == 0)
                    {
                        db.Authors.Add(selectedAuthor);
                    }
                    else
                    {
                        db.Authors.Update(selectedAuthor);
                    }
                    db.SaveChanges();
                }
                LoadData();
            }
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            var selectedGenre = GenreGrid.SelectedItem as Genre ?? new Genre();

            var genreWindow = new GenreWindow(selectedGenre);
            if (genreWindow.ShowDialog() == true)
            {
                using (var db = new DataContext())
                {
                    if (selectedGenre.Id == 0)
                    {
                        db.Genres.Add(selectedGenre);
                    }
                    else
                    {
                        db.Genres.Update(selectedGenre);
                    }
                    db.SaveChanges();
                }
                LoadData();
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var bookWindow = new BookWindow(new Book()); // Создаём новую книгу и передаём в окно
            if (bookWindow.ShowDialog() == true) // Открываем окно как диалоговое
            {
                LoadData(); // Загружаем обновлённые данные после закрытия окна
            }
        }


        private void Edit_book(object sender, RoutedEventArgs e)
        {
            var selectedBook = BookGrid.SelectedItem as Book;
            if (selectedBook != null)
            {
                var window = new BookWindow(selectedBook);
                if (window.ShowDialog() == true)
                {
                    using (var db = new DataContext())
                    {
                        db.Books.Update(selectedBook);
                        db.SaveChanges();
                    }
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для редактирования.");
            }

        }



        // Удалить автора
        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedAuthor = myDataGrid.SelectedItem as Author;
            using (DataContext db = new DataContext())
            {
                if (selectedAuthor != null)
                {
                    db.Authors.Remove(selectedAuthor);
                    db.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Выберите автора для удаления.");
                }
            }
        }

        private void DeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            var selectedGenre = GenreGrid.SelectedItem as Genre;
            using (DataContext db = new DataContext())
            {
                if (selectedGenre != null)
                {
                    db.Genres.Remove(selectedGenre);
                    db.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Выберите жанр для удаления.");
                }
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BookGrid.SelectedItem as Book;
            using (DataContext db = new DataContext())
            {
                if (selectedBook != null)
                {
                    db.Books.Remove(selectedBook);
                    db.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Выберите книгу для удаления.");
                }
            }
        }

        private void BookGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void FilterBooks_Click(object sender, RoutedEventArgs e)
        {
            if (FilterComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedFilter = selectedItem.Content.ToString();
                string filterText = FilterTextBox.Text.Trim();

                if (string.IsNullOrEmpty(filterText))
                {
                    MessageBox.Show("Введите значение для поиска!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var db = new DataContext())
                {
                    List<Book> filteredBooks = new List<Book>();

                    if (selectedFilter == "Автор")
                    {
                        filteredBooks = db.Books
                            .Include(b => b.Author)
                            .Include(b => b.Genre)
                            .Where(b => EF.Functions.ILike(b.Author.LastName, $"%{filterText}%"))
                            .ToList();
                    }
                    else if (selectedFilter == "Жанр")
                    {
                        filteredBooks = db.Books
                            .Include(b => b.Author)
                            .Include(b => b.Genre)
                            .Where(b => EF.Functions.ILike(b.Genre.Name, $"%{filterText}%"))
                            .ToList();
                    }
                    else if (selectedFilter == "Книга")
                    {
                        filteredBooks = db.Books
                            .Include(b => b.Author)
                            .Include(b => b.Genre)
                            .Where(b => EF.Functions.ILike(b.Title, $"%{filterText}%"))
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Выберите способ фильтрации (Автор, Жанр, Книга)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    BookGrid.ItemsSource = filteredBooks;
                }

            }
        }


        private void No_filter_Click(object sender, RoutedEventArgs e)
        {
            FilterTextBox.Text = ""; // Очищаем текстовое поле
            using (var db = new DataContext())
            {
                // Восстанавливаем полный список книг
                BookGrid.ItemsSource = db.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .ToList();
            }
        }


    }

}


