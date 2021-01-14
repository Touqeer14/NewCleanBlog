using CleanBlog.Core.ViewModels;

namespace CleanBlog.Core.Services
{
    public interface ISmtpService
    {
        void SendEmail(ContactViewModel model);
    }
}