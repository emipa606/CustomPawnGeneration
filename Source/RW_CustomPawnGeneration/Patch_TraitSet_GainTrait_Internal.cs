using System;
using System.Collections.Generic;
using RimWorld;

namespace RW_CustomPawnGeneration
{
	// Token: 0x0200000E RID: 14
	public static class Patch_TraitSet_GainTrait_Internal
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002804 File Offset: 0x00000A04
		public static void Prefix(TraitSet __instance, Trait trait, HashSet<string> TraitsForced, HashSet<string> TraitsBlocked)
		{
			string item = string.Format("{0}_{1}", trait.def.defName, trait.Degree);
			bool flag = TraitsForced != null && TraitsForced.Contains(item);
			bool flag2 = TraitsBlocked != null && TraitsBlocked.Contains(item);
			bool flag3 = (flag || flag2) && !__instance.HasTrait(trait.def);
			if (flag3)
			{
				__instance.allTraits.Add(trait);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002878 File Offset: 0x00000A78
		public static void Postfix(TraitSet __instance, Trait trait, HashSet<string> TraitsForced, HashSet<string> TraitsBlocked)
		{
			string item = string.Format("{0}_{1}", trait.def.defName, trait.Degree);
			bool flag = TraitsForced != null && TraitsForced.Contains(item);
			bool flag2 = TraitsBlocked != null && TraitsBlocked.Contains(item);
			bool flag3 = (flag || flag2) && __instance.HasTrait(trait.def);
			if (flag3)
			{
				__instance.allTraits.Remove(trait);
			}
		}
	}
}
