using Ryder.Domain.Common;

namespace Ryder.Domain.Entities
{
    public class Rider : BaseEntity
    {
        public string ValidIdUrl { get; set; }
        public string PassportPhoto { get; set; }
        public string BikeDocument { get; set; }
        public Guid AppUserId { get; set; }
    }
}