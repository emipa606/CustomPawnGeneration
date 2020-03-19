using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000002 RID: 2
	[HarmonyPatch(typeof(ParentRelationUtility), "GetFather")]
	public static class Patch_ParentRelationUtility_GetFather
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
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
