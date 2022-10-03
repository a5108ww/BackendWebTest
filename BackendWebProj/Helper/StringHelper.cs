using Newtonsoft.Json;
using System.Text;

namespace BackendWebProj.Helper
{
    public static class StringHelper
    {
        public static string ConvertObjectToJsonString(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ConvertJsonStringToObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static StringBuilder AppentStringToStringBuilder(StringBuilder sb, string text)
        {
            if(sb == null)
                sb = new StringBuilder();

            sb.Append(text);
            return sb;
        }
    }
}
