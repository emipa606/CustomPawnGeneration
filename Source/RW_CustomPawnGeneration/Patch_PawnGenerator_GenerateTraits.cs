using System;
using HarmonyLib;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x0200000B RID: 11
	[HarmonyPatch(typeof(PawnGenerator), "GenerateTraits")]
	public static class Patch_PawnGenerator_GenerateTraits
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002694 File Offset: 0x00000894
		[HarmonyPriority(0)]
		[HarmonyPostfix]
		public static void Patch(Pawn pawn, PawnGenerationRequest request)
		{
			bool flag = !Settings.SeparateGender || pawn.gender == Gender.Male;
			if (flag)
			{
				Patch_PawnGenerator_GenerateTraits_Internal.Patch(pawn, request, Settings.Male_TraitsForced);
			}
			else
			{
				Patch_PawnGenerator_GenerateTraits_Internal.Patch(pawn, request, Settings.Female_TraitsForced);
			}
		}
	}
}
