using System;
using HarmonyLib;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(Pawn_AgeTracker), "BirthdayBiological")]
	public static class Patch_Pawn_AgeTracker_BirthdayBiological
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002178 File Offset: 0x00000378
		[HarmonyPrefix]
		public static void Patch(Pawn_AgeTracker __instance, Pawn ___pawn)
		{
			bool flag = !Settings.SeparateGender || ___pawn.gender == Gender.Male;
			if (flag)
			{
				Patch_Pawn_AgeTracker_BirthdayBiological_Internal.Patch(__instance, Settings.Male_HasMaxAge, Settings.Male_MaxAge, Settings.Male_MaxAgeChrono);
			}
			else
			{
				Patch_Pawn_AgeTracker_BirthdayBiological_Internal.Patch(__instance, Settings.Female_HasMaxAge, Settings.Female_MaxAge, Settings.Female_MaxAgeChrono);
			}
		}
	}
}
