using System;
using HarmonyLib;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000006 RID: 6
	[HarmonyPatch(typeof(Pawn_AgeTracker), "AgeTick")]
	public static class Patch_Pawn_AgeTracker_AgeTick
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002230 File Offset: 0x00000430
		[HarmonyPrefix]
		public static void Patch(Pawn_AgeTracker __instance, Pawn ___pawn)
		{
			int num = (!Settings.SeparateGender || ___pawn.gender == Gender.Male) ? Settings.Male_AgeTick : Settings.Female_AgeTick;
			bool flag = num == 0;
			if (flag)
			{
				long ageBiologicalTicks = __instance.AgeBiologicalTicks;
				__instance.AgeBiologicalTicks = ageBiologicalTicks - 1L;
			}
			else
			{
				bool flag2 = num > 1;
				if (flag2)
				{
					__instance.AgeTickMothballed(num - 1);
				}
			}
		}
	}
}
