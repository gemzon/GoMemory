namespace GoMemory.ViewModels
{
    public class RulesViewModel
    {
        public string PlayStyle { get; set; }
        public RulesViewModel(string playStyle)
        {
            PlayStyle = playStyle;
        }
    }
}
