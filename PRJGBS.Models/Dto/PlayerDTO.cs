namespace PRJGBS.Models.Dto
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public int SaveStateId { get; set; }
        public SaveState SaveState { get; set; }
        public int Health { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
