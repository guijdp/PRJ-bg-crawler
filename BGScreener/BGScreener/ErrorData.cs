using System.Collections.Generic;

namespace BGScreener
{
    public class ErrorData
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Stack { get; set; }
        public List<string> Causes { get; set; } //Todo: Include a list of causes and translations
    }
}
