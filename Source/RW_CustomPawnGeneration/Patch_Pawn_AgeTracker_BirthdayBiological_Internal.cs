using System;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000005 RID: 5
	public static class Patch_Pawn_AgeTracker_BirthdayBiological_Internal
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000021CC File Offset: 0x000003CC
		public static void Patch(Pawn_AgeTracker __instance, bool HasMaxAge, int MaxAge, bool MaxAgeChrono)
		{
			bool flag = !HasMaxAge;
			if (!flag)
			{
				long ageBiologicalTicks = __instance.AgeBiologicalTicks;
				long num = ageBiologicalTicks / 3600000L;
				bool flag2 = num > (long)MaxAge;
				if (flag2)
				{
					num = (num - (long)MaxAge) * 3600000L;
					__instance.AgeBiologicalTicks -= num;
					if (MaxAgeChrono)
					{
						__instance.AgeChronologicalTicks += num;
					}
				}
			}
		}
	}
}
