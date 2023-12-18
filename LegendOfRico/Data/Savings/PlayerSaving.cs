using System.Numerics;

namespace LegendOfRico.Data
{
    public class PlayerSaving
    {
        public string CharactType { get; set; }
        public string CharactName { get; set; }
        public int CharactLevel { get; set; }
        public int CharactHp { get; set; }
        public int CharactXp { get; set; } 
        public int CharactCoins { get; set; }
        public int PositionI { get; set; }
        public int PositionJ { get; set; }
        public string? MateName { get; set; }
        public int MateHp { get; set; }
        public bool JoyDead { get; set; }
        public bool WukongDead { get; set; }
        public bool ScorpioDead {  get; set; }
        public bool TontaDead { get; set; }
        public bool RicoDead { get; set; }
        public string PetType {  get; set; }

        public PlayerSaving () { }

        public PlayerSaving (Character player) 
        {
            CharactType = GetStringType(player);
            CharactName = player.Name;
            CharactLevel = player.Level;
            CharactHp = player.CurrentHitPoints;
            CharactXp = player.CurrentXp;
            CharactCoins = player.Coins;
            PositionI = player.PositionI;
            PositionJ = player.PositionJ;
            MateName = GetMemberName(player);
            MateHp = GetMemberHp(player);
            JoyDead = player.Joydead;
            WukongDead = player.Wukongdead;
            ScorpioDead = player.Scorpiodead;
            TontaDead = player.Tontatondead;
            RicoDead = player.RicoDead;
            PetType = GetPetType(player);
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

        private int GetMemberHp(Character player)
        {
            if (player.PartyMember != null)
            {
                return player.PartyMember.CurrentHitPoints;
            }
            else
            {
                return 0;
            }
        }

        private string GetPetType(Character player)
        {
            if (player.GetType() != typeof(Ranger))
            {
                return null;
            }
            else
            {
                if (player.Pet.GetType() == typeof(Nosaffraid))
                {
                    return "nosaffraid";
                }
                if (player.Pet.GetType() == typeof(Nosalto))
                {
                    return "nosalto";
                }
                if (player.Pet.GetType() == typeof(Nosptipti))
                {
                    return "nosptipti";
                }
                if (player.Pet.GetType() == typeof(Americanstaff))
                {
                    return "americanstaff";
                }
                if (player.Pet.GetType() == typeof(Rottweiler))
                {
                    return "rottweiler";
                }
                if (player.Pet.GetType() == typeof(EmperorScorpio))
                {
                    return "emperorscorpio";
                }
                if (player.Pet.GetType() == typeof(LittleScorpio))
                {
                    return "littlescorpio";
                }
                if (player.Pet.GetType() == typeof(RockScorpio))
                {
                    return "rockscorpio";
                }
                if (player.Pet.GetType() == typeof(Aragog))
                {
                    return "aragog";
                }
                if (player.Pet.GetType() == typeof(BigSonOfAragog))
                {
                    return "bigsonofaragog";
                }
                if (player.Pet.GetType() == typeof(SonOfAragog))
                {
                    return "sonofaragog";
                }
                if (player.Pet.GetType() == typeof(AlphaWolf))
                {
                    return "alphawolf";
                }
                if (player.Pet.GetType() == typeof(BetaWolf))
                {
                    return "betawolf";
                }
                if (player.Pet.GetType() == typeof(OmegaWolf))
                {
                    return "omegawolf";
                }
                return null;
            }
        }
    }
}
