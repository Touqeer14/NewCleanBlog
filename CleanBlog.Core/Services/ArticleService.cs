using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CleanBlog.Core.Helpers;
using CleanBlog.Core.ViewModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
 

namespace CleanBlog.Core.Services
{
    public class ArticleService : IArticleService
    {
        public IPublishedContent GetaArticleListPage(IPublishedContent siteRoot)
        {
            return siteRoot.Descendants().FirstOrDefault(x => x.ContentType.Alias == "articleList");
        }

        public IEnumerable<IPublishedContent> GetLatestArticles(IPublishedContent siteRoot)
        {
            var articleList = GetaArticleListPage(siteRoot);
            var articles = articleList.Descendants().Where(x => x.ContentType.Alias == "article" && x.IsVisible()).OrderByDescending(y => y.Value<DateTime>("articleDate"));
            return articles;
        }

        public ArticleResultSet GetLatestArticles(IPublishedContent currentContentItem, HttpRequestBase request)
        {
            var siteRoot = currentContentItem.Root();

            var articleList = GetaArticleListPage(siteRoot);
            var articles = articleList.Descendants().
                Where(x => x.ContentType.Alias == "article" && x.IsVisible()).
                OrderByDescending(y => y.Value<DateTime>("articleDate"));

            var isArticleListPage = articleList.Id == currentContentItem.Id;
            var fallbackpageSize = isArticleListPage ? 10 : 3;

            var pageNumber = QueryStringHelper.GetIntFromQueryString(request, "page", 1);
            var pageSize = QueryStringHelper.GetIntFromQueryString(request, "size", fallbackpageSize);

            var hasArticles = articles != null && articles.Any();

            var pageOfArticles = hasArticles
                ? articles.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
                : Enumerable.Empty<IPublishedContent>();
            var totalItemCount = hasArticles ? articles.Count() : 0;

            var pageCount = totalItemCount > 0 ? Math.Ceiling((double)totalItemCount / pageSize) : 1;

            var resultSet = new ArticleResultSet() {
                PageCount = pageCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Results = pageOfArticles,
                IsArticleResultsPage = isArticleListPage,
                Url = articleList.Url

            };
            return resultSet;
        }

        
    }
}
