using System;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000008 RID: 8
	public static class Patch_PawnGenerator_GenerateRandomAge_Internal
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002384 File Offset: 0x00000584
		public static void Postfix(Pawn pawn, bool AgeCurve, bool HasMinAge, bool HasMaxAge, bool MinAgeSoft, int MinAge, int MaxAge)
		{
			bool flag = HasMinAge || HasMaxAge;
			if (flag)
			{
				bool flag2 = HasMinAge && MinAgeSoft && pawn.ageTracker.AgeBiologicalYears <= MinAge;
				if (!flag2)
				{
					long num = pawn.ageTracker.AgeBiologicalTicks;
					long num2 = (long)pawn.kindDef.minGenerationAge;
					long num3 = HasMinAge ? ((long)MinAge) : num2;
					long num4 = (long)pawn.kindDef.maxGenerationAge;
					long num5 = HasMaxAge ? ((long)MaxAge) : num4;
					long len = num4 - num2;
					long len2 = num5 - num3;
					if (AgeCurve)
					{
						num = Patch_PawnGenerator_GenerateRandomAge_Internal.PseudoPreserveCurve(num, num2, num3, num5, len, len2);
					}
					num3 *= 3600000L;
					num5 *= 3600000L;
					pawn.ageTracker.AgeBiologicalTicks = ((num < num3) ? num3 : ((num > num5) ? num5 : num));
				}
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002454 File Offset: 0x00000654
		public static long PseudoPreserveCurve(long age, long min0, long min1, long max1, long len0, long len1)
		{
			long num = (len0 > max1) ? ((len0 - max1) / max1) : ((len0 < max1) ? ((max1 - len0) / max1) : 1L);
			return (age - min0 * 3600000L) / len0 * len1 * num + min1 * 3600000L / 2L;
		}

		// Token: 0x04000001 RID: 1
		public const long AGE = 3600000L;
	}
}
