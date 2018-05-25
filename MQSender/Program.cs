using System;
using Newtonsoft.Json;
using RabbitMQ.Manager;
using RabbitMQ.Manager.Models;

namespace RabbitMQ.Sender
{
    class Program
    {
        #region Declaration(s)
        private const string QUEUE_NAME = "Hello";
        #endregion


        #region Method(s)
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please enter name:");

                string name = Console.ReadLine();

                var mq = new MessageQueue
                {
                    Message = $"Hello my name is, {name}"
                };

                //send serialise object to a Queue, 
                //reason for using json object was just experimenting.
                ManageRabbitMQ.Send(QUEUE_NAME, JsonConvert.SerializeObject(mq));
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
