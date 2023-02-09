using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTasks
{
    class ipFromHostNames
    {
        
        public static Dictionary<string, IPAddress> Resolve(string[] hostNames)
        {
            var result = hostNames.AsParallel().ToDictionary(hn=> (hn), 
                hn => (Dns.GetHostAddresses(hn).First()) );

            return result;
        }
        

        
    }
}
