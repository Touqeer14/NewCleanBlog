using CleanBlog.Core.ViewModels;
using System.Collections.Generic;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace CleanBlog.Core.Services
{
    public interface IArticleService
    {
        IPublishedContent GetaArticleListPage(IPublishedContent siteRoot);
        IEnumerable<IPublishedContent> GetLatestArticles(IPublishedContent siteRoot);
        ArticleResultSet GetLatestArticles(IPublishedContent CurrentContentItem, HttpRequestBase requestt);
    }
}