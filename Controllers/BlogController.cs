using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasteringEF.Data;
using MasteringEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasteringEF.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogs = _context.Blogs.ToList();
            return View(blogs);

           
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var blogs = _context.Blogs.Find(id);

            if (blogs==null)
            {
                return NotFound();
            }
            return View(blogs);

        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("id,Url")] Blog blog)
        {
            if (id != blog.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _context.Update(blog);
                     _context.SaveChanges();

              return RedirectToAction(nameof(Index));
            }
           
            return View(blog);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blogs = _context.Blogs.FirstOrDefault(m =>m.id==id);

            if (blogs == null)
            {
                return NotFound();
            }
            return View(blogs);

        }

        [HttpPost, ActionName("Delete")]
       
        public IActionResult DeleteConfirmed(int id)
        {
            var blog =  _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blogs = _context.Blogs.FirstOrDefault(m => m.id == id);

            if (blogs == null)
            {
                return NotFound();
            }
            return View(blogs);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("id,Url")] Blog blog)
        {
            if (ModelState.IsValid)
            {

                _context.Add(blog);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(blog);
        }


    }
}