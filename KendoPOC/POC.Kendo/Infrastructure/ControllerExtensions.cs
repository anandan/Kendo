﻿using System.Web.Mvc;

namespace Poc.Kendo.Infrastructure
{
    public static class ControllerExtensions
    {
        public static void ShowMessage(this Controller controller, MessageType messageType, string message, bool showAfterRedirect = false)
        {
            var messageTypeKey = messageType.ToString();
            if (showAfterRedirect)
            {
                controller.TempData[messageTypeKey] = message;
            }
            else
            {
                controller.ViewData[messageTypeKey] = message;
            }
        }
    }
}