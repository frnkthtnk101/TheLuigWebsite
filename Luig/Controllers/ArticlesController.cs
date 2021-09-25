using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Luig.Models;
using Luig.Data;
using Luig.Data.Models;
using AutoMapper;
using System.IO;

namespace Luig.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Articles, Article>();
            });
            var mapper = config.CreateMapper();
            Articles[] articles = DataLuigContext.GetArticles();
            var length = articles.Length;
            Article[] webArticles = new Article[length];
            for (int i = 0; i < length; i++)
                webArticles[i] = mapper.Map<Articles, Article>(articles[i]);
            return View(webArticles);
        }
    }
}