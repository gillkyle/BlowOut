using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int clientID {get; set;}
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string email { get; set; }
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