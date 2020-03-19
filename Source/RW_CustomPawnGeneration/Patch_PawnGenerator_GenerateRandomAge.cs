using System;
using HarmonyLib;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000007 RID: 7
	[HarmonyPatch(typeof(PawnGenerator), "GenerateRandomAge")]
	public static class Patch_PawnGenerator_GenerateRandomAge
	{
		// Token: 0x06000006 RID: 6 RVA: 0x0000228C File Offset: 0x0000048C
		[HarmonyPriority(0)]
		[HarmonyPrefix]
		public static void Prefix(Pawn pawn, PawnGenerationRequest request)
		{
			bool flag = pawn.RaceProps.hasGenders && (Settings.UnforcedGender || request.FixedGender == null);
			if (flag)
			{
				int genderSlider = Settings.GenderSlider;
				Gender gender = (genderSlider == 100) ? Gender.Female : ((genderSlider == 0) ? Gender.Male : ((Rand.Value < (float)genderSlider / 100f) ? Gender.Female : Gender.Male));
				bool flag2 = pawn.gender != gender;
				if (flag2)
				{
					pawn.gender = gender;
				}
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002310 File Offset: 0x00000510
		[HarmonyPostfix]
		public static void Postfix(Pawn pawn, PawnGenerationRequest request)
		{
			bool flag = !Settings.SeparateGender || pawn.gender == Gender.Male;
			if (flag)
			{
				Patch_PawnGenerator_GenerateRandomAge_Internal.Postfix(pawn, Settings.Male_AgeCurve, Settings.Male_HasMinAge, Settings.Male_HasMaxAge, Settings.Male_MinAgeSoft, Settings.Male_MinAge, Settings.Male_MaxAge);
			}
			else
			{
				Patch_PawnGenerator_GenerateRandomAge_Internal.Postfix(pawn, Settings.Female_AgeCurve, Settings.Female_HasMinAge, Settings.Female_HasMaxAge, Settings.Female_MinAgeSoft, Settings.Female_MinAge, Settings.Female_MaxAge);
			}
		}
	}
}
