using Microsoft.Build.Framework;

namespace EventPlan1.Models.Domain
{
    public class Host
    {
        public int Id { get; set; }
        [Required]
        public string HostName { get; set; }
    }
}
