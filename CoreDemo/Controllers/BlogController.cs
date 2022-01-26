using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        private BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriter(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator validator = new BlogValidator();
            ValidationResult result = validator.Validate(blog);
            if (result.IsValid)
            {

                blog.BlogStatus = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                bm.TAdd(blog);

                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> CategoryValues = (from x in categoryManager.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString(),
                }).ToList();
            ViewBag.cv = CategoryValues;
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalues = bm.TGetById(id);
            bm.TDelete(blogvalues);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> CategoryValues = (from x in categoryManager.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString(),
                }).ToList();
            ViewBag.cv = CategoryValues;
            var blogvalues = bm.TGetById(id);
            return View(blogvalues);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            blog.WriterId = 1;
            blog.BlogStatus = true;
            blog.CreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
