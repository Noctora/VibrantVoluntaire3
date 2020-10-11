using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibrantVoluntaire3.Models
{
    public class EventM
    {
        [Key]
        public int eventId { get; set; }
        [Required]
        [DisplayName("Event name")]
        public string event_name { get; set; }
        [Required]
        [DisplayName("Date")]
        public string event_date { get; set; }
        [Required]
        public string venue { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public int attendance_limit { get; set; }
       
        //public float budget { get; set; }
        public int rating { get; set; }
        public string additional_info { get; set; }
        public int usernameId { get; set; }

        [ForeignKey("usernameId")]
        public UserAcc UserAcc { get; set; }
        //public IEnumerable<UserAcc> UserAcc { get; set; }

        public EventM()
        {
            eventId = -1;
            event_name = "";
            event_date = "";
            venue = "";
            location = "";
            attendance_limit = 0;
            //budget = 0;
            rating = 0;
            additional_info = "";
        }

        public EventM(int eventId, string event_name, string event_date, string venue, string location, int attendance_limit, int rating, string additional_info, int usernameId, UserAcc userAcc)
        {
            this.eventId = eventId;
            this.event_name = event_name;
            this.event_date = event_date;
            this.venue = venue;
            this.location = location;
            this.attendance_limit = attendance_limit;
            //this.budget = budget;
            this.rating = rating;
            this.additional_info = additional_info;
            this.usernameId = usernameId;
            UserAcc = userAcc;
        }
    }
}