using RabbitMQ.Client;

namespace RabbitMQ.Mock.Models
{
    public class RabbitMessage
    {
        #region Propertie(s)

        /// <summary>
        /// gets and sets exchange
        /// </summary>
        public string Exchange { get; set; }

        /// <summary>
        /// gets and sets routingkey
        /// </summary>
        public string RoutingKey { get; set; }

        /// <summary>
        /// gets and sets queue
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        /// gets and sets mandatory
        /// </summary>
        public bool Mandatory { get; set; }

        /// <summary>
        /// gets and sets immediate
        /// </summary>
        public bool Immediate { get; set; }

        /// <summary>
        /// gets and sets basicproperties
        /// </summary>
        public IBasicProperties BasicProperties { get; set; }

        /// <summary>
        /// gets and sets body
        /// </summary>
        public byte[] Body { get; set; }
        #endregion

        #region Method(s)

        /// <summary>
        /// gets a rabbit message
        /// </summary>
        /// <returns></returns>
        public RabbitMessage Copy()
        {
            return new RabbitMessage
            {
                Exchange = Exchange,
                RoutingKey = RoutingKey,
                Queue = Queue,
                Mandatory = Mandatory,
                Immediate = Immediate,
                BasicProperties = BasicProperties,
                Body = Body
            };
        } 
        #endregion
    }
}
