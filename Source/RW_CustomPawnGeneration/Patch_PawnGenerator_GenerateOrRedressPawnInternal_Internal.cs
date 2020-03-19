using System;
using System.Collections.Generic;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000010 RID: 16
	public static class Patch_PawnGenerator_GenerateOrRedressPawnInternal_Internal
	{
		// Token: 0x06000013 RID: 19 RVA: 0x0000292C File Offset: 0x00000B2C
		public static void Patch(Pawn __result, PawnGenerationRequest request, Dictionary<string, int> Hediffs)
		{
			bool flag = Hediffs == null;
			if (!flag)
			{
				foreach (KeyValuePair<string, int> keyValuePair in Hediffs)
				{
					string[] array = keyValuePair.Key.Split(new char[]
					{
						'\n'
					});
					bool flag2 = array.Length < 3;
					if (!flag2)
					{
						HediffDef hediffDef = HediffDef.Named(array[0]);
						BodyDef bodyDef = null;
						BodyPartRecord bodyPartRecord = null;
						foreach (BodyDef bodyDef2 in DefDatabase<BodyDef>.AllDefs)
						{
							bool flag3 = bodyDef2.defName == array[1];
							if (flag3)
							{
								bodyDef = bodyDef2;
								break;
							}
						}
						foreach (BodyPartRecord bodyPartRecord2 in bodyDef.AllParts)
						{
							bool flag4 = bodyPartRecord2.Label == array[2];
							if (flag4)
							{
								bodyPartRecord = bodyPartRecord2;
								break;
							}
						}
						bool flag5 = hediffDef == null || bodyDef == null || bodyPartRecord == null;
						if (!flag5)
						{
							bool flag6 = __result.def.race.body != bodyDef;
							if (!flag6)
							{
								bool flag7 = Rand.Value < (float)keyValuePair.Value / 100f;
								if (flag7)
								{
									__result.health.AddHediff(hediffDef, bodyPartRecord, null, null);
								}
							}
						}
					}
				}
			}
		}
	}
}
