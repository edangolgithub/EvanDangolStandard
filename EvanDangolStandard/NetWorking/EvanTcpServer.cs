using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvanDangol.NetWorking
{
   public class EvanTcpServer
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        //---create a TCPClient object---
        TcpClient _client = null;

        //---for sending/receiving data---
        byte[] buffer;
        public static void RunTcpServer()
        {
            //File.WriteAllText("d:\\a.txt", "cc");
            //return;
            //---listen at the specified IP and port no.---
            IPAddress localAddress = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAddress, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();
            while (true)
            {
                //---incoming client connected---
                EvanTcpServer user = new EvanTcpServer(listener.AcceptTcpClient());
            }
        }


        //---called when a client has connected---
        public EvanTcpServer(TcpClient client)
        {
            _client = client;
            //---start reading data asynchronously from the client---
            buffer = new byte[_client.ReceiveBufferSize];
            _client.GetStream().BeginRead(buffer, 0, _client.ReceiveBufferSize, receiveMessage, null);
        }

        public void receiveMessage(IAsyncResult ar)
        {
            int bytesRead;
            try
            {
                lock (_client.GetStream())
                {
                    //---read from client---
                    bytesRead = _client.GetStream().EndRead(ar);
                }
                //---if client has disconnected---
                if (bytesRead < 1)
                    return;
                else
                {
                    //---get the message sent---
                    string messageReceived = ASCIIEncoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received: " + messageReceived);
                    //---write back the text to the client---
                    Console.WriteLine("Sending back: " + messageReceived);
                    byte[] dataToSend = ASCIIEncoding.ASCII.GetBytes(messageReceived);
                    _client.GetStream().Write(dataToSend, 0, dataToSend.Length);
                }

                //---continue reading from client---
                lock (_client.GetStream())
                {
                    _client.GetStream().BeginRead(buffer, 0, _client.ReceiveBufferSize, receiveMessage, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    //public class EvanTcpServer1
    //{

    //    #region Private Members
    //    private TcpListener _listener;
    //    private IPAddress _address;
    //    private int _port;
    //    private bool _listening;
    //    private string _sslServerName;
    //    private object _syncRoot = new object();
    //    #endregion

    //    #region Properties
    //    public IPAddress Address { get; }
    //    public int Port { get; }
    //    public bool Listening { get; private set; }
    //    public string SSLServerName { get; }
    //    #endregion

    //    #region CTORs
    //    public EvanTcpServer(IPAddress address, int port, string sslServerName = null)
    //    {
    //        _port = port;
    //        _address = address;
    //        _sslServerName = sslServerName;
    //    }
    //    #endregion // CTORs


    //    #region Public Methods
    //    public async Task ListenAsync(CancellationToken cancellationToken =
    //default(CancellationToken))
    //    {
    //        cancellationToken.ThrowIfCancellationRequested();
    //        try
    //        {
    //            lock (_syncRoot)
    //            {
    //                _listener = new TcpListener(Address, Port);
    //                // fire up the server
    //                _listener.Start();
    //                // set listening bit
    //                Listening = true;
    //            }
    //            // Enter the listening loop.
    //            do
    //            {
    //                Console.Write("Looking for someone to talk to... ");
    //                // Wait for connection
    //                try
    //                {
    //                    cancellationToken.ThrowIfCancellationRequested();
    //                    await Task.Run(async () =>
    //                    {
    //                        TcpClient newClient =
    //                            await _listener.AcceptTcpClientAsync();
    //                        Console.WriteLine("Connected to new client");
    //                        await ProcessClientAsync(newClient, cancellationToken);
    //                    }, cancellationToken);
    //                }
    //                catch (OperationCanceledException)
    //                {
    //                    // the user cancelled
    //                    Listening = false;
    //                }
    //            }
    //            while (Listening);
    //        }
    //        catch (SocketException se)
    //        {
    //            Console.WriteLine($"SocketException: {se}");
    //        }
    //        finally
    //        {
    //            // shut it down
    //            StopListening();
    //        }
    //    }




    //    public void StopListening()
    //    {
    //        if (Listening)
    //        {
    //            lock (_syncRoot)
    //            {
    //                // set listening bit
    //                Listening = false;
    //                try
    //                {
    //                    // shut it down if it is listening
    //                    if (_listener.Server.IsBound)
    //                        _listener.Stop();
    //                }
    //                catch (ObjectDisposedException)
    //                {
    //                    // if we try to stop listening while waiting
    //                    // for a connection in AcceptTcpClientAsync (since it blocks)
    //                    // it will throw an ObjectDisposedException here
    //                    // Since we know in this case we are shutting down anyway
    //                    // just note that we cancelled
    //                    Console.WriteLine("Cancelled the listener");
    //                }
    //            }
    //        }
    //    }
    //    #endregion

    //    #region Private Methods
    //    private async Task ProcessClientAsync(TcpClient client,
    //          CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        cancellationToken.ThrowIfCancellationRequested();
    //        try
    //        {
    //            // Buffer for reading data
    //            byte[] bytes = new byte[1024];
    //            StringBuilder clientData = new StringBuilder();
    //            Stream stream = null;
    //            if (!string.IsNullOrWhiteSpace(SSLServerName))
    //            {
    //                Console.WriteLine($"Talking to client over SSL using {SSLServerName}");
    //                SslStream sslStream = new SslStream(client.GetStream());
    //                sslStream.AuthenticateAsServer(GetServerCert(SSLServerName), false,
    //                     SslProtocols.Default, true);
    //                stream = sslStream;
    //            }
    //            else
    //            {
    //                Console.WriteLine("Talking to client over regular HTTP");
    //                stream = client.GetStream();
    //            }
    //            // get the stream to talk to the client over
    //            using (stream)
    //            {
    //                // set initial read timeout to 1 minute to allow for connection
    //                stream.ReadTimeout = 60000;
    //                // Loop to receive all the data sent by the client.
    //                int bytesRead = 0;
    //                do
    //                {
    //                    // THIS SEEMS LIKE A BUG, but it apparently isn't...
    //                    // When we use Read, the first time it works fine, and then on the
    //                    // second read when there is no data the IOException is thrown for
    //                    // the timeout resulting from the 1 second timeout set on the
    //                    // NetworkStream. If we use ReadAsync, it just hangs forever when
    //                    // there is no data on the second read. This is because timeouts
    //                    // are ignored on the Socket class when Async is used.
    //                    try
    //                    {
    //                        // We use Read here and not ReadAsync as if you call ReadAsync
    //                        // it will not timeout as you might expect (see note above)
    //                        bytesRead = stream.Read(bytes, 0, bytes.Length);
    //                        if (bytesRead > 0)
    //                        {
    //                            // Translate data bytes to an ASCII string and append
    //                            clientData.Append(
    //                                Encoding.ASCII.GetString(bytes, 0, bytesRead));
    //                            // decrease read timeout to 1/2 second now that data is
    //                            // coming in.
    //                            stream.ReadTimeout = 500;
    //                        }
    //                    }
    //                    catch (IOException ioe)
    //                    {
    //                        // read timed out, all data has been retrieved
    //                        Trace.WriteLine($"Read timed out: {ioe}");
    //                        bytesRead = 0;
    //                    }
    //                }
    //                while (bytesRead > 0);
    //                Console.WriteLine($"Client says: {clientData}");
    //                // Thank them for their input
    //                bytes = Encoding.ASCII.GetBytes("Thanks call again!");
    //                // Send back a response.
    //                await stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
    //            }
    //        }
    //        finally
    //        {
    //            // stop talking to client
    //            client?.Close();
    //        }
    //    }
    //    private static X509Certificate GetServerCert(string subjectName)
    //    {
    //        using (X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
    //        {
    //            store.Open(OpenFlags.ReadOnly);
    //            X509CertificateCollection certificate = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, true);
    //            if (certificate.Count > 0)
    //                return (certificate[0]);
    //            else
    //                return (null);

    //        }
    //    }
    //    #endregion
    //}
}