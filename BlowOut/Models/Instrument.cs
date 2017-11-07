using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int instrumentID { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        public int price { get; set; }

        [ForeignKey("Client")]
        public virtual int clientID { get; set; }
        public virtual Client Client { get; set; }
    }

    /*
    CREATE TABLE [dbo].[Instrument] (
    [instrumentID] INT          NOT NULL PRIMARY KEY,
    [desc]          VARCHAR (50) NOT NULL,
    [type]         VARCHAR (4)  NOT NULL,
    [price]        INT        NOT NULL,
    [clientID]     INT          NOT NULL,
    );
    */
}
 