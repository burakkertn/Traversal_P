﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.GetListCommentWithDes();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.GetById(id);
            _commentService.Delete(values);
            return RedirectToAction("Index");
        }
    }
}
