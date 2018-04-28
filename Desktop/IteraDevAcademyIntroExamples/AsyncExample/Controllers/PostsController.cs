/// This is exercise Web API controller class with task to change the API calls from synchronous to asynchrounous
/// using C# async, await capability, which was introduced in C# 5.0 and .NET Framework 4.5.
/// 
/// For more information about asynchronous calls go to https://docs.microsoft.com/en-us/dotnet/csharp/async.
/// 
/// Methods are commented about their asynchronous call alternatives.
/// The method should then return Task<> reference type and be anotated async.
/// Example implementation can be found in PostsControllerAsync.cs.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncExample.Models;

namespace AsyncExample.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostsContext _context;

        public PostsController(PostsContext context)
        {
            _context = context;
        }

        // GET: Posts
        // ToList has async version and can be awaited
        public IActionResult Index()
        {
            return View(_context.Posts.ToList());
        }

        // GET: Posts/Details/5
        // SingleOrDefault has async version and can be awaited
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts
                .SingleOrDefault(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // SaveChanges has async version and can be awaited
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Perex,Content,AuthorId,CreatedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        // SingleOrDefault has async version and can be awaited
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts.SingleOrDefault(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // SaveChanges has async version and can be awaited
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Perex,Content,AuthorId,CreatedAt")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        // SingleOrDefault has async version and can be awaited
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts
                .SingleOrDefault(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        // SingleOrDefault and SaveChanges have async version and can be awaited
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _context.Posts.SingleOrDefault(m => m.Id == id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
