
namespace BookMan.ConsoleApp.Views
{
    using global::Framework;
    using BookMan.Framework;
    using Models;
    /// <summary>
    /// class để hiển thị danh sách Book
    /// </summary>
    internal class BookListView : ViewBase<Book[]>
    {
        
        /// <summary>
        /// hàm tạo
        /// </summary>
        /// <param name="model">danh sách object kiểu Book</param>
        public BookListView(Book[] model) : base(model) { }
        
        /// <summary>
        /// in danh sách ra console
        /// </summary>
        public override void Render()
        {
            if (((Book[])Model).Length == 0)
            {
                ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
                return;
            }
            ViewHelp.WriteLine("THE BOOK LIST", ConsoleColor.Green);
            int i = 0;
           foreach(Book b in Model as Book[])
            {
                ViewHelp.Write($"[{b.Id}]", ConsoleColor.Yellow);
                ViewHelp.WriteLine($"{b.Title}",b.Reading?ConsoleColor.Cyan:ConsoleColor.White);
            }
           Console.ResetColor();
        }
        
    }
}