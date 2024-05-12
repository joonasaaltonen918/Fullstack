using Microsoft.Graph.Models;
using System.ComponentModel.DataAnnotations;

namespace EventPlan1.Models.Domain
{
    public class Event
    {
        public int Id { get; set; }
        //public int
        //
        //
        //{ get; set; }
        [Required]
        public string? EventName { get; set; }

        public int? Date { get; set; }
        [Required]
        public string? EventDescription { get; set; }
        [Required]
        //public int? EventTime { get; set; }
        public DateTime? EventTime { get; set; }
        //public ICollection<Participant> EventParticipants { get; set; }
       // public object Participants { get; internal set; }
        // public ICollection<ApplicationUser> Participants { get; set; } = new List<ApplicationUser>();
        //ypublic object EventParticipants { get; internal set; }

        //public string? Host {  get; set; }
    }
}
