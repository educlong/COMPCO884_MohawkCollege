using System;

namespace Physician_aspNetCoreWebApp_ModelViewControl.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Description { get; set; }
    }
}
