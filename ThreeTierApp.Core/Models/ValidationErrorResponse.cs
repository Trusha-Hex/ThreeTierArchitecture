using System;
using System.Collections.Generic;
using System.Text;

// Core/Models/ValidationErrorResponse.cs
namespace ThreeTierApp.Core.Models
{
    public class ValidationErrorResponse
    {
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
    }
}
