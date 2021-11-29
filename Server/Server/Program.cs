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
        }

        protected override void OnOpen()
        {
            Console.WriteLine("Hello world!");
            base.OnOpen();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer(9001);
            wssv.AddWebSocketService<SocketServer>("/");
            wssv.Start();
            Console.Read(); //Stops the debugger from exiting run mode
        }
    }
}
