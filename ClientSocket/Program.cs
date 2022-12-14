using Message; // custom class with implementation of FormatMessage
using System;
using System.Collections.Generic;

namespace SocketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileParser parser = new FileParser(args);
                List<FormatMessage> messagesLs = parser.MessagesLs;

                foreach (FormatMessage fm in messagesLs)
                {
                    ClientSocket.SendMessage(fm);
                    ClientSocket.ReceiveMessage();
                }
                ClientSocket.CloseSocket();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Exception: {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
