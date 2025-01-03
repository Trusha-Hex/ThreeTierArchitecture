using System.Collections.Generic;

namespace ThreeTierApp.Core.Models
{
    public class ValidationErrorResponse
    {
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
    }
}
