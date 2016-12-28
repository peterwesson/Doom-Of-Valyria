using System.Collections.Generic;
using System.Linq;

using GuildWars2.Models.Core;
using GuildWars2.Models.Items;
using GuildWars2.Models.Skills;

namespace GuildWebsite.Helpers
{
    public static class SkillHelper
    {
        public static List<EquipmentItem> GetWeaponSetA(Character character)
        {
            var weaponSetA = new List<EquipmentItem>();
            if (character.WeaponA1 != null)
            {
                weaponSetA.Add(character.WeaponA1);
            }
            else
            {
                if (character.WeaponB1 != null)
                {
                    if (!IsWeaponTwoHanded((character.WeaponB1.Item as Weapon).WeaponType))
                    {
                        if (character.WeaponA2 != null)
                        {
                            weaponSetA.Add(character.WeaponB1);
                        }
                    }
                }

            }

            if (!weaponSetA.Any() || !IsWeaponTwoHanded((weaponSetA.First().Item as Weapon).WeaponType))
            {
                if (character.WeaponA2 != null)
                {
                    if (!weaponSetA.Any())
                    {
                        weaponSetA.Add(new EquipmentItem { Item = new Weapon { WeaponType = WeaponType.None } });
                    }

                    weaponSetA.Add(character.WeaponA2);
                }
                else
                {
                    if (character.WeaponB2 != null)
                    {
                        if (weaponSetA.Any())
                        {
                            weaponSetA.Add(character.WeaponB2);
                        }
                    }
                }
            }

            return weaponSetA;
        }

        public static List<EquipmentItem> GetWeaponSetB(Character character)
        {
            var weaponSetB = new List<EquipmentItem>();
            if (character.WeaponB1 != null)
            {
                weaponSetB.Add(character.WeaponB1);
            }
            else
            {
                if (character.WeaponA1 != null)
                {
                    if (!IsWeaponTwoHanded((character.WeaponA1.Item as Weapon).WeaponType))
                    {
                        if (character.WeaponB2 != null)
                        {
                            weaponSetB.Add(character.WeaponA1);
                        }
                    }
                }

            }

            if (!weaponSetB.Any() || !IsWeaponTwoHanded((weaponSetB.First().Item as Weapon).WeaponType))
            {
                if (character.WeaponB2 != null)
                {
                    if (!weaponSetB.Any())
                    {
                        weaponSetB.Add(new EquipmentItem { Item = new Weapon { WeaponType = WeaponType.None }});
                    }

                    weaponSetB.Add(character.WeaponB2);
                }
                else
                {
                    if (character.WeaponA2 != null)
                    {
                        if (weaponSetB.Any())
                        {
                            weaponSetB.Add(character.WeaponA2);
                        }
                    }
                }
            }

            return weaponSetB;
        }

        public static Dictionary<int, IEnumerable<Skill>> GetSkillSet(List<WeaponType> weaponSet, Character character, AttunementType attunement = AttunementType.None)
        {
            var skillSet = new Dictionary<int, IEnumerable<Skill>>();

            if (weaponSet[0] != WeaponType.None)
            {
                skillSet[0] = character.ProfessionInfo.Weapons[weaponSet[0]].Skills
                    .Where(weaponSkill => weaponSkill.Slot == SlotType.Weapon_1)
                    .Where(weaponSkill => weaponSkill.Attunement == attunement)
                    .Select(weaponSkill => weaponSkill.Skill);

                skillSet[1] = new List<Skill>
                {
                    character.ProfessionInfo.Weapons[weaponSet[0]].Skills
                        .Where(weaponSkill => weaponSkill.Attunement == attunement)
                        .FirstOrDefault(weaponSkill => weaponSkill.Slot == SlotType.Weapon_2).Skill
                };

                if (character.Profession != Profession.Thief)
                {
                    skillSet[2] = new List<Skill>
                    {
                        character.ProfessionInfo.Weapons[weaponSet[0]].Skills
                            .Where(weaponSkill => weaponSkill.Attunement == attunement)
                            .FirstOrDefault(weaponSkill => weaponSkill.Slot == SlotType.Weapon_3).Skill
                    };
                }
                else
                {
                    WeaponType weapon2Type = WeaponType.Nothing;

                    if (weaponSet.Count() > 1)
                    {
                        weapon2Type = weaponSet[1];
                    }

                    skillSet[2] = new List<Skill>
                    {
                        character.ProfessionInfo.Weapons[weaponSet[0]].Skills
                            .Where(weaponSkill => weaponSkill.Slot == SlotType.Weapon_3)
                            .Where(weaponSkill => weaponSkill.Offhand == weapon2Type || weaponSet[0] == WeaponType.Staff)
                            .Where(weaponSkill => weaponSkill.Attunement == attunement)
                            .FirstOrDefault()?.Skill
                    };
                }                

                if (IsWeaponTwoHanded(weaponSet[0]))
                {
                    skillSet[3] = new List<Skill>
                    {
                        character.ProfessionInfo.Weapons[weaponSet[0]].Skills
                            .Where(weaponSkill => weaponSkill.Attunement == attunement)
                            .FirstOrDefault(weaponSkill => weaponSkill.Slot == SlotType.Weapon_4).Skill
                    };

                    skillSet[4] = new List<Skill>
                    {
                        character.ProfessionInfo.Weapons[weaponSet[0]].Skills
                            .Where(weaponSkill => weaponSkill.Attunement == attunement)
                            .FirstOrDefault(weaponSkill => weaponSkill.Slot == SlotType.Weapon_5).Skill
                    };
                }
                else if (weaponSet.Count() > 1)
                {
                    skillSet[3] = new List<Skill> { character.ProfessionInfo.Weapons[weaponSet[1]].Skills.FirstOrDefault(weaponSkill => weaponSkill.Slot == SlotType.Weapon_4).Skill };
                    skillSet[4] = new List<Skill> { character.ProfessionInfo.Weapons[weaponSet[1]].Skills.FirstOrDefault(weaponSkill => weaponSkill.Slot == SlotType.Weapon_5).Skill };
                }
            }
            else if (weaponSet.Count() > 1)
            {
                skillSet[3] = new List<Skill>
                {
                    character.ProfessionInfo.Weapons[weaponSet[1]].Skills
                        .Where(weaponSkill => weaponSkill.Attunement == attunement)
                        .FirstOrDefault(weaponSkill => weaponSkill.Slot == SlotType.Weapon_4).Skill
                };

                skillSet[4] = new List<Skill>
                {
                    character.ProfessionInfo.Weapons[weaponSet[1]].Skills
                        .Where(weaponSkill => weaponSkill.Attunement == attunement)
                        .FirstOrDefault(weaponSkill => weaponSkill.Slot == SlotType.Weapon_5).Skill
                };
            }

            return skillSet;
        }

        public static bool IsWeaponTwoHanded(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.Greatsword:
                case WeaponType.Hammer:
                case WeaponType.LongBow:
                case WeaponType.Rifle:
                case WeaponType.ShortBow:
                case WeaponType.Staff:
                    return true;
                default:
                    return false;
            }
        }

        public static string GetWeaponSetTitle(List<WeaponType> weaponSet)
        {
            if (weaponSet.Count > 1)
            {
                return $"{weaponSet[0].ToString()}/{weaponSet[1].ToString()}";
            }
            else
            {
                return $"{weaponSet[0].ToString()}";
            }
        }
    }
}