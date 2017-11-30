using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client //also has a ton of data validation stuff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //we handle the primary key
        public int clientID {get; set;}
        [Required, Display(Name = "First Name"), StringLength(25, MinimumLength = 1), RegularExpression(@"^[A-Z]{1}[a-z A-Z]*$", ErrorMessage = "First Name contains only alphabetic characters and first letter capitalized.")]
        public string firstName { get; set; }
        [Required, Display(Name = "Last Name"), StringLength(25, MinimumLength = 1), RegularExpression(@"^[A-Z]{1}[a-z A-Z]*$", ErrorMessage = "Last Name contains only alphabetic characters and first letter capitalized.")]
        public string lastName { get; set; }
        [Required, Display(Name = "Address"), StringLength(50, MinimumLength = 5)]
        public string address { get; set; }
        [Required, Display(Name = "City"), StringLength(25, MinimumLength = 3), RegularExpression(@"^[A-Z]{1}[a-z A-Z]*$", ErrorMessage = "City contains only alphabetic characters and first letter capitalized.")]
        public string city { get; set; }
        [Required, Display(Name = "State"), StringLength(25, MinimumLength = 2), RegularExpression(@"^[A-Z]{1}[a-z A-Z]*$", ErrorMessage = "State contains only alphabetic characters and first letter capitalized.")]
        public string state { get; set; }
        [Required, Display(Name = "Zipcode"), RegularExpression(@"^\d{5}$", ErrorMessage = "Zipcode must be 5 digits")]
        public string zip { get; set; }
        [Required, Display(Name = "Email"), EmailAddress(ErrorMessage = "Email requires @ sign")]
        public string email { get; set; }
        [Required, Display(Name = "Phone"), RegularExpression(@"^\([0-9]{3}\) ([0-9]{3})-([0-9]{4})$", ErrorMessage = "Format (801) 123-4832")]
        public string phone { get; set; }
    }

    /* 
    CREATE TABLE [dbo].[Client] (
    [clientID]  INT           NOT NULL PRIMARY KEY,
    [firstName] VARCHAR (25)  NOT NULL,
    [lastName]  VARCHAR (25)  NOT NULL,
    [address]   VARCHAR (50)  NOT NULL,
    [city]      VARCHAR (25)  NOT NULL,
    [state]     VARCHAR (25)  NOT NULL,
    [zip]       VARCHAR (10)  NOT NULL,
    [email]     VARCHAR (411) NOT NULL,
    [phone]     VARCHAR (20)  NOT NULL
    ); 
    */


}