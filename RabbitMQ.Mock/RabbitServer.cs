
using RabbitMQ.Mock.Models;
using System.Collections.Concurrent;

namespace RabbitMQ.Mock
{
    public class RabbitServer
    {
        #region Declaration(s)
        public ConcurrentDictionary<string, Exchange> Exchanges = new ConcurrentDictionary<string, Exchange>();
        public ConcurrentDictionary<string, Queue> Queues = new ConcurrentDictionary<string, Queue>();

        #endregion

        #region Method(s)
        /// <summary>
        /// reset server
        /// </summary>
        public void Reset()
        {
            Exchanges.Clear();
            Queues.Clear();
        } 
        #endregion
    }
}
