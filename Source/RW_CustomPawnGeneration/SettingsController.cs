using System;
using UnityEngine;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000013 RID: 19
	public class SettingsController : Mod
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00004847 File Offset: 0x00002A47
		public SettingsController(ModContentPack content) : base(content)
		{
			base.GetSettings<Settings>();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000485C File Offset: 0x00002A5C
		public override string SettingsCategory()
		{
			return "Custom Pawn Generation";
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004873 File Offset: 0x00002A73
		public override void DoSettingsWindowContents(Rect inRect)
		{
			Settings.DoWindowContents(inRect);
		}
	}
}
