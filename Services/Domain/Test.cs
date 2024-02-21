using System;

namespace Services.Domain
{
    public class Test
    {
        public static string GetGenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
