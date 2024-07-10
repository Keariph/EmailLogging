using System.Text.Json.Serialization;

namespace EmailLogging.Models
{
    /// <summary>
    /// Saves full information about the email
    /// </summary>
    [Serializable]
    public class Email
    {
        /// <summary>
        /// Initializes a new instance of the Email object without any properties
        /// </summary>
        public Email() 
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the Email object with the usage of the EmailDTO instance
        /// </summary>
        /// <param name="dto">The instance of the EmailDTO class </param>
        public Email(EmailDTO dto)
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now.ToString();
            Subject = dto.Subject;
            Body = dto.Body;
            Recipients = dto.Recipients;
            Result = "";
            FailedMessage = "";
        }

        /// <summary>
        ///  Initializes a new instance of the Email object with the usage of all properties
        /// </summary>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="recipients">Recipients of the email</param>
        /// <param name="result">Result of sending the email</param>
        /// <param name="failedMessage">Error message sending email</param>    
        public Email(string subject, string body, List<string> recipients, string result, string failedMessage)
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now.ToString();
            Subject = subject;
            Body = body;
            Recipients = recipients;
            Result = result;
            FailedMessage = failedMessage;
        }

        public Guid Id { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Recipients { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
