using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace RabbitMQ.Mock.Models
{
    public class Exchange
    {
        #region Declaration(s)
        public IDictionary<string, object> Arguments = new Dictionary<string, object>();

        public ConcurrentQueue<RabbitMessage> Messages = new ConcurrentQueue<RabbitMessage>();
        public ConcurrentDictionary<string, ExchangeQueueBinding> Bindings = new ConcurrentDictionary<string, ExchangeQueueBinding>();
        #endregion

        #region Propertie(s)
        /// <summary>
        /// gets and sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// gets and sets type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// gets and sets isdurable
        /// </summary>
        public bool IsDurable { get; set; }

        /// <summary>
        /// gets and sets autodelete
        /// </summary>
        public bool AutoDelete { get; set; }

        #endregion


        #region Method(s)

        /// <summary>
        /// publish message
        /// </summary>
        /// <param name="message"></param>
        public void PublishMessage(RabbitMessage message)
        {
            this.Messages.Enqueue(message);

            if (string.IsNullOrWhiteSpace(message.RoutingKey))
            {
                foreach (var binding in Bindings)
                {
                    binding.Value.Queue.PublishMessage(message);
                }
            }
            else
            {
                var matchingBindings = Bindings
                    .Values
                    .Where(b => b.RoutingKey == message.RoutingKey);

                foreach (var binding in matchingBindings)
                {
                    binding.Queue.PublishMessage(message);
                }
            }
        } 

        #endregion
    }
}
