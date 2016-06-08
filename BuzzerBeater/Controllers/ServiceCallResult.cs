using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BuzzerBeater.Controllers
{
    public class ServiceCallResult 
    {

        private bool _success;
        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

        private object _data;
        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private List<string> _errors = new List<string>();
        public List<string> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }

        public ServiceCallResult()
        {
            this.Success = true;
            this.Data = null;
            this.Errors = null;
        }

        public ServiceCallResult(string errorString)
        {
            this.Success = false;
            this.Data = null;
            this.Errors.Add(errorString);
        }

        public ServiceCallResult(object data)
        {
            this.Success = true;
            this.Data = data;
            this.Errors = null;
        }

        public ServiceCallResult(object data, params string[] errors)
        {
            this.Success = true;
            this.Data = data;
            this.Errors.AddRange(errors);
        }

        public ServiceCallResult(params string[] errors)
        {
            this.Success = false;
            this.Data = null;
            this.Errors.AddRange(errors);
        }

        public ServiceCallResult(Exception ex)
        {
            this.Success = false;
            this.Data = null;
            string innerE = string.Empty;
            if (ex.InnerException != null)
            {
                innerE = ex.InnerException.Message;
            }
            this.Errors.Add(ex.Message);
            this.Errors.Add(ex.StackTrace);
            this.Errors.Add(ex.Source);
            this.Errors.Add(ex.TargetSite.Name);
            this.Errors.Add(innerE);
        }

        public ServiceCallResult(bool success, object data, List<string> errors, Exception ex = null)
        {
            this.Success = success;
            this.Data = data;
            this.Errors = errors;
            string innerE = string.Empty;
            if (ex.InnerException != null)
            {
                innerE = ex.InnerException.Message;
            }
            this.Errors.Add(ex.Message);
            this.Errors.Add(ex.StackTrace);
            this.Errors.Add(ex.Source);
            this.Errors.Add(ex.TargetSite.Name);
            this.Errors.Add(innerE);
        }

        public ServiceCallResult(bool success, object data, params string[] errors)
        {
            this.Success = success;
            this.Data = data;
            this.Errors.AddRange(errors);
        }

        public static string SendJSONError(params string[] errors)
        {
            return JsonConvert.SerializeObject(new ServiceCallResult(errors), new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }

        public static string SendJSONException(Exception ex)
        {
            return JsonConvert.SerializeObject(new ServiceCallResult(ex), new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }

        public static object SendJSONResult()
        {
            return JsonConvert.SerializeObject(new ServiceCallResult(), new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }

        public static object SendJSONResult(object data)
        {
            return JsonConvert.SerializeObject(new ServiceCallResult(data), new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }
        public static object SendJSONResult(object data, params string[] errors)
        {
            return JsonConvert.SerializeObject(new ServiceCallResult(data, errors), new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }
    }
}