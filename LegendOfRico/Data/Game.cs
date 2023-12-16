﻿using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using LegendOfRico.Pages;

namespace LegendOfRico.Data
{
    //Class "main" qui va permettre de développer les interactions entre le Player et la map tel que les combats, les savings etc
    public class Game
    {
        public Map GameMap { get; set; } = new Map();
        public Character Player { get; set; } = new Wizard { };
        public Monster MonsterFight { get; private set; } = new Bulldog { };
        public Merchant Merchant { get; private set; } = new Merchant();
        public TavernRecruits Tavernist { get; private set; } = new TavernRecruits();
        public bool IsCurrentFight { get; set; } = false;
        public string FightMessage { get; set; } = "";
        public bool PlayerDead = false;
        public bool MonsterDead = false;
        //série de paramètres/variables qui vont gérer l'affichage des différents display du jeu
        //gestion du menu de droite
        public bool ShowInventory = true;
        public bool ShowQuestList = false;
        public bool ShowQuestGiver = false;
        //gestion de l'interface de combat
        public bool ShowFightSpells = true;
        public bool ShowFightInventory = false;
        public int Turncount = 0;
        public TypeOfShow FormShow { get; set; } = TypeOfShow.Connection;

        public void LevelUp(Character player)
        {
            if (player.Equals(Player))
            {
                GameMap.MapLevel++;
            }
            while(player.CurrentXp >= player.XpToLevel)
            {
                player.Level++;
                FightMessage += player.Name + " gagne un niveau ! ";
                player.CurrentXp -= player.XpToLevel;
                player.XpToLevel += 125 * (player.Level - 1);
            }
        }


        public void CreateCharacter(string CName, TypeOfCharacter Type)
        {
            if (Type == TypeOfCharacter.Magicien)
            {
                Player = new Wizard { Name = CName, MapSprite = "img/character/spriteWizard.png" };
            }
            else if (Type == TypeOfCharacter.Guerrier)
            {
                Player = new Fighter { Name = CName, MapSprite = "img/character/spriteFighter.png" };
            }
            else if (Type == TypeOfCharacter.Voleur)
            {
                Player = new Rogue { Name = CName, MapSprite = "img/character/spriteRogue.png" };
            }
            else if (Type == TypeOfCharacter.Clerc)
            {
                Player = new Cleric { Name = CName, MapSprite = "img/character/spriteCleric.png" };
            }
            else
            {
                Player = new Ranger { Name = CName, MapSprite = "img/character/spriteRanger.png" };
            }
            FormShow = TypeOfShow.Map;

        }

        public void Deconnection()
        {
            FormShow = TypeOfShow.Connection;
        }

        //gestion des quetes

        public void ValidQuest(Quest quest)
        {
            if (quest.GetType() == typeof(CollectQuest))
            {
                CollectQuest collecquest = (CollectQuest)quest;
                GameMap.MapLayout[collecquest.PositionI][collecquest.PositionJ].IsACollectDestination = false;
            }
            Player.LootGold(quest.CoinsReward);
            Player.CurrentXp += quest.XpReward;
            if(Player.PartyMember != null)
            {
                Player.PartyMember.CurrentXp += quest.XpReward;
            }

            if(Player.CurrentXp >= Player.XpToLevel)
            {
                LevelUp(Player);
            }
            if(Player.PartyMember != null && Player.PartyMember.CurrentXp >= Player.PartyMember.XpToLevel) 
            {
                LevelUp(Player.PartyMember);
            }
            Player.QuestsBook.Remove(quest);
        }

        public void TakeQuest(Quest quest)
        {
            if (quest.GetType() == typeof(CollectQuest))
            {
                CollectQuest collecquest = (CollectQuest)quest;
                GameMap.MapLayout[collecquest.PositionI][collecquest.PositionJ].IsACollectDestination = true;
            }
            Player.QuestsBook.Add(quest);
            GameMap.MapLayout[Player.PositionI][Player.PositionJ].MisterQuest.Quests.Remove(quest);
        }

        public void UseConsumable(Consumable consumable, Character target)
        {
            consumable.Use(target);
        }

        //gestion du menu de droite pour les quetes et inventaire.


        public void SwitchShowQuestList()
        {
            ShowInventory = false;
            ShowQuestList = true;
            ShowQuestGiver = false;
        }

        public void SwitchShowInventoryList()
        {
            ShowInventory = true;
            ShowQuestList = false;
            ShowQuestGiver = false;
        }

        public void SwitchShowQuestGiver()
        {
            ShowQuestGiver = true;
            ShowQuestList = false;
            ShowInventory = false;
        }

        //Gestion des combats

        //Fonction qui va vérifier si le déplacement provoque un combat ou pas.

