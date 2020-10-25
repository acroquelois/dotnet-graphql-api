using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skeleton.Domain.Core.Models
{
    public interface IBaseEntity
    {
    }
    
    public class BaseEntity<TKey> : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
    }
}