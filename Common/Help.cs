using System;
using System.Linq;
using Shared.Enums;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Common
{
    public static class Help
    {
        public static Task<IEnumerable<EnumDetail>> GetEnumDetelsAsync(string[] namespaces)
        {
            return Task.Run(() =>
            {
                return
                AppDomain.CurrentDomain.
                GetAssemblies().
                SelectMany(a => a.GetTypes()).
                Where(t => t.IsEnum && t.Namespace != null && namespaces.Any(n => t.Namespace.ToLower().Contains(n.ToLower()))).
                Select(t => new EnumDetail(t.Name, Enum.GetNames(t).Select(s => new KeyValuePair<int, string>((int)Enum.Parse(t, s), s))));
            });
        }
    }
}
