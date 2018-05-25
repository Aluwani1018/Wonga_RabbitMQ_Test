using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Mock.Models
{
    public class ExchangeQueueBinding
    {
        #region Propertie(s)
        /// <summary>
        /// gets and sets routing key
        /// </summary>
        public string RoutingKey { get; set; }

        /// <summary>
        /// gets and sets exchange
        /// </summary>
        public Exchange Exchange { get; set; }

        /// <summary>
        /// gets and sets queue
        /// </summary>
        public Queue Queue { get; set; }

        public string Key
        {
            get { return string.Format("{0}|{1}|{2}", Exchange.Name, RoutingKey, Queue.Name); }
        } 
        #endregion
    }
}
