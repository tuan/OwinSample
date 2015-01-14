﻿// Copyright (C) Microsoft Corporation.  All rights reserved. 

using System;
using System.Diagnostics;

namespace Common
{
    public class Logger : ILogger
    {
        // Warning - trace information within the application  
        public void Information(string message)
        {
            Trace.TraceInformation(message);
        }

        /// <summary>
        /// Traces information.
        /// </summary>
        /// <param name="fmt">String formatter.</param>
        /// <param name="vars">String formatter's parameters.</param>
        public void Information(string fmt, params object[] vars)
        {
            Trace.TraceInformation(fmt, vars);
        }

        public void Information(Exception exception, string fmt, params object[] vars)
        {
            var msg = String.Format(fmt, vars);
            Trace.TraceInformation(string.Format(fmt, vars) + ";Exception Details={0}",
                ExceptionUtils.FormatException(exception, includeContext: true));
        }

        // Warning - trace warnings within the application  
        public void Warning(string message)
        {
            Trace.TraceWarning(message);
        }

        public void Warning(string fmt, params object[] vars)
        {
            Trace.TraceWarning(fmt, vars);
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            var msg = String.Format(fmt, vars);
            Trace.TraceWarning(string.Format(fmt, vars) + ";Exception Details={0}",
                ExceptionUtils.FormatException(exception, includeContext: true));
        }

        // Error - trace fatal errors within the application  
        public void Error(string message)
        {
            Trace.TraceError(message);
        }

        public void Error(string fmt, params object[] vars)
        {
            Trace.TraceError(fmt, vars);
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            var msg = String.Format(fmt, vars);
            Trace.TraceError(string.Format(fmt, vars) + ";Exception Details={0}",
                ExceptionUtils.FormatException(exception, includeContext: true));
        }

        // TraceAPI - trace inter-service calls (including latency) 
        public void TraceApi(string componentName, string method, TimeSpan timespan)
        {
            TraceApi(componentName, method, timespan, "");
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
        {
            TraceApi(componentName, method, timespan, string.Format(fmt, vars));
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
        {
            string message = String.Concat("component:", componentName, ";method:", method, ";timespan:", timespan.ToString(), ";properties:", properties);
            Trace.TraceInformation(message);
        }
    }
}