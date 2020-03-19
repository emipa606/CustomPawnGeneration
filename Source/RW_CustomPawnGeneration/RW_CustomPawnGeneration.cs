using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000011 RID: 17
	[StaticConstructorOnStartup]
	internal class RW_CustomPawnGeneration
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002B0C File Offset: 0x00000D0C
		static RW_CustomPawnGeneration()
		{
			new Harmony("com.rimworld.mod.nyan.custom_pawn_generation").PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
