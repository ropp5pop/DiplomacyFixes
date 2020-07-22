﻿using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace DiplomacyFixes.DiplomaticAction.WarPeace.Conditions
{
    class HasEnoughInfluenceForPeaceCondition : AbstractCostCondition
    {
        protected override TextObject FailedConditionText => new TextObject(StringConstants.NOT_ENOUGH_INFLUENCE);

        protected override bool ApplyConditionInternal(Kingdom kingdom, Kingdom otherKingdom, ref TextObject textObject, bool forcePlayerCharacterCosts = false)
        {
            bool hasEnoughInfluence = DiplomacyCostCalculator.DetermineCostForMakingPeace(kingdom, otherKingdom, forcePlayerCharacterCosts).InfluenceCost.CanPayCost();
            if (!hasEnoughInfluence)
            {
                textObject = FailedConditionText;
            }
            return hasEnoughInfluence;
        }
    }
}
