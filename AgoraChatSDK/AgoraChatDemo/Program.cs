﻿using System;
using AgoraChat;
namespace AgoraChatDemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sdk = SDKClient.Instance;

            //TO-DO: need to remove, just for testing
            Console.WriteLine("Press any key to test.");
            Console.ReadKey();
            SDKClient.Instance.TestCallBack("chatManagerListener", "hello method", "hello json");

            SDKClient.Instance.ChatManager.AddCallBack(new CallBack(
                onSuccess: () => { Console.WriteLine("Callback success."); },
                onProgress: (i) => { Console.WriteLine($"Callback progress.{i}"); },
                onError: (i, desc) => { Console.WriteLine($"Callback error, code:{i}; desc:{desc}."); }
            ));
            SDKClient.Instance.TestCallBack("callback", "0", "error");

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
    }
}
