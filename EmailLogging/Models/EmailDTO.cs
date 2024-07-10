namespace EmailLogging.Models
{
    /// <summary>
    /// Saves information about the email received from the front 
    /// </summary>
    [Serializable]
    public class EmailDTO
    {
        /// <summary>
        /// Initializes a new empty instance of the EmailDTO object
        /// </summary>
        public EmailDTO() 
        { 
        }

        /// <summary>
        /// Initializes a new populated instance of the EmailDTO object
        /// </summary>
        /// <param name="subject">The subject of the email</param>
        /// <param name="body">The body of the email</param>
        /// <param name="recepients">Recipients of the email</param>
        public EmailDTO(string subject, string body, List<string> recepients)
        {
            Subject = subject;
            Body = body;
            Recipients = recepients;
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Recipients { get; set; }
    }
}
