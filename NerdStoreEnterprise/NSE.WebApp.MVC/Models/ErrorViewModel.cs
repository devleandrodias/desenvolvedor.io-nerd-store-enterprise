using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ResponseResult
    {
        public string Title { get; set; }

        public int Status { get; set; }

        public ResponseErrorMessages Erros { get; set; }
    }

    public class ResponseErrorMessages
    {
        public List<string> Messages { get; set; }
    }
}
