﻿namespace ChatSDK
{
    class Client_Win : IClient
    {

        public override void InitWithOptions(Options options)
        {
            throw new System.NotImplementedException();
        }

        public override void CreateAccount(string username, string password, CallBack callBack = null)
        {
            throw new System.NotImplementedException();
        }

        public override void Login(string username, string pwdOrToken, bool isToken = false, CallBack callBack = null)
        {
            throw new System.NotImplementedException();
        }

        public override void Logout(bool unbindDeviceToken, CallBack callBack = null)
        {
            throw new System.NotImplementedException();
        }

        public override string CurrentUsername()
        {
            throw new System.NotImplementedException();
        }

        public override void StartLog(string logFilePath)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsConnected
        {
            get => IsConnected;
            internal set => IsConnected = value;
        }

        public override bool IsLoggedIn()
        {
            throw new System.NotImplementedException();
        }

        public override string AccessToken()
        {
            throw new System.NotImplementedException();
        }

        public override void StopLog()
        {
            throw new System.NotImplementedException();
        }
    }
}