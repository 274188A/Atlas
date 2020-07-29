﻿using System;
using System.Collections.Generic;

namespace Atlas.Domain.PermissionSets.Commands
{
    public class CreatePermissionSet : CommandBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
