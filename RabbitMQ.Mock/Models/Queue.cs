using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RabbitMQ.Mock.Models
{
    public class Queue
    {

        #region Declaration(s)

        public Dictionary<string, object> Arguments = new Dictionary<string, object>();

        public ConcurrentQueue<RabbitMessage> Messages = new ConcurrentQueue<RabbitMessage>();

        public ConcurrentDictionary<string, ExchangeQueueBinding> Bindings = new ConcurrentDictionary<string, ExchangeQueueBinding>();
        #endregion

        #region Propertie(s)
        /// <summary>
        /// gets and set name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// gets and sets isdurable
        /// </summary>
        public bool IsDurable { get; set; }

        /// <summary>
        /// gets and sets isexclusive
        /// </summary>
        public bool IsExclusive { get; set; }

        /// <summary>
        /// gets and sets isautodelete
        /// </summary>
        public bool IsAutoDelete { get; set; }
        #endregion

        #region EventHandler(s)

        public event EventHandler<RabbitMessage> MessagePublished = (sender, message) => { };
        #endregion

        #region Method(s)

        /// <summary>
        /// publich message
        /// </summary>
        /// <param name="message"></param>
        public void PublishMessage(RabbitMessage message)
        {
            var queueMessage = message.Copy();
            queueMessage.Queue = this.Name;

            this.Messages.Enqueue(queueMessage);

            MessagePublished(this, queueMessage);
        } 
        #endregion
    }
}
