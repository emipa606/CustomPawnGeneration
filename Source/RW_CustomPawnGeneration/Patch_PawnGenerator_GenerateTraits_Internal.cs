using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x0200000C RID: 12
	public static class Patch_PawnGenerator_GenerateTraits_Internal
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000026D8 File Offset: 0x000008D8
		public static void Patch(Pawn pawn, PawnGenerationRequest request, HashSet<string> TraitsForced)
		{
			bool flag = pawn.story == null || TraitsForced == null || TraitsForced.Count == 0;
			if (!flag)
			{
				foreach (string key in TraitsForced)
				{
					Trait trait = Tools.NewTrait(key);
					bool flag2 = trait != null;
					if (flag2)
					{
						pawn.story.traits.allTraits.Add(trait);
					}
				}
			}
		}
	}
}
