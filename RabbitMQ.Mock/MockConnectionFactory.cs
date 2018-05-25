using System;
using System.Collections.Generic;
using RabbitMQ.Client;

namespace RabbitMQ.Mock
{
    public class MockConnectionFactory : ConnectionFactory
    {

        #region Ctor
        public MockConnectionFactory() : this(new RabbitServer())
        {

        }

        public MockConnectionFactory(RabbitServer server)
        {
            Server = server;
        }
        #endregion
        
        #region Propertie(s)
        public IConnection Connection { get; private set; }
        public RabbitServer Server { get; private set; }

        public MockConnection UnderlyingConnection
        {
            get { return (MockConnection)Connection; }
        }

        public List<MockModel> UnderlyingModel
        {
            get
            {
                var connection = UnderlyingConnection;
                if (connection == null)
                    return null;

                return connection.Models;
            }
        }
        #endregion
        
        #region Method(s)
        public MockConnectionFactory WithConnection(IConnection connection)
        {
            Connection = connection;
            return this;
        }

        public MockConnectionFactory WithRabbitServer(RabbitServer server)
        {
            Server = server;
            return this;
        }


        public override IConnection CreateConnection()
        {
            if (Connection == null)
                Connection = new MockConnection(Server);

            return Connection;
        }
        #endregion
        
    }
}
