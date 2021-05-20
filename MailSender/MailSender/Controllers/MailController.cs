using MailSender.Models;
using MailSender.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MailSender.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        private readonly IMailService _mailService;
        private readonly ILogger<MailController> _logger;

        public MailController(ILogger<MailController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult SendMail() => View();

        [HttpPost]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mailService.SendEmailAsync(request);
                    _logger.LogInformation("Сообщение отправленно успешно.");

                    return RedirectToAction("SendMail");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Ошибка при отправке сообщения.", ex.ToString());
                }
            }

            return View();
        }
    }
}
