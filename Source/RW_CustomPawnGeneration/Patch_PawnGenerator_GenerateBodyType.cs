using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000009 RID: 9
	[HarmonyPatch(typeof(PawnGenerator), "GenerateBodyType")]
	public static class Patch_PawnGenerator_GenerateBodyType
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000024A4 File Offset: 0x000006A4
		[HarmonyPriority(0)]
		[HarmonyPostfix]
		public static void Patch(Pawn pawn)
		{
			bool flag = !Settings.SeparateGender || pawn.gender == Gender.Male;
			if (flag)
			{
				Patch_PawnGenerator_GenerateBodyType_Internal.Patch(pawn, (pawn.gender == Gender.Male) ? BodyTypeDefOf.Male : BodyTypeDefOf.Female, Settings.Male_BodyFix, Settings.Male_BodyThin, Settings.Male_BodyAverage, Settings.Male_BodyFat, Settings.Male_BodyHulk);
			}
			else
			{
				Patch_PawnGenerator_GenerateBodyType_Internal.Patch(pawn, BodyTypeDefOf.Female, Settings.Female_BodyFix, Settings.Female_BodyThin, Settings.Female_BodyAverage, Settings.Female_BodyFat, Settings.Female_BodyHulk);
			}
		}
	}
}
