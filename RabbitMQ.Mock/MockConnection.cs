using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Net;

namespace RabbitMQ.Mock
{
    public class MockConnection : IConnection
    {
        #region Declaration(s)
        private readonly RabbitServer _server;
        #endregion

        #region Ctor(s)
        public MockConnection(RabbitServer server)
        {
            _server = server;
            Models = new List<MockModel>();
        }
        #endregion

        #region Propertie(s)
        /// <summary>
        /// gets and sets models
        /// </summary>
        public List<MockModel> Models { get; private set; }

        /// <summary>
        /// gets and sets local end point
        /// </summary>
        public EndPoint LocalEndPoint { get; set; }

        /// <summary>
        /// gets and sets remote end point
        /// </summary>
        public EndPoint RemoteEndPoint { get; set; }

        /// <summary>
        /// gets and sets local port
        /// </summary>
        public int LocalPort { get; set; }

        /// <summary>
        /// gets and sets remote port
        /// </summary>
        public int RemotePort { get; set; }


        public AmqpTcpEndpoint Endpoint { get; set; }

        public IProtocol Protocol { get; set; }

        IDictionary<string, object> IConnection.ServerProperties
        {
            get { throw new NotImplementedException(); }
        }

        IList<ShutdownReportEntry> IConnection.ShutdownReport
        {
            get { throw new NotImplementedException(); }
        }

        public string ClientProvidedName { get; }

        public ConsumerWorkService ConsumerWorkService { get; }

        event EventHandler<CallbackExceptionEventArgs> IConnection.CallbackException
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public event EventHandler<ConnectionBlockedEventArgs> ConnectionBlocked;
        event EventHandler<ShutdownEventArgs> IConnection.ConnectionShutdown
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> ConnectionUnblocked;


        public event EventHandler<EventArgs> RecoverySucceeded;

        public event EventHandler<ConnectionRecoveryErrorEventArgs> ConnectionRecoveryError;

        public ushort ChannelMax { get; set; }

        IDictionary<string, object> IConnection.ClientProperties
        {
            get { throw new NotImplementedException(); }
        }

        public uint FrameMax { get; set; }

        public ushort Heartbeat { get; set; }

       // public IDictionary ClientProperties { get; set; }

        //public IDictionary ServerProperties { get; set; }

        public AmqpTcpEndpoint[] KnownHosts { get; set; }

        public ShutdownEventArgs CloseReason { get; set; }

        public bool IsOpen { get; set; }

        public bool AutoClose { get; set; }

        //public IList ShutdownReport { get; set; }
        #endregion

        #region Method(s)
        public void Dispose()
        {

        }

        public IModel CreateModel()
        {
            var model = new MockModel(_server);
            Models.Add(model);

            return model;
        }

        public void Close()
        {
            Close(1, null, 0);
        }

        public void Close(ushort reasonCode, string reasonText)
        {
            Close(reasonCode, reasonText, 0);
        }

        public void Close(int timeout)
        {
            Close(1, null, timeout);
        }

        public void Close(ushort reasonCode, string reasonText, int timeout)
        {
            IsOpen = false;
            CloseReason = new ShutdownEventArgs(ShutdownInitiator.Library, reasonCode, reasonText);

            Models.ForEach(m => m.Close());
        }

        public void Abort()
        {
            Abort(1, null, 0);
        }

        public void Abort(int timeout)
        {
            Abort(1, null, timeout);
        }

        public void Abort(ushort reasonCode, string reasonText)
        {
            Abort(reasonCode, reasonText, 0);
        }
        public void Abort(ushort reasonCode, string reasonText, int timeout)
        {
            IsOpen = false;
            CloseReason = new ShutdownEventArgs(ShutdownInitiator.Library, reasonCode, reasonText);

            this.Models.ForEach(m => m.Abort());
        }

        public void HandleConnectionBlocked(string reason)
        {

        }

        public void HandleConnectionUnblocked()
        {

        }
        #endregion
    }
}
