using System.Linq;

using GuildWars2.Models.Core;
using GuildWars2.Models.Items;

namespace GuildWebsite.Helpers
{
    public static class CharacterHelper
    {
        public static int CalculateAttribute(Character character, AttributeType attributeType)
        {
            var attributeTotal = 0;

            switch (attributeType)
            {
                case AttributeType.Power:
                case AttributeType.Precision:
                case AttributeType.Toughness:
                case AttributeType.Vitality:
                    attributeTotal = 1000;
                    break;
            }

            attributeTotal += CalculateAttributeForEquipment(character.Helm, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Coat, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Shoulders, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Gloves, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Leggings, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Boots, attributeType);

            attributeTotal += CalculateAttributeForEquipment(character.WeaponA1, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.WeaponA2, attributeType);

            attributeTotal += CalculateAttributeForEquipment(character.Accessory1, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Accessory2, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Backpiece, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Amulet, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Ring1, attributeType);
            attributeTotal += CalculateAttributeForEquipment(character.Ring2, attributeType);

            return attributeTotal;
        }

        private static int CalculateAttributeForEquipment(EquipmentItem equipment, AttributeType attributeType)
        {
            int attributeTotal = 0;

            if (equipment != null)
            {
                if (equipment.Stats != null)
                {
                    switch (attributeType)
                    {
                        case AttributeType.BoonDuration:
                            attributeTotal += equipment.Stats.Attributes.BoonDuration;
                            break;
                        case AttributeType.ConditionDamage:
                            attributeTotal += equipment.Stats.Attributes.ConditionDamage;
                            break;
                        case AttributeType.ConditionDuration:
                            attributeTotal += equipment.Stats.Attributes.ConditionDuration;
                            break;
                        case AttributeType.CritDamage:
                            attributeTotal += equipment.Stats.Attributes.CritDamage;
                            break;
                        case AttributeType.Healing:
                            attributeTotal += equipment.Stats.Attributes.HealingPower;
                            break;
                        case AttributeType.Power:
                            attributeTotal += equipment.Stats.Attributes.Power;
                            break;
                        case AttributeType.Precision:
                            attributeTotal += equipment.Stats.Attributes.Precision;
                            break;
                        case AttributeType.Toughness:
                            attributeTotal += equipment.Stats.Attributes.Toughness;
                            break;
                        case AttributeType.Vitality:
                            attributeTotal += equipment.Stats.Attributes.Vitality;
                            break;
                    }
                }

                if (equipment.Upgrades != null)
                {
                    foreach (var upgrade in equipment.Upgrades)
                    {
                        if (upgrade.InfixUpgrade != null)
                        {
                            attributeTotal += upgrade.InfixUpgrade.Attributes.FirstOrDefault(attribute => attribute.Type == attributeType)?.Modifier ?? 0;
                        }
                    }
                }

                if (equipment.Item is IInfixUpgradeable)
                {
                    var infixUpgradeable = equipment.Item as IInfixUpgradeable;

                    if (infixUpgradeable.InfixUpgrade != null)
                    {
                        attributeTotal += infixUpgradeable.InfixUpgrade.Attributes.FirstOrDefault(attribute => attribute.Type == attributeType)?.Modifier ?? 0;
                    }
                }
            }            

            return attributeTotal;
        }
    }
}