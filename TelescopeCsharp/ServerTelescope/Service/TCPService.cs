using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerTelescope.Service
{

    public class TCPService
    {
        private static TCPService _TCPService;

        public static TCPService Instance
        {
            get
            {
                if (_TCPService == null)
                    _TCPService = new TCPService();
                return _TCPService;
            }

        }

        private bool _ClientConnected = false;
        public bool ClientConnected { get { return Status && _ClientConnected; } }
        public bool Status = false;
        SocketPermission permission;
        Socket sListener;
        IPEndPoint ipEndPoint;
        Socket handler;

        public void Stop()
        {
            try
            {
                if (sListener.Connected)

                    sListener.Shutdown(SocketShutdown.Receive);
                sListener.Close();
                sListener = null;


                Status = false;
                _ClientConnected = false;
            }
            catch (Exception ex)
            { }
        }

        public void Start()
        {
            try
            {
                // Creates one SocketPermission object for access restrictions 
                permission = new SocketPermission(
                NetworkAccess.Accept,     // Allowed to accept connections  
                TransportType.Tcp,        // Defines transport types  
                "",                       // The IP addresses of local host  
                SocketPermission.AllPorts // Specifies all ports  
                );

                // Listening Socket object  
                sListener = null;

                // Ensures the code to have permission to access a Socket  
                permission.Demand();

                // Resolves a host name to an IPHostEntry instance  
                IPHostEntry ipHost = Dns.GetHostEntry("");

                // Gets first IP address associated with a localhost  
                //IPAddress ipAddr = ipHost.AddressList[0];
                IPAddress ipAddr = IPAddress.Loopback;

                // Creates a network endpoint  
                ipEndPoint = new IPEndPoint(ipAddr, global::ServerTelescope.Properties.Settings.Default.IdPort);

                // Create one Socket object to listen the incoming connection  
                sListener = new Socket(
                    ipAddr.AddressFamily,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );

                // Associates a Socket with a local endpoint  
                sListener.Bind(ipEndPoint);

                // Places a Socket in a listening state and specifies the maximum  
                // Length of the pending connections queue  
                sListener.Listen(10);

                // Begins an asynchronous operation to accept an attempt  
                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                sListener.BeginAccept(aCallback, sListener);

                //tbStatus.Text = "Server is now listening on " + ipEndPoint.Address + " port: " + ipEndPoint.Port;

                Status = true;
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.ToString()); 
            }
        }

        #region Listen
        public void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = null;

            // A new Socket to handle remote host communication  
            Socket handler = null;
            try
            {
                // Receiving byte array  
                byte[] buffer = new byte[1024];
                // Get Listening Socket object  
                listener = (Socket)ar.AsyncState;
                // Create a new socket  
                handler = listener.EndAccept(ar);

                // Using the Nagle algorithm  
                handler.NoDelay = false;

                // Creates one object array for passing data  
                object[] obj = new object[2];
                obj[0] = buffer;
                obj[1] = handler;

                // Begins to asynchronously receive data  
                handler.BeginReceive(
                    buffer,        // An array of type Byt for received data  
                    0,             // The zero-based position in the buffer   
                    buffer.Length, // The number of bytes to receive  
                    SocketFlags.None,// Specifies send and receive behaviors  
                    new AsyncCallback(ReceiveCallback),//An AsyncCallback delegate  
                    obj            // Specifies infomation for receive operation  
                    );

                // Begins an asynchronous operation to accept an attempt  
                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                listener.BeginAccept(aCallback, listener);
                _ClientConnected = true;
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.ToString()); 
            }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Fetch a user-defined object that contains information  
                object[] obj = new object[2];
                obj = (object[])ar.AsyncState;

                // Received byte array  
                byte[] buffer = (byte[])obj[0];

                // A Socket to handle remote host communication.  
                handler = (Socket)obj[1];

                // Received message  
                string content = string.Empty;


                // The number of bytes received.  
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    CoordsStellariumEQService.Service.ClientServerByte(buffer);

                    // Continues to asynchronously receive data 
                    byte[] buffernew = new byte[1024];
                    obj[0] = buffernew;
                    obj[1] = handler;
                    handler.BeginReceive(buffernew, 0, buffernew.Length,
                        SocketFlags.None,
                        new AsyncCallback(ReceiveCallback), obj);


                    //this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                    //{
                    //    tbAux.Text = content;
                    //}
                    //);
                }
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.ToString()); 
            }
        }
        #endregion

        #region Send
        public void Send()
        {
            try
            {


                // send telescope position to stellarium
                byte[] byteData = CoordsStellariumEQService.Service.ServerClientByte();
                // Sends data asynchronously to a connected Socket  
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);

            }
            catch (Exception exc)
            {

            }
        }
        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                // A Socket which has sent the data to remote host  
                Socket handler = (Socket)ar.AsyncState;

                // The number of bytes sent to the Socket  
                int bytesSend = handler.EndSend(ar);
                Console.WriteLine(
                    "Sent {0} bytes to Client", bytesSend);
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.ToString()); 
            }
        }
        #endregion
    }

}
