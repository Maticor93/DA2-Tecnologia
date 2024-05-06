using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public sealed record class Movie
    {
        public string Id { get; init; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
