
using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Manager
{
    public class ManageRabbitMQ 
    {
        #region Method(s)
        /// <summary>
        /// This create a connection
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IConnection GetConnection(string hostName, string userName, string password)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            connectionFactory.UserName = userName;
            connectionFactory.Password = password;
            return connectionFactory.CreateConnection();
        }

        /// <summary>
        /// attempt to connect to a brocker
        /// creates communication channel
        /// creates a queue if does not exist
        /// send message to a queue
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="data"></param>
        public static void Send(string queue, string data)
        {
            try
            {
                using (IConnection connection = new ConnectionFactory().CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue, false, false, false, null);
                        channel.BasicPublish(string.Empty, queue, null, Encoding.UTF8.GetBytes(data));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// attempt to connect to a brocker
        /// creates communication channel
        /// creates a queue if does not exist
        /// gets encoded message and decode the body of the message
        /// return message
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        public static string Receive(string queue)
        {
            try
            {
                using (IConnection connection = new ConnectionFactory().CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue, false, false, false, null);
                        //var consumer = new EventingBasicConsumer(channel);
                        BasicGetResult result = channel.BasicGet(queue, true);
                        if (result != null)
                        {
                            return Encoding.UTF8.GetString(result.Body);
                        }
                        else
                            return "";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } 
        #endregion
    }
}
