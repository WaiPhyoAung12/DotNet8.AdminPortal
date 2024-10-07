using AdminPortal.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.Shared.ResponseModels
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public bool IsError => !IsSuccess;
        public string Message { get; set; }
        public EnumErrorTypes? ErrorType { get; set; }
        public T? Data { get; set; }
        public List<string> MessageList { get; set; }
        public static Result<T> Success(string message,T? data=default,string code=null) 
        {
            return new Result<T> { IsSuccess = true, Message = message, Data = data, };
        }
        public static Result<T>Fail(string message,EnumErrorTypes errorType=EnumErrorTypes.Error,string code=null)
        {
            return new Result<T> { IsSuccess = false, Message = message, ErrorType = errorType };
        }
        public static Result<T> FailValidation(List<string> messageList)
        {
            return new Result<T> { IsSuccess = false, MessageList = messageList, ErrorType = EnumErrorTypes.Warning };
        }
    }
}
