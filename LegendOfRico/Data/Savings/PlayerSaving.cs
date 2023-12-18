using System.Numerics;

namespace LegendOfRico.Data
{
    public class PlayerSaving
    {
        public string CharactType { get; set; }
        public string CharactName { get; set; }
        public int CharactLevel { get; set; }
        public int CharactXp { get; set; } 
        public string? MateName { get; set; }
        public bool JoyDead { get; set; }
        public bool WukongDead { get; set; }
        public bool ScorpioDead {  get; set; }
        public bool TontaDead { get; set; }

        public PlayerSaving () { }

        public PlayerSaving (Character player) 
        {
            CharactType = GetStringType(player);
            CharactName = player.Name;
            CharactLevel = player.Level;
            CharactXp = player.CurrentXp;
            MateName = GetMemberName(player);
            JoyDead = player.Joydead;
            WukongDead = player.Wukongdead;
            ScorpioDead = player.Scorpiodead;
            TontaDead = player.Tontatondead;
        }

        private string GetStringType(Character player)
        {
            if (player.GetType() == typeof(Rogue))
            {
                return "rogue";
            }
            else if (player.GetType() == typeof(Fighter))
            {
                return "fighter";
            }
            else if (player.GetType() == typeof(Ranger))
            {
                return "ranger";
            }
            else if (player.GetType() == typeof(Cleric))
            {
                return "cleric";
            }
            else
            {
                return "wizard";
            }
        }

        private string GetMemberName(Character player)
        {
            if (player.PartyMember != null)
            {
                return player.PartyMember.Name;
            }
            else
            {
                return null;
            }
        }
    }
}