        private void IsFight(Square localisation)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            if (randomNumber < localisation.ChanceToTriggerFight)
            {
                MonsterFight = SelectEnemy();
                IsCurrentFight = true;
                FormShow = TypeOfShow.Fight;
            }
        }

        public void Action(Spells spell)
        {
            if (MonsterFight.MonsterBreed != TypeOfBreed.RicoChico || (Player.Wukongdead && Player.Tontatondead && Player.Joydead && Player.Scorpiodead))
            {
                if (Turncount % 2 == 0)
                {
                    FightMessage = spell.UseSpell(Player, MonsterFight);
                    FightMessage += " ";
                    Turncount++;
                    if (!CheckGroup())
                    {
                        Turncount++;
                    }
                }
                else
                {
                    FightMessage = spell.UseSpell(Player.PartyMember, MonsterFight);
                    FightMessage += " ";
                    Turncount++;
                }
            }
            else
            {
                MonsterHit();
                CheckCharactDead();
            }
            FightChecking();
        }

        
        public void UseWeapon(Monster target)
        {
            if (target.MonsterBreed != TypeOfBreed.RicoChico || (Player.Wukongdead && Player.Tontatondead && Player.Joydead && Player.Scorpiodead))
            {
                if (Turncount % 2 == 0)
                {
                    FightMessage = Player.Hit(target);
                    FightMessage += " ";
                    Turncount++;
                    if (!CheckGroup())
                    {
                        Turncount++;
                    }
                }
                else
                {
                    FightMessage = Player.PartyMember.Hit(target);
                    FightMessage += " ";
                    Turncount++;
                }
            }
            else
            {
                MonsterHit();
                CheckCharactDead();
            }
            FightChecking();
        }

        public void UseConsumableFight(Consumable consumable)
        {
            if(!consumable.DodgeFight)
            { 
                if (MonsterFight.MonsterBreed != TypeOfBreed.RicoChico || (Player.Wukongdead && Player.Tontatondead && Player.Joydead && Player.Scorpiodead))
                {
                    if (Turncount % 2 == 0)
                    {
                        FightMessage = consumable.UseInBattle(Player);
                        FightMessage += " ";
                        Turncount++;
                        if (!CheckGroup())
                        {
                            Turncount++;
                        }
                    }
                    else
                    {
                        FightMessage = consumable.UseInBattle(Player.PartyMember);
                        FightMessage += " ";
                        Turncount++;
                    }
                }
                else
                {
                    MonsterHit();
                    CheckCharactDead();
                }
                FightChecking();
            }
            else
            {
                FightMessage = consumable.UseInBattle(Player);
                MonsterDead = true;
            }
        }

        private void FightChecking ()
        {
            if (MonsterFight.MonsterCurrentHP <= 0)
            {
                FightVictory();
            }
            else if (!CheckGroup() || (CheckGroup() && Turncount%2 == 0))
            {
                if (MonsterFight.IsBurning) //Le monstre perd 10% hp si il brûle
                {
                    FightMessage += "La cible brûle et subit " + MonsterFight.BurnTic() + " points de dégâts ! ";
                    if (MonsterFight.MonsterCurrentHP <= 0) //Check si meurt avec brûlure
                    {
                        FightVictory();
                    }
                    else
                    {
                        MonsterHit();
                        FightMessage += CharactBurn();
                        FightMessage += CharacterPoisoned();
                        CheckCharactDead();
                    }
                }
                else if (FightMessage != "Vous ne pouvez plus lancer ce sort ! ") //Le monstre passe son tour si le joueur est con
                {
                    MonsterHit();
                    FightMessage += CharactBurn();
                    FightMessage += CharacterPoisoned(); 
                    CheckCharactDead();
                }
                else if (MonsterFight.IsFrozen) //Le monstre ne joue pas si gelé
                {
                    FightMessage += "Vous avez gelé la cible !";
                    MonsterFight.Frozen(); //dégèle
                }
            }
        }
        private void FightVictory()
        {
            MonsterFight.MonsterCurrentHP = 0;
            FightMessage += "Cela suffit à vaincre le monstre, cette victoire vous rapporte " + MonsterFight.XpGranted +
                " points d'expérience ! ";
            FightMessage += CheckQuest();
            if (MonsterFight.MonsterBreed == TypeOfBreed.RicoChico)
            {
                GameMap.MapLayout[246][250].ChanceToTriggerFight = 0.0;
            }
            if (MonsterFight.MonsterBreed == TypeOfBreed.Joybean)
            {
                GameMap.MapLayout[428][58].ChanceToTriggerFight = 0.0;
                Player.Joydead = true;
            }
            if (MonsterFight.MonsterBreed == TypeOfBreed.EternalScorpio)
            {
                GameMap.MapLayout[499][499].ChanceToTriggerFight = 0.0;
                Player.Scorpiodead = true;
            }
            if (MonsterFight.MonsterBreed == TypeOfBreed.Cheftontaton)
            {
                GameMap.MapLayout[36][401].ChanceToTriggerFight = 0.0;
                Player.Tontatondead = true;
            }
            if (MonsterFight.MonsterBreed == TypeOfBreed.Sunwukong)
            {
                GameMap.MapLayout[72][53].ChanceToTriggerFight = 0.0;
                Player.Wukongdead = true;
            }
            Player.CurrentXp += MonsterFight.XpGranted;
            if(Player.PartyMember != null)
            {
                Player.PartyMember.CurrentXp += MonsterFight.XpGranted;
            }
            if (new Random().Next(0, 2) == 1 || MonsterFight.MonsterBreed == TypeOfBreed.RicoChico)
            {
                Stuff droppedItem = MonsterFight.DropItem();
                Player.LootStuff(droppedItem);
                FightMessage += "Vous trouvez '" + droppedItem.ItemName + "' sur le cadavre de votre ennemi ! ";
            }
            if(MonsterFight.GetType() == typeof(Humanoid))
            {
                var humanoidMob = (Humanoid)MonsterFight;
                Player.LootGold(humanoidMob.DropsCoins());
            }
            MonsterDead = true;
            if (Player.CurrentXp >= Player.XpToLevel)
            {
                LevelUp(Player);
            }
            if (Player.PartyMember != null && Player.PartyMember.CurrentXp >= Player.PartyMember.XpToLevel)
            {
                LevelUp(Player.PartyMember);
            }
        }

