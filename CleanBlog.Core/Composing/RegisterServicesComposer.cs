using Umbraco.Core;
using Umbraco.Core.Composing;
using CleanBlog.Core.Services;

namespace Umbraco.Composers
{
    public class RegisterSiteServiceComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
 
           composition.Register<ISmtpService, SmtpService>(Lifetime.Singleton);

           composition.Register<IArticleService, ArticleService>(Lifetime.Request);
        }
        
    }
}