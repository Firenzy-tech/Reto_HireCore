using System;
using System.Collections.Generic;
using System.Text;

namespace Reto_1.Entities.DTOs
{
    public class ResponseDto

    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
