using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    class SocketServer : WebSocketBehavior
    {
        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
        }

        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            base.OnMessage(e);
            Console.WriteLine(e.Data);
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            Console.WriteLine("Hello world!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer(9001);
            wssv.AddWebSocketService<SocketServer>("/Player");
            wssv.Start();
            Console.Read(); //Stops the debugger from exiting run mode
        }
    }
}
