namespace GuildManager.Data.GameObjects.Characters.Stats
{
    public abstract class Resource
    {
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }

        protected Resource(int baseValue, int itemsValue, int buffsValue, int mainStat)
        {

        }
    }
}
