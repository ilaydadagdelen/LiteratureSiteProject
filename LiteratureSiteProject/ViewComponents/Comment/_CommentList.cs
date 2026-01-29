using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureSiteProject.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetBlogByID(id);
            return View(values);  
        }
    }
}
