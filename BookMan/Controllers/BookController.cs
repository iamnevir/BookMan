namespace BookMan.ConsoleApp.Controllers
{
    using BookMan.ConsoleApp.Models;
    using DataServices;
    using global::Framework;
    using Views;
    internal class BookController : ControllerBase
    {
        protected Repository Repository;
        public BookController(IDataAccess context)
        {
            Repository = new Repository(context);
        }
        public void Single(int id, string path = "")
        {
            var model = Repository.Select(id);
            Render(new BookSingleView(model), path);
        }
        public void Create(Book book = null)
        {
            if (book == null)
            {
                Render(new BookCreateView());
                return;
            }
            Repository.Insert(book);
            Success("Book created!");
        }
        public void List(string path = "")
        {
            var model = Repository.Select();
            Render(new BookListView(model), path);
        }
        public void Update(int id, Book book = null)
        {
            if (book == null)
            {
                var model = Repository.Select(id);
                var view = new BookUpdateView(model);
                Render(view);
                return;
            }
            Repository.Update(id, book);
            Success("Book updated!");
        }
        public void Delete(int id, bool process = false)
        {
            if (process == false)
            {
                var b = Repository.Select(id);
                Confirm($"Do you want to delete this book ({b.Title})? ", $"do delete?id={b.Id}");
            }
            else
            {
                Repository.Delete(id);
                Success("Book deleted!");
            }
        }
        public void Filter(string key)
        {
            var model = Repository.Select(key);
            if (model.Length == 0)
                Inform("No matched book found!");
            else
                Render(new BookListView(model));
        }
        public void Mark(int id, bool read = true)
        {
            var book = Repository.Select(id);
            if (book == null)
            {
                Error("Book not found!");
                return;
            }
            book.Reading = read;
            Success($"The book '{book.Title}' are marked as {(read ? "READ" : "UNREAD")}");
        }
        public void ShowMarks()
        {
            var model = Repository.SelectMarked();
            var view = new BookListView(model);
            Render(view);
        }
        public void Stats()
        {
            var model = Repository.Stats();
            var view = new BookStatsView(model);
            Render(view);
        }
    }
}