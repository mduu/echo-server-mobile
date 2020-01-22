using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Echo.Server.Services
{
    public class TcpServer
    {
        private TcpListener server;

        public TcpServer()
        {
        }

        public async Task Start()
        {
            await LogItem("Server starting ...");

            server = TcpListener.Create(42424);
            server.Start();

            _ = Task.Run(async () => await Serve());

            await LogItem($"Server started: {server.LocalEndpoint.ToString()}");
        }

        public async Task Pause()
        {
        }

        public async Task Resume()
        {

        }

        public async Task Shutdown()
        {
            await LogItem("Server stoping");

            server.Stop();

            await LogItem("Server stoped");
        }


        private async Task Serve()
        {
            try
            {
                var bytes = new byte[256];
                string data = null;

                while (true)
                {
                    var client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected");

                    data = null;

                    var stream = client.GetStream();
                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine($"Received: {data}");

                        if (data.StartsWith("hi", StringComparison.InvariantCultureIgnoreCase))
                        {
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes("Hello" + Environment.NewLine);
                            await stream.WriteAsync(msg, 0, msg.Length);
                        }
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
        }

        private async Task LogItem(string text)
        {
            await MockDataStore.Instance.AddItemAsync(new Models.Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = text,
                Description = DateTime.Now.ToString("G")
            });
        }
    }
}
