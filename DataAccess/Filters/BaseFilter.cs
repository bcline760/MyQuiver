using System;
namespace MyQuiver.Model.Filters
{
    internal abstract class BaseFilter
    {
        public Guid? Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public string CreatedBy { get; set; }
    }
}
