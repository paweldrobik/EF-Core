using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCore.Data
{
    public class TeamAssignments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int teamId { get; set; }
        public int memberId { get; set; }

        [ForeignKey("memberId")]
        public virtual TeamMember TeamMember { get; set; }
        [ForeignKey("teamId")]
        public virtual Team Team { get; set; }
    }
}
