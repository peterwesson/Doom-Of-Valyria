using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using GuildWars2.API;
using GuildWars2.Models.Guilds;
using GuildWars2.Models.Items;

using GuildWebsite.Global;
using GuildWebsite.Models.ViewModels.Members;

namespace GuildWebsite.Controllers
{
    public class MembersController : BaseController
    {
        public MembersController() : base()
        {

        }

        public async Task<ActionResult> Index()
        {
            using (var api = new GuildWars2API(APIkey))
            {
                var guild = System.Web.HttpContext.Current.Session["Guild"] as Guild;
                
                var members = await api.GetGuildMembers(guild.Id);

                return View(members);
            }
        }

        public async Task<ActionResult> Member(string id, int? minLevel = null)
        {
            using (var api = new GuildWars2API(APIkey))
            {
                var accountInfoTask = api.GetAccount();
                var charactersTask = api.GetCharacters();

                await Task.WhenAll(new List<Task> { accountInfoTask, charactersTask });

                var characters = charactersTask.Result.Where(character => minLevel == null || character.Level >= minLevel).ToList();

                foreach (var character in characters)
                {
                    character.ProfessionInfo = GlobalAssets.Professions[character.Profession.ToString()];
                }

                var viewModel = new MemberViewModel
                {
                    AccountInfo = accountInfoTask.Result,
                    Characters = characters
                };

                foreach (var accountMastery in viewModel.AccountInfo.Masteries)
                {
                    accountMastery.Mastery = GlobalAssets.Masteries[accountMastery.Id];
                }

                return View(viewModel);
            }
        }

        public async Task<ActionResult> Character(string id)
        {
            using (var api = new GuildWars2API(APIkey))
            {
                var character = await api.GetCharacter(id);

                foreach (var equipment in character.Equipment)
                {
                    if (equipment.SkinId.HasValue)
                    {
                        equipment.Skin = GlobalAssets.Skins[equipment.SkinId.Value];
                    }   
                                     
                    equipment.Item = GlobalAssets.Items[equipment.ItemId];

                    if (equipment.InfusionIds != null)
                    {
                        equipment.Infusions = equipment.InfusionIds.Select(infusionId => GlobalAssets.Items[infusionId] as UpgradeComponent).ToList();
                    }

                    if (equipment.UpgradeIds != null)
                    {
                        equipment.Upgrades = equipment.UpgradeIds.Select(upgradeId => GlobalAssets.Items[upgradeId] as UpgradeComponent).ToList();
                    }
                }

                if (character.Skills.PvE.Heal.HasValue)
                {
                    character.Skills.PvE.HealSkill = GlobalAssets.Skills[character.Skills.PvE.Heal.Value];
                }
                if (character.Skills.PvE.Utilities[0].HasValue)
                {
                    character.Skills.PvE.UtilitySkill1 = GlobalAssets.Skills[character.Skills.PvE.Utilities[0].Value];
                }
                if (character.Skills.PvE.Utilities[1].HasValue)
                {
                    character.Skills.PvE.UtilitySkill2 = GlobalAssets.Skills[character.Skills.PvE.Utilities[1].Value];
                }
                if (character.Skills.PvE.Utilities[2].HasValue)
                {
                    character.Skills.PvE.UtilitySkill3 = GlobalAssets.Skills[character.Skills.PvE.Utilities[2].Value];
                }
                if (character.Skills.PvE.Elite.HasValue)
                {
                    character.Skills.PvE.EliteSkill = GlobalAssets.Skills[character.Skills.PvE.Elite.Value];
                }

                var profession = GlobalAssets.Professions[character.Profession.ToString()];

                character.WeaponA1 = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.WeaponA1);
                if (character.WeaponA1 != null)
                {
                    foreach (var weapon in profession.Weapons[(character.WeaponA1.Item as Weapon).WeaponType].Skills)
                    {
                        weapon.Skill = GlobalAssets.Skills[weapon.Id];
                    }
                }                

                character.WeaponA2 = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.WeaponA2);
                if (character.WeaponA2 != null)
                {
                    foreach (var weapon in profession.Weapons[(character.WeaponA2.Item as Weapon).WeaponType].Skills)
                    {
                        weapon.Skill = GlobalAssets.Skills[weapon.Id];
                    }
                }

                character.WeaponB1 = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.WeaponB1);
                if (character.WeaponB1 != null)
                {
                    foreach (var weapon in profession.Weapons[(character.WeaponB1.Item as Weapon).WeaponType].Skills)
                    {
                        weapon.Skill = GlobalAssets.Skills[weapon.Id];
                    }
                }

                character.WeaponB2 = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.WeaponB2);
                if (character.WeaponB2 != null)
                {
                    foreach (var weapon in profession.Weapons[(character.WeaponB2.Item as Weapon).WeaponType].Skills)
                    {
                        weapon.Skill = GlobalAssets.Skills[weapon.Id];
                    }
                }

                character.Helm = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Helm);
                character.Shoulders = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Shoulders);
                character.Coat = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Coat);
                character.Gloves = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Gloves);
                character.Leggings = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Leggings);
                character.Boots = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Boots);

                character.Backpiece = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Backpack);
                character.Accessory1 = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Accessory1);
                character.Accessory2 = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Accessory2);
                character.Amulet = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Amulet);
                character.Ring1 = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Ring1);
                character.Ring2 = character.Equipment.FirstOrDefault(equipment => equipment.Slot == EquipmentSlot.Ring2);

                character.ProfessionInfo = profession;

                return View(character);
            }
        }
    }
}