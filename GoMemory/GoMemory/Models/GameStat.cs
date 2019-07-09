using GoMemory.Enums;
using SQLite;

namespace GoMemory.Models
{
    [Table("Gamestat")]
    public class GameStat
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string PlayStyle { get; set; }
        public int Level { get; set; }
        public Difficulty Difficulty { get; set; }


    }
}
