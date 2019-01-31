using System;
using System.Runtime.Remoting.Messaging;
using NUnit.Framework;

namespace Domain.Tests.Fakes
{
    [TestFixture]
    public class StorageTests
    {
        [Test]
        public void Save_WhenCalled_SendsEmail()
        {
            var emailSender = new FakeEmailSender();
            
            Storage storage = new Storage(emailSender);

            storage.Save();

            Assert.That(emailSender.Text, Is.EqualTo("saved"));
        }

        [Test]
        public void Save_WhenSendEmailThrowsException_WriteInLogMessage()
        {
            var emailSender = new FakeEmailSender();
            
            emailSender.ToThrow = new ApplicationException();

            var logger = new FakeLogWriter();
                
            StorageManager storageManager = new StorageManager(emailSender,logger);
            
            storageManager.Save();
            
            Assert.That(logger.Message,Is.EqualTo("got exception"));
        }
    }

    public interface ILogWriter
    {
        void Write(string message);
    }

    class FakeLogWriter : ILogWriter
    {
        public string Message;

        public void Write(string message)
        {
            Message = message;
        }
    }

    class FakeEmailSender : IEmailSender
    {
        public string Text;
        public Exception ToThrow;
        
        public void Send(string text)
        {
            Text = text;
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }
}