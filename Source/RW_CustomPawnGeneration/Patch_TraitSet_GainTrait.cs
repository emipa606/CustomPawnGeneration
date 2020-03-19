using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x0200000D RID: 13
	[HarmonyPatch(typeof(TraitSet), "GainTrait")]
	public static class Patch_TraitSet_GainTrait
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000276C File Offset: 0x0000096C
		[HarmonyPrefix]
		public static void Prefix(TraitSet __instance, Trait trait, Pawn ___pawn)
		{
			bool flag = !Settings.SeparateGender || ___pawn.gender == Gender.Male;
			if (flag)
			{
				Patch_TraitSet_GainTrait_Internal.Prefix(__instance, trait, Settings.Male_TraitsForced, Settings.Male_TraitsBlocked);
			}
			else
			{
				Patch_TraitSet_GainTrait_Internal.Prefix(__instance, trait, Settings.Female_TraitsForced, Settings.Female_TraitsBlocked);
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000027B8 File Offset: 0x000009B8
		[HarmonyPostfix]
		public static void Postfix(TraitSet __instance, Trait trait, Pawn ___pawn)
		{
			bool flag = !Settings.SeparateGender || ___pawn.gender == Gender.Male;
			if (flag)
			{
				Patch_TraitSet_GainTrait_Internal.Postfix(__instance, trait, Settings.Male_TraitsForced, Settings.Male_TraitsBlocked);
			}
			else
			{
				Patch_TraitSet_GainTrait_Internal.Postfix(__instance, trait, Settings.Female_TraitsForced, Settings.Female_TraitsBlocked);
			}
		}
	}
}
