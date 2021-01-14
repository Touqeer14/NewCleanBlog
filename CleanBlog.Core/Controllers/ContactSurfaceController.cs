using CleanBlog.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using System.Web;
using System.Net.Mail;
using Umbraco.Core.Logging;
using CleanBlog.Core.Services;
 

namespace CleanBlog.Core.Controllers
{
    //public class ContactSurfaceController : SurfaceController
    //{
    //    private readonly ISmtpService _smtpService;
    //    public ContactSurfaceController(ISmtpService smtpService)
    //    {
    //        _smtpService = smtpService;
    //    }

    //    [HttpGet]
    //    public ActionResult RenderForm()
    //    {
    //        ContactViewModel model = new ContactViewModel() { ContactFormId = CurrentPage.Id };

    //        return PartialView("~/Views/Partials/Contact/contactForm.cshtml", model);
    //    }
    //    [HttpPost]

    //    public ActionResult RenderForm(ContactViewModel model)
    //    {

    //        return PartialView("~/Views/Partials/Contact/contactForm.cshtml",model);
    //    }
    //    public ActionResult SubmitForm(ContactViewModel model)
    //    {
    //        bool success = false;

    //        if (ModelState.IsValid)
    //        {
    //            success = _smtpService.SendEmail(model);
    //        }
    //        var contactpage = UmbracoContext.Content.GetById( false, model.ContactFormId);

    //        var successMessage = contactpage.Value<IHtmlString>( "SuccessMessage");
    //        var errorMessage = contactpage.Value<IHtmlString>( "errorMessage");

    //        return PartialView("~/Views/Partials/Contact/result.cshtml", success ? successMessage: errorMessage);



    //    }

    //}
    [HttpGet]
    public ActionResult RenderForm()
    {
        return PartialView("~/Views/Partials/Contact/contactForm.cshtml");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SubmitForm(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            SendEmail(model);
            TempData["ContactSuccess"] = true;

            return RedirectToCurrentUmbracoPage();
        }
        return CurrentUmbracoPage();
    }

}