        private bool CheckGroup()
        {
            return Player.PartyMember != null && Player.PartyMember.CurrentHitPoints >= 0;
        }

        private string CheckQuest()
        {
            string message = "";
            foreach (var quest in Player.QuestsBook)
            {
                if (MonsterFight.MonsterBreed == quest.Target)
                {
                    quest.Status = true;
                    message = " Cela vous permet aussi de valider une quête. ";
                }
            }
            return message;
        }

        private void CheckCollectQuest()
        {
            if (Player.CollectQuest.CollectMap[Player.CollectPosI][Player.CollectPosJ].HasMonsterCollectQuest)
            {
                Player.CollectQuest.QuestEnd = true;
            }
            else if (Player.CollectQuest.CollectMap[Player.CollectPosI][Player.CollectPosJ].HasQuestTarget)
            {
                Player.CollectQuest.CollectMap[Player.CollectPosI][Player.CollectPosJ].HasQuestTarget = false;
                Player.CollectQuest.CurrentTarget--;
                if (Player.CollectQuest.CurrentTarget == 0)
                {
                    Player.CollectQuest.QuestEnd = true;
                }
            }
        }

        public void ValidQuestCollect()
        {
            Player.CollectQuest.Status = true;
            GameMap.MapLayout[Player.PositionI][Player.PositionJ].IsACollectDestination = false;
            FormShow = TypeOfShow.Map;
        }

        public void MonsterHit()
        {
            if (MonsterFight.MonsterBreed == TypeOfBreed.RicoChico && (!Player.Joydead || !Player.Scorpiodead || !Player.Tontatondead || !Player.Wukongdead))
            {
                FightMessage = "Vous touchez le grand Rico Chico mais il vous rit au nez et vous balaye d'une main. Vous êtes Ko. Revenez après avoir reconstruit la relique";
                Player.CurrentHitPoints = 0;
                PlayerDead = true;
                Player.CurrentXp /= 2;
            }
            else
            {
                MonsterFight.SelectHit();
                if (MonsterFight.MonsterHit.IsGroupHit && Player.PartyMember != null)
                {
                    FightMessage += MonsterFight.DoubleHit(Player, Player.PartyMember);
                }
                else
                { 
                    int whoGetsHit = new Random().Next(0, 2);
                    if (Player.PartyMember != null && whoGetsHit == 0 && Player.PartyMember.CurrentHitPoints > 0)
                    {
                        FightMessage += MonsterFight.Hit(Player.PartyMember);
                    }
                    else
                    {
                        FightMessage += MonsterFight.Hit(Player);
                    }
                }
                if (Player.PartyMember != null && Player.PartyMember.CurrentHitPoints < 0)
                {
                    Player.PartyMember.CurrentHitPoints = 0;
                }
                
            }
        }

        private void CheckCharactDead ()
        {
            if (Player.CurrentHitPoints <= 0 && !MonsterDead)
            {
                Player.CurrentHitPoints = 0;
                PlayerDead = true;
                FightMessage = "Vous êtes mort, des goblins sortent de l'ombre pour vous emmener rapidement dans le dernier village que vous avez visité. ";
                FightMessage += "Vous perdez la moitié de votre expérience. ";
                Player.CurrentXp /= 2;
            }
        }

