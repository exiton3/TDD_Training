using System;

namespace Domain.Tests.Fakes
{
    public class StorageManager
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogWriter _logger;

        public StorageManager(IEmailSender emailSender, ILogWriter logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        public void Save()
        {
            try
            {
                _emailSender.Send("saved");
            }
            catch (Exception e)
            {
                _logger.Write("got exception");
            }
        }
    }
}