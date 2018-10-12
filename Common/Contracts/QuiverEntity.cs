using System;
namespace MyQuiver.Contracts
{
    public abstract class QuiverEntity<T>
    {
        public QuiverEntity()
        {
        }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public string CreatedBy { get; set; }
    }
}
