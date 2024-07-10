using EmailLogging.Models;
using EmailLogging.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace EmailLogging.Controllers
{
    /// <summary>
    /// Provides a set of endpoints for managing email operations
    /// </summary>
    public class ApiController : Controller
    {
        private readonly EmailContext _context;

        /// <summary>
        /// Initialize a new instance of the MailSevice class with special options of the connection to the database
        /// </summary>
        /// <param name="context">The instance of the EmailContex class with options of the connection to the database </param>
        public ApiController(EmailContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get an email in JSON from the front and try to send it
        /// </summary>
        /// <param name="dto">Json received from the front and converted to a class object EmailDTO</param>
        /// <returns>Sending result</returns>
        [HttpPost]
        public string Mails([FromBody] EmailDTO dto)
        {
            MailService mailService = new MailService();
            Email email = new(dto);
            mailService.SendMessage(email);
            _context.Emails.Add(email); 
            _context.SaveChanges();
            return email.Result;
        }

        /// <summary>
        /// Take information from the database about all the trying to send email 
        /// </summary>
        /// <returns>The information in JSON and response code or error code</returns>
        [HttpGet]
        public IActionResult Mails()
        {          
            List<Email> emails = _context.Emails.ToList();
            Response.ContentType = "application/json";
            string response = JsonSerializer.Serialize(emails);
            return response == null ? NotFound() : Ok(response);
        }
    }
}
