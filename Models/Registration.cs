using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VibrantVoluntaire3.Models
{
    public class Registration
    {
        [Key]
        public int participateId { get; set; }
        public int eventId { get; set; }
        public int usernameId { get; set; }


        [ForeignKey("eventId")]
        public EventM EventM { get; set; }
        [ForeignKey("usernameId")]
        public UserAcc UserAcc { get; set; }

        public Registration()
        {
            participateId = -1;
        }

        public Registration(int participateId, int eventId, int usernameId, EventM eventM, UserAcc userAcc)
        {
            this.participateId = participateId;
            this.eventId = eventId;
            this.usernameId = usernameId;
            EventM = eventM;
            UserAcc = userAcc;
        }
    }
}