using System;
using HarmonyLib;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x0200000F RID: 15
	[HarmonyPatch(typeof(PawnGenerator), "GenerateOrRedressPawnInternal")]
	public static class Patch_PawnGenerator_GenerateOrRedressPawnInternal
	{
		// Token: 0x06000012 RID: 18 RVA: 0x000028E8 File Offset: 0x00000AE8
		[HarmonyPostfix]
		[HarmonyPriority(0)]
		public static void Patch(Pawn __result, PawnGenerationRequest request)
		{
			bool flag = !Settings.SeparateGender || __result.gender == Gender.Male;
			if (flag)
			{
				Patch_PawnGenerator_GenerateOrRedressPawnInternal_Internal.Patch(__result, request, Settings.Male_Hediffs);
			}
			else
			{
				Patch_PawnGenerator_GenerateOrRedressPawnInternal_Internal.Patch(__result, request, Settings.Female_Hediffs);
			}
		}
	}
}
