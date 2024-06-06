using SocialDotNet.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDotNet.Domain.GroupAggregate.ValueObjects
{
    public sealed class GroupId : ValueObject
    {
        public Guid Value { get; }

        private GroupId(Guid value)
        {
            Value = value;
        }

        public static GroupId CreateUnique()
        {
            return new GroupId(Guid.NewGuid());
        }

        public static GroupId Create(Guid value)
        {
            return new GroupId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
