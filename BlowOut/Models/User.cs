using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
    }

    /*
         CREATE TABLE [dbo].[User] (
    [username] VARCHAR(30) NOT NULL PRIMARY KEY,
    [password] VARCHAR (30) NOT NULL,
    );

    */
}