        private string CharactBurn()
        {
            string s = "";
            if(Player.IsBurning)
            {
                int damage = Player.CurrentHitPoints / 10;
                Player.CurrentHitPoints -= damage;
                s += "vous brulez et subissez " + damage + " dégats";
                Player.BurnDuration--;
                if(Player.BurnDuration == 0)
                {
                    Player.IsBurning = false;
                }
            }
            if (Player.PartyMember != null && Player.PartyMember.IsBurning)
            {
                int damage = Player.PartyMember.CurrentHitPoints / 10;
                Player.PartyMember.CurrentHitPoints -= damage;
                s += Player.PartyMember.Name + " brule et subit " + damage + " dégats";
                Player.PartyMember.BurnDuration--;
                if (Player.PartyMember.BurnDuration == 0)
                {
                    Player.PartyMember.IsBurning = false;
                }
            }
            return s;
        }

        public string CharacterPoisoned()
        {
            string s = "";
            if(Player.IsPoisoned)
            {
                Player.CurrentHitPoints -= Player.PoisonDamage;
                s += "vous etes empoisonné et subissez " + Player.PoisonDamage + " dégats ";
                Player.PoisonDamage = Player.PoisonDamage * 2;
            }

            if (Player.PartyMember != null && Player.PartyMember.IsPoisoned)
            {
                Player.PartyMember.CurrentHitPoints -= Player.PartyMember.PoisonDamage;
                s += Player.PartyMember.Name + " est empoisonné et subissez " + Player.PartyMember.PoisonDamage + " dégats ";
                Player.PartyMember.PoisonDamage = Player.PartyMember.PoisonDamage * 2;
            }
            return s;
        }
        public void SwitchFightSpells()
        {
            ShowFightSpells = true;
            ShowFightInventory = false;
        }

        public void SwitchFightInventory()
        {
            ShowFightInventory = true;
            ShowFightSpells = false;
        }

        //Fonction qui va choisir aléatoirement un monstre dans le pool du Biome
        private Monster SelectEnemy()
        {
            List<Type> list = GameMap.MapLayout[Player.PositionI][Player.PositionJ].SquareBiome.MonsterPool;
            Type randomClassType = list[new Random().Next(list.Count)];
            dynamic monster = Activator.CreateInstance(randomClassType);
            FightMessage = "Vous êtes agressé par " + monster.MonsterName + ", il faut le vaincre pour survivre.";
            return monster;
        }

        //gestion de l'équipe
        public void PartyRest()
        {
            Player.lastRestVillageI = Player.PositionI;
            Player.LastRestVillageJ = Player.PositionJ;
            Player.Rest();
            Player.SetIsRested(true);
            if (Player.PartyMember != null)
            {
                Player.PartyMember.Rest();
                Player.PartyMember.SetIsRested(true);
            }
        }

        public void Recrut(Character player)
        {
            Player.PartyMember = player;
            player.PartyMember = Player;
            while(player.Level < Player.Level)
            {
                player.CurrentXp = player.XpToLevel;
                LevelUp(player);
            }
            player.CurrentXp = Player.CurrentXp;
            player.Rest();
            Player.SetCoins(-player.RecruitingPrice);
        }

        public void Solo()
        {
            Player.PartyMember = null;
        }


        //Gestion de déplacement et de trigger fight
        public void GoUp()
        {
            if (ShowQuestGiver)
            {
                SwitchShowInventoryList();
            }
            if (Player.PositionI > 0)
            {
                Player.PositionI--;
                GameMap.UpdateMapDisplay(Player);
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoDown()
        {
            if (ShowQuestGiver)
            {
                SwitchShowInventoryList();
            }
            if (Player.PositionI < 499)
            {
                Player.PositionI++;
                GameMap.UpdateMapDisplay(Player);
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoLeft()
        {
            if (ShowQuestGiver)
            {
                SwitchShowInventoryList();
            }
            if (Player.PositionJ > 0)
            {
                Player.PositionJ--;
                GameMap.UpdateMapDisplay(Player);
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoRight()
        {
            if (ShowQuestGiver)
            {
                SwitchShowInventoryList();
            }
            if (Player.PositionJ < 499)
            {
                Player.PositionJ++;
                GameMap.UpdateMapDisplay(Player);
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoUpCollect()
        {
            if(Player.CollectPosI > 0)
            {
                Player.CollectPosI--;
                CheckCollectQuest();
            }
        }

        public void GoDownCollect()
        {
            if (Player.CollectPosI < 9)
            {
                Player.CollectPosI++;
                CheckCollectQuest();
            }
        }

        public void GoLeftCollect()
        {
            if (Player.CollectPosJ > 0)
            {
                Player.CollectPosJ--;
                CheckCollectQuest();
            }
        }

        public void GoRightCollect()
        {
            if (Player.CollectPosJ < 9)
            {
                Player.CollectPosJ++;
                CheckCollectQuest();
            }
        }
    }
}
