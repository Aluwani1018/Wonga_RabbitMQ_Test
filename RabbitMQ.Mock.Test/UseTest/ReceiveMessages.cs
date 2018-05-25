
using NUnit.Framework;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ.Mock.Test.UseTest
{
    [TestFixture]
    public class ReceiveMessages : BaseTester
    {
        #region Test Method
        [Test]
        public void ReceiveSentMessages()
        {
            var server = new RabbitServer();

            ConfigureQueueBinding(server, "test_server", "hello_queue");

            SendMessage(server, "test_server", "Hello my name is, Aluwani");

            var connectionFactory = new MockConnectionFactory(server);

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // First message
                    var message = channel.BasicGet("hello_queue", false);
                    
                    //check if massage is not null
                    Assert.That(message, Is.Not.Null);

                    //get message
                    var messageBody = Encoding.ASCII.GetString(message.Body);

                    //compare message
                    Assert.That(messageBody, Is.EqualTo("Hello my name is, Aluwani"));

                    //get if message is delevered
                    channel.BasicAck(message.DeliveryTag, multiple: false);
                }
            }
        } 


        #endregion



    }
}
