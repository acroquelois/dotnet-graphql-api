using System;
using Microsoft.EntityFrameworkCore;

namespace Skeleton.Internal
{
    public class SkeletonApiContext : DbContext
    {
        public SkeletonApiContext(DbContextOptions<SkeletonApiContext> options)
            : base(options)
        {
        }
    }
}
