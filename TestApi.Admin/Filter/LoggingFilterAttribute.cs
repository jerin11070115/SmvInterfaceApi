using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace TestApi.Admin.Filter
{
    public class LoggingFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if ((actionExecutedContext.Response == null))
            {
                LogException(actionExecutedContext, EventLogEntryType.Error);
            }
        }

        private void LogException(HttpActionExecutedContext actionExecutedContext, EventLogEntryType eventLogEntryType)
        {

            string logName = actionExecutedContext.Request.RequestUri.Authority.ToString();          /* Log Name*/
            string exceptionSource = actionExecutedContext.Request.RequestUri.Authority.ToString();  /*Domain Name*/
            string typeMethod = actionExecutedContext.ActionContext.Request.Method.ToString();
            List<KeyValuePair<string, object>> list = actionExecutedContext.ActionContext.ActionArguments.ToList();

            StringBuilder exceptionTrack = new StringBuilder();

            exceptionTrack.Append(Environment.NewLine + "Host Name : " + actionExecutedContext.Request.RequestUri.Authority.ToString() + Environment.NewLine);
            exceptionTrack.Append(Environment.NewLine + "Request Url : " + actionExecutedContext.Request.RequestUri + Environment.NewLine);


            if (typeMethod.ToLower() == "post")
            {

                exceptionTrack.Append(Environment.NewLine + "Request Type : " + typeMethod + Environment.NewLine);
                exceptionTrack.Append(Environment.NewLine + "Class Name : " + list[0].Value + Environment.NewLine);
                var propertiesData = list[0].Value;
                exceptionTrack.Append("Parameter :" + Environment.NewLine);
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(propertiesData))
                {
                    string classPropertyName = descriptor.Name;
                    object classPropertyValue = descriptor.GetValue(propertiesData);
                    exceptionTrack.Append("Key : " + classPropertyName + "    :    " + "Value : " + classPropertyValue + Environment.NewLine);
                }
                exceptionTrack.Append(Environment.NewLine);
            }
            else
            {
                exceptionTrack.Append(Environment.NewLine + "Request Type : " + typeMethod + Environment.NewLine);
                exceptionTrack.Append(Environment.NewLine + "Parameter :" + Environment.NewLine);
                for (int loop = 0; loop < list.Count; loop++)
                {
                    exceptionTrack.Append("Key : " + list[loop].Key + "    :    " + "Value : " + list[loop].Value.ToString() + Environment.NewLine);
                }
                exceptionTrack.Append(Environment.NewLine);
            }

            int count = 1;
            do
            {
                exceptionTrack.Append(Environment.NewLine + "Exception Number :" + count + Environment.NewLine);
                exceptionTrack.Append(Environment.NewLine + "Exception Type :");
                exceptionTrack.Append(actionExecutedContext.Exception.GetType().Name + Environment.NewLine);
                exceptionTrack.Append(Environment.NewLine + "Message : ");
                exceptionTrack.Append(actionExecutedContext.Exception.Message + Environment.NewLine);
                exceptionTrack.Append(Environment.NewLine + "                                        ********************************************************" + Environment.NewLine);
                actionExecutedContext.Exception = actionExecutedContext.Exception.InnerException;
                ++count;
            }
            while (actionExecutedContext.Exception != null);

            if (EventLog.Exists(logName))
            {
                EventLog log = new EventLog(logName);
                log.Source = exceptionSource;
                log.WriteEntry(exceptionTrack.ToString(), eventLogEntryType);
            }
            else
            {

                EventLog.CreateEventSource(exceptionSource, logName);
                EventLog log = new EventLog(logName);
                log.Source = exceptionSource;
                log.WriteEntry(exceptionTrack.ToString(), eventLogEntryType);
            }
        }
    }
}