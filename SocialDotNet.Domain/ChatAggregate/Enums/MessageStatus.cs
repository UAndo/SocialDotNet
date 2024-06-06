﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDotNet.Domain.ChatAggregate.Enums
{
    public enum MessageStatus
    {
        Sent = 0,
        Delivered = 1,
        Seen = 2,
        Failed = 3
    }
}
