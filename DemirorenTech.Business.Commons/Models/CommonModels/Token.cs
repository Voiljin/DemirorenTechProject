using System;
using System.Collections.Generic;
using System.Text;

namespace DemirorenTech.Business.Commons.Models.CommonModels
{
    public class Token<T>
    {
        private static readonly Token<T> instance = new Token<T>();

        private Token() { }


        public static Token<T> Instance
        {
            get
            {
                instance.Header = null;
                return instance;
            }
        }

        
        public bool HasError { get; set; }

        
        public string ResultCode { get; set; }

        
        public string ResultMessage { get; set; }

        
        public string AuthenticationToken { get; set; }

        
        public T Result { get; set; }

        
        public object Header { get; set; }

        public Token<T> Login(T result, string authenticationToken)
        {
            Result = result;
            ResultCode = "200";
            HasError = false;
            ResultMessage = "OK";
            AuthenticationToken = authenticationToken;

            return this;
        }

        public Token<T> SuccessResult(T result)
        {
            Result = result;
            ResultCode = "200";
            HasError = false;
            ResultMessage = "OK";
            return this;
        }

        public Token<T> SuccessResult(T result, string resultCode, string resultMessage)
        {
            Result = result;
            ResultCode = resultCode;
            HasError = false;
            ResultMessage = resultMessage;
            return this;
        }
        public Token<T> FailResult(string resultCode, string resultMessage)
        {
            ResultCode = resultCode;
            HasError = true;
            ResultMessage = resultMessage;
            Result = default(T);
            return this;
        }

        public Token<T> FailResult(T result, string resultCode, string resultMessage)
        {
            Result = result;
            ResultCode = resultCode;
            HasError = true;
            ResultMessage = resultMessage;
            return this;
        }
    }
}
