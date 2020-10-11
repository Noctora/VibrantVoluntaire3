using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace VibrantVoluntaire3.Models
{
    public class UserAcc
    {
        [Key]
        public int usernameId { get; set; }
        [Required]
        [DisplayName("What is the your username?")]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string occupation { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string interests { get; set; }
        [Required]
        public string past_experience { get; set; }
        [Required]
        public string email_address { get; set; }
        [Required]
        public string phone_num { get; set; }

        public ICollection<EventM> EventMs { get; set; }

        public UserAcc()
        {
            usernameId = -1;
            username = "";
            password = "";
            firstname = "";
            lastname = "";
            age = 0;
            gender = "";
            occupation = "";
            title = "";
            interests = "";
            past_experience = "";
            email_address = "";
            phone_num = "";

        }

        public UserAcc(int usernameId, string username, string password, string firstname, string lastname, int age, string gender, string occupation, string title, string interests, string past_experience, string email_address, string phone_num)
        {
            this.usernameId = usernameId;
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
            this.gender = gender;
            this.occupation = occupation;
            this.title = title;
            this.interests = interests;
            this.past_experience = past_experience;
            this.email_address = email_address;
            this.phone_num = phone_num;
        }
    }
}