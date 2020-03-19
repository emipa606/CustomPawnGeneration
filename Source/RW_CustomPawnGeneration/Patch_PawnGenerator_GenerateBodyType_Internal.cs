using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x0200000A RID: 10
	public static class Patch_PawnGenerator_GenerateBodyType_Internal
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002528 File Offset: 0x00000728
		public static void Patch(Pawn pawn, BodyTypeDef Average, bool BodyFix, bool BodyThin, bool BodyAverage, bool BodyFat, bool BodyHulk)
		{
			BodyTypeDef bodyType = pawn.story.bodyType;
			bool flag = bodyType == BodyTypeDefOf.Thin;
			if (flag)
			{
				if (BodyThin)
				{
					return;
				}
			}
			else
			{
				bool flag2 = bodyType == BodyTypeDefOf.Male || bodyType == BodyTypeDefOf.Female;
				if (flag2)
				{
					if (BodyFix)
					{
						pawn.story.bodyType = Average;
					}
					if (BodyAverage)
					{
						return;
					}
				}
				else
				{
					bool flag3 = bodyType == BodyTypeDefOf.Fat;
					if (flag3)
					{
						if (BodyFat)
						{
							return;
						}
					}
					else
					{
						bool flag4 = bodyType == BodyTypeDefOf.Hulk;
						if (flag4)
						{
							if (BodyHulk)
							{
								return;
							}
						}
					}
				}
			}
			HashSet<int> hashSet = new HashSet<int>();
			if (BodyThin)
			{
				hashSet.Add(0);
			}
			if (BodyAverage)
			{
				hashSet.Add(1);
			}
			if (BodyFat)
			{
				hashSet.Add(2);
			}
			if (BodyHulk)
			{
				hashSet.Add(3);
			}
			int num;
			bool flag5 = !hashSet.TryRandomElement(out num);
			if (!flag5)
			{
				switch (num)
				{
				case 0:
					pawn.story.bodyType = BodyTypeDefOf.Thin;
					break;
				case 1:
					pawn.story.bodyType = Average;
					break;
				case 2:
					pawn.story.bodyType = BodyTypeDefOf.Fat;
					break;
				case 3:
					pawn.story.bodyType = BodyTypeDefOf.Hulk;
					break;
				}
			}
		}
	}
}
