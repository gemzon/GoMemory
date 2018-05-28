using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Enums;
using GoMemory.Models;

namespace GoMemory.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        public string PlayStyle { get; set; }
        public GameStat EasyGameStat { get; set; }
        public GameStat NormalGameStat { get; set; }
        public GameStat HardGameStat { get; set; }
        public StatsViewModel(string playStyle)
        {
            PlayStyle = playStyle;
           

        }

        private async Task SetGameStatBindingValues()
        {

            await GetStats();
        }

        public async Task<List<GameStat>> GetStats()
        {
            if (IsBusy)
                return null;

            IsBusy = true;
            try
            {
                return await  App.StatRepository.GetGameStats(PlayStyle); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
