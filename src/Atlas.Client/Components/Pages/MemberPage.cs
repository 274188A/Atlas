﻿using System;
using Microsoft.AspNetCore.Components;

namespace Atlas.Client.Components.Pages
{
    public abstract class MemberPage : PageBase
    {
        [Parameter] public Guid Id { get; set; }
    }
}