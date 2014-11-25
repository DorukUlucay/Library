using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryUI.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace LibraryUI.Controllers
{
    public class HomeController : Controller
    {
        // evet tüm controller'lar burada. dağıtacağım...

        public ActionResult ApproveReject(int ID, string ActionType)
        {
            using (LibraryUI.Models.LIBRARYEntities db = new Models.LIBRARYEntities())
            {
                Models.BookRequest BR = db.BookRequest.FirstOrDefault(o => o.BookRequestId == ID);
                if (ActionType == "Approve")
                {
                    BR.ApprovedOn = DateTime.Now;
                    BR.ApprovedBy = int.Parse(Session["UserId"].ToString());
                }
                else if (ActionType == "Reject")
                {
                    BR.RejectedOn = DateTime.Now;
                    BR.RejectedBy = int.Parse(Session["UserId"].ToString());
                }
                db.SaveChanges();
            }
            return RedirectToAction("Requests");
        }

        public ActionResult Index(bool? LogOut)
        {
            //            throw new NotImplementedException("ex");
            //error handling görmek istersen.
            
            if (LogOut == true)
            {
                Session.Abandon();
                Session.Clear();
            }

            //TODO: adam gibi join yaz
            List<Book> Books;
            List<Author> Authors;

            using (LIBRARYEntities db = new LIBRARYEntities())
            {
                Books = db.Book.ToList();
                Authors = db.Author.ToList();
            }

            List<BookViewModel> Bvm = new List<BookViewModel>();
            foreach (var book in Books)
            {
                Bvm.Add(new BookViewModel() { Author = book.AuthorId.ToString(), Title = book.Title, BookId = book.BookId });
            }

            foreach (BookViewModel item in Bvm)
            {
                item.Author = Authors.Where(o => o.AuthorId.Equals(int.Parse(item.Author))).ToList()[0].Name;
            }

            return View(Bvm);
        }

        public ActionResult AddBook()
        {
            List<Author> Authors;

            using (Models.LIBRARYEntities db = new Models.LIBRARYEntities())
            {
                Authors = db.Author.ToList();
            }

            return View(Authors);
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            using (LIBRARYEntities db = new LIBRARYEntities())
            {
                db.Book.Add(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            List<Author> Authors;

            using (Models.LIBRARYEntities db = new Models.LIBRARYEntities())
            {
                Authors = db.Author.ToList();
            }
            return View(Authors);
        }

        public JsonResult AddAuthor(Author author)
        {
            try
            {
                using (DataAccessLayer.DataAccessManager DAM = new DataAccessLayer.DataAccessManager())
                {
                    string[] ColNames = { "Name" };
                    SqlParameter[] Values = { new SqlParameter() { Value = author.Name, ParameterName = "Name", SqlDbType = SqlDbType.NVarChar } };
                    
                }
                return Json(new { Ok = true });
            }
            catch (Exception ex)
            {
                return Json(new { Ok = false, ErrorMessage = ex.Message });
            }
        }

        public ActionResult RequestBook()
        {
            List<BookViewModel> Bvm = new List<BookViewModel>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LIBRARYEntitiesMSSQL"].ToString());
            SqlDataAdapter da = new SqlDataAdapter("uspHowManyTaken", conn);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("userid", int.Parse(Session["UserId"].ToString()));

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (int.Parse(dt.Rows[0][0].ToString()) == 2)
            {
                return View(Bvm);
            }


            //yukarıdan c/p. bunu da optimize et.
            List<Book> Books = new List<Book>();
            List<Author> Authors;

            using (Models.LIBRARYEntities db = new Models.LIBRARYEntities())
            {
                Authors = db.Author.ToList();


                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LIBRARYEntitiesMSSQL"].ToString());
                da = new SqlDataAdapter("uspAvailableBooks", conn);
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {


                    Books.Add(
                        new Book()
                        {
                            AuthorId = int.Parse(item["AuthorId"].ToString()),
                            BookId = int.Parse(item["BookId"].ToString()),
                            //CreatedOn = DateTime.Parse(item["CreatedOn"].ToString()),
                            IsActive = item["IsActive"].ToString() == string.Empty ? true : bool.Parse(item["IsActive"].ToString()),
                            //ReleaseDate = item["ReleaseDate"] == DBNull.Value ? DBNull.Value : DateTime.Parse(item["ReleaseDate"].ToString()),
                            Title = item["Title"].ToString()
                        });
                }
            }
                

            
            foreach (var book in Books)
            {
                Bvm.Add(new BookViewModel() { Author = book.AuthorId.ToString(), Title = book.Title, BookId = book.BookId });
            }

            foreach (BookViewModel item in Bvm)
            {
                item.Author = Authors.Where(o => o.AuthorId.Equals(int.Parse(item.Author))).ToList()[0].Name;
            }

            return View(Bvm);
        }

        public ActionResult RequestBookComplete(int ID)
        {
            BookRequest br = new BookRequest();
            br.BookId = ID;
            return View(br);
        }

        [HttpPost]
        public ActionResult RequestBookComplete(BookRequest br)
        {
            br.UserId = int.Parse(Session["UserId"].ToString());
            br.RequestedOn = DateTime.Now;
            using (LIBRARYEntities db = new LIBRARYEntities())
            {
                db.BookRequest.Add(br);
                db.SaveChanges();

            }

            return RedirectToAction("RequestBook");
        }

        public ActionResult Requests()
        {
            List<BookRequestViewModel> WaitingRequests = new List<BookRequestViewModel>();

            using (LibraryUI.Models.LIBRARYEntities db = new LibraryUI.Models.LIBRARYEntities())
            {
                WaitingRequests = (from BR in db.BookRequest
                                   join B in db.Book on BR.BookId equals B.BookId
                                   join A in db.Author on B.AuthorId equals A.AuthorId
                                   join U in db.User on BR.UserId equals U.UserId
                                   where BR.RejectedOn.Equals(null)
                                    && BR.ApprovedOn.Equals(null)

                                   select new BookRequestViewModel
                                   {
                                       RequestId = BR.BookRequestId,
                                       RequestedOn = BR.RequestedOn,
                                       Since = BR.Since,
                                       Until = BR.Until,
                                       Title = B.Title,
                                       AuthorName = A.Name,
                                       UserId = U.UserId,
                                       Name = U.Name,
                                       Surname = U.Surname,
                                       BookId = B.BookId
                                   }).ToList();
            }

            return View(WaitingRequests);
        }

        public ActionResult ReturnBook(int ID)
        {
            using (LibraryUI.Models.LIBRARYEntities db = new Models.LIBRARYEntities())
            {
                Models.BookRequest BR = db.BookRequest.FirstOrDefault(o => o.BookRequestId == ID);
                BR.ReturnedOn = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("ReturnBooks");
        }

        public ActionResult ReturnBooks()
        {
            List<BookRequestViewModel> ReturnBooks = new List<BookRequestViewModel>();
            int CurrUserid = int.Parse(Session["UserId"].ToString());

            using (LibraryUI.Models.LIBRARYEntities db = new LibraryUI.Models.LIBRARYEntities())
            {
                ReturnBooks = (from BR in db.BookRequest
                               join B in db.Book on BR.BookId equals B.BookId
                               join A in db.Author on B.AuthorId equals A.AuthorId
                               join U in db.User on BR.UserId equals U.UserId
                               where !BR.ApprovedOn.Equals(null)
                                && BR.ReturnedOn.Equals(null)
                                && BR.UserId == CurrUserid

                               select new BookRequestViewModel
                               {
                                   RequestId = BR.BookRequestId,
                                   RequestedOn = BR.RequestedOn,
                                   Since = BR.Since,
                                   Until = BR.Until,
                                   Title = B.Title,
                                   AuthorName = A.Name,
                                   UserId = U.UserId,
                                   Name = U.Name,
                                   Surname = U.Surname,
                                   BookId = B.BookId
                               }).ToList();
            }

            return View(ReturnBooks);
        }

        public ActionResult AllBooks()
        {
            //geçici çözüm.
            string Command = "declare @temp table (bookid int, title nvarchar(100), authorid int, " +
            "releasedate datetime, createdon datetime, isactive bit); " +
            "insert into @temp exec uspavailablebooks; " +
            "select * from Book where BookId not in(select bookid from @temp); ";

            string Command2 = "exec  uspavailablebooks";

            using (DataAccessLayer.DataAccessManager DAM = new DataAccessLayer.DataAccessManager())
            {
                BookReportViewModel brm = new BookReportViewModel();
                //TODO:dataset select olayı da vardı ama kaldırdım. geri getiricem.
                brm.BookReport = new DataSet() { Tables = { DAM.SelectDataTable(Command), DAM.SelectDataTable(Command2) } };
                return View(brm);
            }
        }
    }
}