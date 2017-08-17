using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Configuration;
using System.Xml;

namespace PersonalLibrary
{
    public partial class BookGrid : Form
    {
        public BookGrid()
        {
            InitializeComponent();
            FillBookGrid();
            var create = CreateTable();
        }

        //Applies source to the book grid, sizes it properly, and refreshes the view
        public void FillBookGrid() {
            List<Book> books = GetAllBooks();

            var bindingList = new BindingList<Book>(books);
            var source = new BindingSource(bindingList, null);
            bookGridView.DataSource = source;
            bookGridView.Columns[0].Visible = false;

            //Handy method to dynamically resize the grid based on the amount of entries
            bookGridView.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };

            bookGridView.Refresh();
        }

        //Uses the ISBNDB API to find a book based on ISBN_10 or ISBN_13 value
        public Book GetBookData(string isbn) {
            Book book = new Book();
            string accessKey = ConfigurationManager.AppSettings["isbnKey"];
            string url = "http://isbndb.com/api/v2/json/" + accessKey + "/book/" + isbn;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            XmlTextReader reader = null;

            try
            {
                String ISBNUriStr = "http://isbndb.com//api/books.xml?access_key=" +
                accessKey + "&results=details&index1=isbn&value1=";

                Uri uri = null;

                if (isbn != null)
                {
                    uri = new Uri(ISBNUriStr + isbn);
                }

                WebRequest http = HttpWebRequest.Create(uri);

                HttpWebResponse response = (HttpWebResponse)http.GetResponse();
                Stream stream = response.GetResponseStream();

                reader = new XmlTextReader(stream);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        String name = reader.Name;
                        if (name == "BookData")
                        {
                            if (reader.MoveToFirstAttribute())
                            {
                                //book_id
                            }

                            while (reader.MoveToNextAttribute())
                            {
                                //isbn_10 and isbn_13

                                if (reader.Name == "isbn")
                                {
                                    book.Isbn_10 = reader.Value;
                                }
                                else if (reader.Name == "isbn13")
                                {
                                    book.Isbn_13 = reader.Value;
                                }
                            }
                        }

                        else if (name == "Title")
                        {
                            //Title
                            book.Title = reader.ReadString();
                        }
                        else if (name == "TitleLongText")
                        {
                            //Title Long
                        }
                        else if (name == "AuthorsText")
                        {
                            //Author
                            book.Author = reader.ReadString();
                        }
                        else if (name == "PublisherText")
                        {
                            //Publisher
                            book.Publisher = reader.ReadString();
                        }
                        else if (name == "Details")
                        {
                            if (reader.MoveToFirstAttribute())
                            {
                                //Change time
                            }

                            while (reader.MoveToNextAttribute())
                            {
                                //Price time
                                //Edition
                                //Language
                                //Description
                                //lcc
                            }
                        }

                        reader.Read();
                    }

                }
                return book;
            }
            catch (Exception)
            {
                Debug.WriteLine("Error");
                return null;
            }
        }

        //Create the database table, runs upon initialization
        public async Task CreateTable() {
            string databasePath = GetDataPath();
            var conn = new SQLiteAsyncConnection(databasePath);

            await conn.CreateTableAsync<Book>();
        }

        //Inserts a given book into the database then refreshes the grid
        public async Task InsertBook(Book book) {
            string databasePath = GetDataPath();

            var conn = new SQLiteAsyncConnection(databasePath);
            await conn.InsertAsync(book);
            FillBookGrid();
        }

        //Get the path for the database file directory located in AppData
        public string GetDataPath() {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(folder, "PersonalLibrary");

            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);

            return Path.Combine(appFolder, "Books.db");
        }

        //Return all books in the database for populating the main grid view
        public List<Book> GetAllBooks() {
            List<Book> books = new List<Book>();
            var conn = new SQLiteConnection(GetDataPath());
            var query = conn.Table<Book>();

            foreach (var book in query)
                books.Add(book);

            return books;
        }

        //Click event for the search button, errors if no title was returned from GetBookData, otherwise inserts the new book
        private void BookSearchBtn_Click(object sender, EventArgs e)
        {
            string isbn = isbnTextBox.Text;
            Book book = GetBookData(isbn);
            if (string.IsNullOrEmpty(book.Title))
            {
                MessageBox.Show("That ISBN returned no results. Ensure the ISBN contains only letters and numbers.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                var task = InsertBook(book);
            }
        }

        //Deletes the selected row from the grid and database table
        private void BookDeleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bookGridView.Rows) {
                if (row.Selected) {
                    string delID = row.Cells["id"].Value.ToString();
                    var conn = new SQLiteConnection(GetDataPath());
                    conn.Delete<Book>(delID);
                    FillBookGrid();
                }
            }
        }
    }
}
