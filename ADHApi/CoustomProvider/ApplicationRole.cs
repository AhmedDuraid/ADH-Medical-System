using System;

namespace ADHApi.CoustomProvider
{
    public class ApplicationRole
    {
        public string Id { get; set; } = $"Role{DateTime.Now.ToBinary()}";
        public string Name { get; set; }
        public string NormalizedRoleName { get; set; }
    }
}

