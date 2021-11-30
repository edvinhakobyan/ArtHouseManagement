using System.Collections.Generic;

namespace Shared.Enums
{
    public class EnumDetail
    {
        public EnumDetail(string enumName, IEnumerable<KeyValuePair<int, string>> valuePairs)
        {
            EnumName = enumName;
            ValuePairs = valuePairs;
        }

        public string EnumName { get; set; }
        public IEnumerable<KeyValuePair<int, string>> ValuePairs { get; set; }
    }
}
