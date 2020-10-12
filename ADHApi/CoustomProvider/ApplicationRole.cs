﻿using System;

namespace ADHApi.CoustomProvider
{
    public class ApplicationRole
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string NormalizedRoleName { get; set; }
    }
}

