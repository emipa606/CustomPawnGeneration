using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000003 RID: 3
	[HarmonyPatch(typeof(ParentRelationUtility), "GetMother")]
	public static class Patch_ParentRelationUtility_GetMother
	{
		// Token: 0x06000002 RID: 2 RVA: 0x000020E4 File Offset: 0x000002E4
		[HarmonyPriority(0)]
		[HarmonyPostfix]
		public static void Patch(this Pawn pawn, ref Pawn __result)
		{
			bool flag = !Settings.UnforcedGender;
			if (!flag)
			{
				bool flag2 = __result != null;
				if (!flag2)
				{
					bool flag3 = !pawn.RaceProps.IsFlesh;
					if (!flag3)
					{
						List<DirectPawnRelation> directRelations = pawn.relations.DirectRelations;
						for (int i = directRelations.Count - 1; i >= 0; i--)
						{
							DirectPawnRelation directPawnRelation = directRelations[i];
							bool flag4 = directPawnRelation.def == PawnRelationDefOf.Parent;
							if (flag4)
							{
								__result = directPawnRelation.otherPawn;
								break;
							}
						}
					}
				}
			}
		}
	}
}
