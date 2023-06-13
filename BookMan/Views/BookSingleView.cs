
namespace BookMan.ConsoleApp.Views // chú ý cách Visual Studio đặt tên namespace
{
    using BookMan.Framework;
    using global::Framework;
    using Models; // chú ý cách dùng using bên trong namespace
    /// <summary>
    /// class để hiển thị một cuốn sách
    /// </summary>
    internal class BookSingleView : ViewBase<Book>
    {
        public BookSingleView(Book model) : base(model) { }
       
        /// <summary>
        /// thực hiện in thông tin ra màn hình console
        /// </summary>
        public override void Render()
        {
            if (Model == null) // kiếm tra xem có dữ liệu không
            {
                // sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
                ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
                return; // kết thúc thực hiện phương thức (bỏ qua phần còn lại)
            }
            // sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
            ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            /* các dòng dưới đây viết ra thông tin cụ thể theo từng dòng
             * sử dụng cách tạo xâu kiểu "interpolation"
             * và dùng dấu cách để căn chỉnh tạo thẩm mỹ
             */
            var model = Model as Book;
            Console.WriteLine($"Authors:     {model.Authors}");
            Console.WriteLine($"Title:       {model.Title}");
            Console.WriteLine($"Publisher:   {model.Publisher}");
            Console.WriteLine($"Year:        {model.Year}");
            Console.WriteLine($"Edition:     {model.Edition}");
            Console.WriteLine($"Isbn:        {model.Isbn}");
            Console.WriteLine($"Tags:        {model.Tags}");
            Console.WriteLine($"Description: {model.Description}");
            Console.WriteLine($"Rating:      {model.Rating}");
            Console.WriteLine($"Reading:     {model.Reading}");
            Console.WriteLine($"File:        {model.File}");
            Console.WriteLine($"File Name:   {model.FileName}");
        }
        
    }
}