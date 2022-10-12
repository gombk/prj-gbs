using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJGBS.Models
{
    public class NPC
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public int Affinity { get; set; }
        [ForeignKey("NPCDialogue")]
        public int NPCDialogueID { get; set; }
        public NPCDialogue NPCDialogue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
