using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using TCE.RJ.Entity;
using TCE.RJ.Web.Context;

namespace TCE.RJ.Web.Controllers
{
	public class BooksController : BaseApiController
	{
		// GET: api/Books
		public IQueryable<Book> GetBooks()
		{
			var books = this.db.Books;

			return books;
		}

		// GET: api/Books/5
		[ResponseType(typeof(Book))]
		public async Task<IHttpActionResult> GetBook(int id)
		{
			var book = await this.db.Books.SingleOrDefaultAsync(b => b.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			return Ok(book);
		}

		// PUT: api/Books/5
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutBook(int id, Book book)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != book.Id)
			{
				return BadRequest();
			}

			this.db.Entry(book).State = EntityState.Modified;

			try
			{
				await this.db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BookExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/Books
		[ResponseType(typeof(Book))]
		public async Task<IHttpActionResult> PostBook(Book book)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				
				//if (!string.IsNullOrEmpty(book.Capa))
				//{
				//	book.Capa = Convert.FromBase64String(book.Capa);
				//}
				

				this.db.Books.Add(book);
				await this.db.SaveChangesAsync();

				var dto = new Book()
				{
					Id = book.Id,
					Nome = book.Nome,
					Autor = book.Autor,
					ISBN = book.ISBN,
					Preco = book.Preco,
					DataPublicacao = book.DataPublicacao,
					Capa = book.Capa
				};

				return CreatedAtRoute("DefaultApi", new { id = book.Id }, dto);
			}
			catch (Exception ex)
			{
				return CreatedAtRoute("DefaultApi", new { id = book.Id }, ex.Message);
			}
		}

		// DELETE: api/Books/5
		[ResponseType(typeof(Book))]
		public async Task<IHttpActionResult> DeleteBook(int id)
		{
			Book book = await db.Books.FindAsync(id);
			if (book == null)
			{
				return NotFound();
			}

			db.Books.Remove(book);
			await db.SaveChangesAsync();

			return Ok(book);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool BookExists(int id)
		{
			return db.Books.Count(e => e.Id == id) > 0;
		}
	}
}