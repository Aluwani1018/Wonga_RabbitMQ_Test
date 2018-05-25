using System;
using System.Linq;
using Newtonsoft.Json;
using RabbitMQ.Manager;
using RabbitMQ.Manager.Models;

namespace RabbitMQ.Receiver
{
    class Program
    {
        #region const variables
        private const string QUEUE_NAME = "Hello";
        #endregion

        #region Method(s)
        static void Main(string[] args)
        {
            try
            {
                //send message from a Queue
                string message = ManageRabbitMQ.Receive(QUEUE_NAME);

                //deserialiszing an object
                var messageQueue = JsonConvert.DeserializeObject<MessageQueue>(message);

                //print message
                Console.WriteLine(!string.IsNullOrEmpty(messageQueue.Message.Split(',').LastOrDefault()) 
                                                ? $"Hello {message.Split(',').LastOrDefault() }, I am your father!" 
                                                : "There is nothing received from the queue!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        } 
        #endregion
    }
}
