using Blog.Data.Models;
using Blog.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WEB.Controllers
{
    public class ArticleController : Controller
    {
        List<Article> articles;

        public ArticleController()
        {
            this.articles = new List<Article>()
            {
                new Article()
                {
                    Id = 1,
                    Title = "My first blog",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    CreateOn = DateTime.Now,
                    UserId =  "77fa499f-9eb8-4da3-8a08-4f5001aef376",
                },
                new Article()
                {
                    Id = 2,
                    Title = "Article 2",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    CreateOn = new DateTime(2023, 10, 11),
                    UserId =  "77fa499f-9eb8-4da3-8a08-4f5001aef376",
                },
            };
        }

        public IActionResult Index()
        {
            return View(articles.Select(a => new Article()
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content.Substring(0, 100),
                CreateOn = a.CreateOn,
            }));
        }

        public IActionResult Details(int articleId)
        {
            var article = articles
                .FirstOrDefault(a => a.Id == articleId);

            if (article is null)
            {
                return NotFound();
            }

            return View(article);
        }

        [HttpGet]
        public IActionResult Edit(int articleId)
        {
            var article = articles
                .FirstOrDefault(a => a.Id == articleId);

            if (article == null)
            {
                return NotFound();
            }

            ArticleEditViewModel articleEditViewModel = new ArticleEditViewModel()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
            };

            return View(articleEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ArticleEditViewModel article)
        {
            var articleFound = articles
                .FirstOrDefault(a => a.Id == article.Id);

            if (ModelState.IsValid)
            {
                if (articleFound == null)
                {
                    return NotFound();
                }

                articleFound.Title = article.Title;
                articleFound.Content = article.Content;

                return RedirectToAction("Index", "Article");
            }

            return View(article);
        }
    }
}
