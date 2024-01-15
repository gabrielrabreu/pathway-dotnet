using System.Collections.Generic;

namespace Core.API.Common
{
    public class UnprocessableEntityResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
