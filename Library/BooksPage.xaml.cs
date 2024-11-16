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

namespace Library
{
    /// <summary>
    /// Interaction logic for BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        LibraryEntities db = new LibraryEntities();
        public BooksPage(ComboBox combobox)
        {
            InitializeComponent();
            Book book = new Book();
           Category category = new Category();
            category = db.Categories.FirstOrDefault(x => x.CategoryName == combobox.Text);
            if (category != null)
            {
                var books = db.Books.Where(x => x.CategoryID == category.CategoryID)
                    .Select(b => new
                             {
                                 b.BookID,
                                 b.BookName,
                                 b.BookAuthor,
                                 b.CategoryID,
                                 CategoryName = b.Category.CategoryName 
                             }).ToList();
                dg.ItemsSource = books;
            }

    
        }


    }
}
