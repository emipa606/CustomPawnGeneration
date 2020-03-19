using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000012 RID: 18
	public class Settings : ModSettings
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002B30 File Offset: 0x00000D30
		public static void Draw_MaleBody(Listing_Standard gui, Rect inRect)
		{
			bool flag = gui.ButtonText("Back", null);
			if (flag)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_Root);
				Settings.Male_BodyLabel_Refresh();
			}
			gui.Gap(10f);
			gui.ColumnWidth /= 2f;
			int num = Settings.Male_BodyThin ? 0 : (Settings.Male_BodyAverage ? 1 : (Settings.Male_BodyFat ? 2 : 3));
			gui.CheckboxLabeled("Make Average Body Gender-Specific", ref Settings.Male_BodyFix, "Some backstories will give pawns average body of the opposite gender. Enabling this will disable it.");
			gui.CheckboxLabeled("Thin", ref Settings.Male_BodyThin, null);
			gui.CheckboxLabeled("Average", ref Settings.Male_BodyAverage, null);
			gui.CheckboxLabeled("Fat", ref Settings.Male_BodyFat, null);
			gui.CheckboxLabeled("Hulk", ref Settings.Male_BodyHulk, null);
			bool flag2 = !Settings.Male_BodyThin && !Settings.Male_BodyAverage && !Settings.Male_BodyFat && !Settings.Male_BodyHulk;
			if (flag2)
			{
				switch (num)
				{
				case 0:
					Settings.Male_BodyThin = true;
					break;
				case 1:
					Settings.Male_BodyAverage = true;
					break;
				case 2:
					Settings.Male_BodyFat = true;
					break;
				case 3:
					Settings.Male_BodyHulk = true;
					break;
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002C68 File Offset: 0x00000E68
		public static void Draw_FemaleBody(Listing_Standard gui, Rect inRect)
		{
			bool flag = gui.ButtonText("Back", null);
			if (flag)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_Root);
				Settings.Female_BodyLabel_Refresh();
			}
			gui.Gap(10f);
			gui.ColumnWidth /= 2f;
			int num = Settings.Female_BodyThin ? 0 : (Settings.Female_BodyAverage ? 1 : (Settings.Female_BodyFat ? 2 : 3));
			gui.CheckboxLabeled("Make Average Body Gender-Specific", ref Settings.Female_BodyFix, "Some backstories will give pawns average body of the opposite gender. Enabling this will disable it.");
			gui.CheckboxLabeled("Thin", ref Settings.Female_BodyThin, null);
			gui.CheckboxLabeled("Average", ref Settings.Female_BodyAverage, null);
			gui.CheckboxLabeled("Fat", ref Settings.Female_BodyFat, null);
			gui.CheckboxLabeled("Hulk", ref Settings.Female_BodyHulk, null);
			bool flag2 = !Settings.Female_BodyThin && !Settings.Female_BodyAverage && !Settings.Female_BodyFat && !Settings.Female_BodyHulk;
			if (flag2)
			{
				switch (num)
				{
				case 0:
					Settings.Female_BodyThin = true;
					break;
				case 1:
					Settings.Female_BodyAverage = true;
					break;
				case 2:
					Settings.Female_BodyFat = true;
					break;
				case 3:
					Settings.Female_BodyHulk = true;
					break;
				}
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002DA0 File Offset: 0x00000FA0
		public static void ExposeData_Body()
		{
			Settings.Male_BodyLabel_Refresh();
			Settings.Female_BodyLabel_Refresh();
			Scribe_Values.Look<bool>(ref Settings.Male_BodyThin, "Male_BodyThin", Settings.Male_BodyThin, true);
			Scribe_Values.Look<bool>(ref Settings.Male_BodyAverage, "Male_BodyAverage", Settings.Male_BodyAverage, true);
			Scribe_Values.Look<bool>(ref Settings.Male_BodyFat, "Male_BodyFat", Settings.Male_BodyFat, true);
			Scribe_Values.Look<bool>(ref Settings.Male_BodyHulk, "Male_BodyHulk", Settings.Male_BodyHulk, true);
			Scribe_Values.Look<bool>(ref Settings.Female_BodyThin, "Female_BodyThin", Settings.Female_BodyThin, true);
			Scribe_Values.Look<bool>(ref Settings.Female_BodyAverage, "Female_BodyAverage", Settings.Female_BodyAverage, true);
			Scribe_Values.Look<bool>(ref Settings.Female_BodyFat, "Female_BodyFat", Settings.Female_BodyFat, true);
			Scribe_Values.Look<bool>(ref Settings.Female_BodyHulk, "Female_BodyHulk", Settings.Female_BodyHulk, true);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002E6A File Offset: 0x0000106A
		public static void Draw_Body_Label(Listing_Standard gui, float total, int value, string postfix)
		{
			gui.Label(Settings.Body_Label(total, value, postfix), -1f, null);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002E84 File Offset: 0x00001084
		public static string Body_Label(float total, int value, string postfix)
		{
			return string.Format("{0:F0}% {1}", (total > 0f) ? ((float)value / total) : 25f, postfix);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002EBC File Offset: 0x000010BC
		public static void Male_BodyLabel_Refresh()
		{
			Settings.Male_BodyLabel = "";
			bool male_BodyThin = Settings.Male_BodyThin;
			if (male_BodyThin)
			{
				Settings.Male_BodyLabel += "Thin | ";
			}
			bool male_BodyAverage = Settings.Male_BodyAverage;
			if (male_BodyAverage)
			{
				Settings.Male_BodyLabel += "Average | ";
			}
			bool male_BodyFat = Settings.Male_BodyFat;
			if (male_BodyFat)
			{
				Settings.Male_BodyLabel += "Fat | ";
			}
			bool male_BodyHulk = Settings.Male_BodyHulk;
			if (male_BodyHulk)
			{
				Settings.Male_BodyLabel += "Hulk | ";
			}
			Settings.Male_BodyLabel = Settings.Male_BodyLabel.Substring(0, Settings.Male_BodyLabel.Length - 3);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002F64 File Offset: 0x00001164
		public static void Female_BodyLabel_Refresh()
		{
			Settings.Female_BodyLabel = "";
			bool female_BodyThin = Settings.Female_BodyThin;
			if (female_BodyThin)
			{
				Settings.Female_BodyLabel += "Thin | ";
			}
			bool female_BodyAverage = Settings.Female_BodyAverage;
			if (female_BodyAverage)
			{
				Settings.Female_BodyLabel += "Average | ";
			}
			bool female_BodyFat = Settings.Female_BodyFat;
			if (female_BodyFat)
			{
				Settings.Female_BodyLabel += "Fat | ";
			}
			bool female_BodyHulk = Settings.Female_BodyHulk;
			if (female_BodyHulk)
			{
				Settings.Female_BodyLabel += "Hulk | ";
			}
			Settings.Female_BodyLabel = Settings.Female_BodyLabel.Substring(0, Settings.Female_BodyLabel.Length - 3);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000300C File Offset: 0x0000120C
		public static void DoWindowContents(Rect inRect)
		{
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.Begin(inRect);
			Settings.draw(listing_Standard, inRect);
			listing_Standard.End();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000303E File Offset: 0x0000123E
		public override void ExposeData()
		{
			base.ExposeData();
			Settings.ExposeData_Root();
			Settings.ExposeData_Body();
			Settings.ExposeData_TraitsForced();
			Settings.ExposeData_TraitsBlocked();
			Settings.ExposeData_Hediffs();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003068 File Offset: 0x00001268
		public static void Draw_MaleHediffs(Listing_Standard gui, Rect inRect)
		{
			Settings.Draw_Hediffs_Back(gui);
			gui.Gap(10f);
			bool flag = Settings.Body_Selected != null;
			if (flag)
			{
				Settings.Draw_Hediffs_Body(gui, inRect, Settings.Male_Hediffs);
			}
			else
			{
				bool flag2 = Settings.Hediff_Selected != null;
				if (flag2)
				{
					Settings.Draw_Hediffs_Race(gui, inRect, Settings.Male_Hediffs);
				}
				else
				{
					Settings.Draw_Hediffs(gui, inRect, ref Settings.Male_Hediffs);
				}
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000030CC File Offset: 0x000012CC
		public static void Draw_FemaleHediffs(Listing_Standard gui, Rect inRect)
		{
			Settings.Draw_Hediffs_Back(gui);
			gui.Gap(10f);
			bool flag = Settings.Body_Selected != null;
			if (flag)
			{
				Settings.Draw_Hediffs_Body(gui, inRect, Settings.Female_Hediffs);
			}
			else
			{
				bool flag2 = Settings.Hediff_Selected != null;
				if (flag2)
				{
					Settings.Draw_Hediffs_Race(gui, inRect, Settings.Female_Hediffs);
				}
				else
				{
					Settings.Draw_Hediffs(gui, inRect, ref Settings.Female_Hediffs);
				}
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003130 File Offset: 0x00001330
		public static void ExposeData_Hediffs()
		{
			Scribe_Collections.Look<string, int>(ref Settings.Male_Hediffs, "Male_Hediffs", LookMode.Value, LookMode.Undefined);
			Scribe_Collections.Look<string, int>(ref Settings.Female_Hediffs, "Female_Hediffs", LookMode.Value, LookMode.Undefined);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003158 File Offset: 0x00001358
		public static void Draw_Hediffs_Back(Listing_Standard gui)
		{
			bool flag = gui.ButtonText("Back", null);
			if (flag)
			{
				Settings.ScrollVector = Vector2.zero;
				Settings.ScrollRect = Rect.zero;
				bool flag2 = Settings.Body_Selected != null;
				if (flag2)
				{
					Settings.Body_Selected = null;
				}
				else
				{
					bool flag3 = Settings.Hediff_Selected != null;
					if (flag3)
					{
						Settings.Hediff_Selected = null;
					}
					else
					{
						Settings.draw = new Settings.Draw(Settings.Draw_Root);
					}
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000031C8 File Offset: 0x000013C8
		public static void Draw_Hediffs(Listing_Standard gui, Rect inRect, ref Dictionary<string, int> Hediffs)
		{
			bool flag = Hediffs == null;
			if (flag)
			{
				Hediffs = new Dictionary<string, int>();
			}
			gui.Label("Hediffs\n* Allows you to give the pawns a chance to have any hediffs to the designated body part upon spawning.", -1f, null);
			float num = gui.CurHeight + 10f;
			gui.ColumnWidth /= 2f;
			gui.BeginScrollView(new Rect(0f, num, gui.ColumnWidth + 20f, inRect.height - num - 20f), ref Settings.ScrollVector, ref Settings.ScrollRect);
			foreach (HediffDef hediffDef in DefDatabase<HediffDef>.AllDefs)
			{
				try
				{
					string label = "[" + hediffDef.defName + "] " + hediffDef.label;
					bool flag2 = gui.ButtonText(label, null);
					if (flag2)
					{
						Settings.Hediff_Selected = hediffDef;
						Settings.ScrollVector = Vector2.zero;
						Settings.ScrollRect = Rect.zero;
					}
				}
				catch
				{
				}
			}
			gui.EndScrollView(ref Settings.ScrollRect);
			gui.ColumnWidth += 20f;
			gui.NewColumn();
			gui.Gap(num);
			gui.ColumnWidth = 120f;
			bool flag3 = gui.ButtonText("Clear All", null);
			if (flag3)
			{
				Hediffs.Clear();
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000333C File Offset: 0x0000153C
		public static void Draw_Hediffs_Race(Listing_Standard gui, Rect inRect, Dictionary<string, int> Hediffs)
		{
			gui.Label("Hediffs > Race\n* Select which race will be affected by the selected hediff.", -1f, null);
			gui.Label("Hediff: [" + Settings.Hediff_Selected.defName + "] " + Settings.Hediff_Selected.label, -1f, null);
			float num = gui.CurHeight + 10f;
			gui.ColumnWidth /= 2f;
			gui.BeginScrollView(new Rect(0f, num, gui.ColumnWidth + 20f, inRect.height - num - 20f), ref Settings.ScrollVector, ref Settings.ScrollRect);
			foreach (BodyDef bodyDef in DefDatabase<BodyDef>.AllDefs)
			{
				try
				{
					bool flag = gui.ButtonText("[" + bodyDef.defName + "] " + bodyDef.label, null);
					if (flag)
					{
						Settings.Body_Selected = bodyDef;
						Settings.ScrollVector = Vector2.zero;
						Settings.ScrollRect = Rect.zero;
					}
				}
				catch
				{
				}
			}
			gui.EndScrollView(ref Settings.ScrollRect);
			gui.ColumnWidth += 20f;
			gui.NewColumn();
			gui.Gap(num);
			gui.ColumnWidth = 240f;
			bool flag2 = gui.ButtonText("Clear this Hediff from All Races", null);
			if (flag2)
			{
				foreach (string text in Hediffs.Keys.ToArray<string>())
				{
					bool flag3 = text.Contains(Settings.Hediff_Selected.defName + "\n");
					if (flag3)
					{
						Hediffs.Remove(text);
					}
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003514 File Offset: 0x00001714
		public static void Draw_Hediffs_Body(Listing_Standard gui, Rect inRect, Dictionary<string, int> Hediffs)
		{
			string str = string.Concat(new string[]
			{
				"Hediff: [",
				Settings.Hediff_Selected.defName,
				"] ",
				Settings.Hediff_Selected.label,
				"\n"
			});
			string str2 = "Race: [" + Settings.Body_Selected.defName + "] " + Settings.Body_Selected.label;
			gui.Label("Hediffs > Race > Body\n* Set the chance for each parts for the hediffs to appear.", -1f, null);
			gui.Label(str + str2, -1f, null);
			float num = gui.CurHeight + 10f;
			gui.ColumnWidth /= 2f;
			gui.BeginScrollView(new Rect(0f, num, gui.ColumnWidth + 20f, inRect.height - num - 20f), ref Settings.ScrollVector, ref Settings.ScrollRect);
			foreach (BodyPartRecord bodyPartRecord in Settings.Body_Selected.AllParts)
			{
				try
				{
					string key = string.Concat(new string[]
					{
						Settings.Hediff_Selected.defName,
						"\n",
						Settings.Body_Selected.defName,
						"\n",
						bodyPartRecord.Label,
						"\n"
					});
					int num2 = Hediffs.ContainsKey(key) ? Hediffs[key] : 0;
					gui.Label(string.Format("[{0}] {1} {2}%", bodyPartRecord.def.defName, bodyPartRecord.Label, num2), -1f, bodyPartRecord.Label);
					num2 = (int)gui.Slider((float)num2, 0f, 100f);
					bool flag = num2 != 0;
					if (flag)
					{
						Hediffs[key] = num2;
					}
					else
					{
						bool flag2 = Hediffs.ContainsKey(key);
						if (flag2)
						{
							Hediffs.Remove(key);
						}
					}
				}
				catch
				{
				}
			}
			gui.EndScrollView(ref Settings.ScrollRect);
			gui.ColumnWidth += 20f;
			gui.NewColumn();
			gui.Gap(num);
			gui.ColumnWidth = 260f;
			bool flag3 = gui.ButtonText("Clear All Values from this Hediff+Race", null);
			if (flag3)
			{
				foreach (string text in Hediffs.Keys.ToArray<string>())
				{
					bool flag4 = text.Contains(Settings.Hediff_Selected.defName + "\n") && text.Contains(Settings.Body_Selected.defName + "\n");
					if (flag4)
					{
						Hediffs.Remove(text);
					}
				}
			}
			bool flag5 = gui.ButtonText("Clear All Hediffs from this Race", null);
			if (flag5)
			{
				foreach (string text2 in Hediffs.Keys.ToArray<string>())
				{
					bool flag6 = text2.Contains(Settings.Body_Selected.defName + "\n");
					if (flag6)
					{
						Hediffs.Remove(text2);
					}
				}
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000387C File Offset: 0x00001A7C
		public static void Draw_Root(Listing_Standard gui, Rect inRect)
		{
			Settings.Draw_Root_Gender(gui);
			gui.Gap(10f);
			float curHeight = gui.CurHeight;
			bool separateGender = Settings.SeparateGender;
			if (separateGender)
			{
				gui.ColumnWidth = gui.ColumnWidth / 2f - 9f;
				gui.Label("Male", -1f, null);
				gui.Gap(10f);
				Settings.Draw_Root_Male(gui);
				gui.NewColumn();
				gui.Gap(curHeight);
				gui.Label("Female", -1f, null);
				gui.Gap(10f);
				Settings.Draw_Root_Female(gui);
			}
			else
			{
				Settings.Draw_Root_Male(gui);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000392C File Offset: 0x00001B2C
		public static void ExposeData_Root()
		{
			Scribe_Values.Look<int>(ref Settings.GenderSlider, "GenderSlider", Settings.GenderSlider, true);
			Scribe_Values.Look<bool>(ref Settings.SeparateGender, "SeparateGender", Settings.SeparateGender, true);
			Scribe_Values.Look<bool>(ref Settings.OverrideGender, "OverrideGender", Settings.OverrideGender, true);
			Scribe_Values.Look<bool>(ref Settings.UnforcedGender, "UnforcedGender", Settings.UnforcedGender, true);
			Scribe_Values.Look<bool>(ref Settings.Male_AgeCurve, "Male_AgeCurve", Settings.Male_AgeCurve, true);
			Scribe_Values.Look<bool>(ref Settings.Male_HasMinAge, "Male_HasMinAge", Settings.Male_HasMinAge, true);
			Scribe_Values.Look<bool>(ref Settings.Male_MinAgeSoft, "Male_MinAgeSoft", Settings.Male_MinAgeSoft, true);
			Scribe_Values.Look<int>(ref Settings.Male_MinAge, "Male_MinAge", Settings.Male_MinAge, true);
			Settings.Male_MinAgeBuffer = Settings.Male_MinAge.ToString();
			Scribe_Values.Look<bool>(ref Settings.Male_HasMaxAge, "Male_HasMaxAge", Settings.Male_HasMaxAge, true);
			Scribe_Values.Look<bool>(ref Settings.Male_MaxAgeChrono, "Male_MaxAgeChrono", Settings.Male_MaxAgeChrono, true);
			Scribe_Values.Look<int>(ref Settings.Male_MaxAge, "Male_MaxAge", Settings.Male_MaxAge, true);
			Settings.Male_MaxAgeBuffer = Settings.Male_MaxAge.ToString();
			Scribe_Values.Look<int>(ref Settings.Male_AgeTick, "Male_AgeTick", Settings.Male_AgeTick, true);
			Settings.Male_AgeTickBuffer = Settings.Male_AgeTick.ToString();
			Scribe_Values.Look<bool>(ref Settings.Female_AgeCurve, "Female_AgeCurve", Settings.Female_AgeCurve, true);
			Scribe_Values.Look<bool>(ref Settings.Female_HasMinAge, "Female_HasMinAge", Settings.Female_HasMinAge, true);
			Scribe_Values.Look<bool>(ref Settings.Female_MinAgeSoft, "Female_MinAgeSoft", Settings.Female_MinAgeSoft, true);
			Scribe_Values.Look<int>(ref Settings.Female_MinAge, "Female_MinAge", Settings.Female_MinAge, true);
			Settings.Female_MinAgeBuffer = Settings.Female_MinAge.ToString();
			Scribe_Values.Look<bool>(ref Settings.Female_HasMaxAge, "Female_HasMaxAge", Settings.Female_HasMaxAge, true);
			Scribe_Values.Look<bool>(ref Settings.Female_MaxAgeChrono, "Female_MaxAgeChrono", Settings.Female_MaxAgeChrono, true);
			Scribe_Values.Look<int>(ref Settings.Female_MaxAge, "Female_MaxAge", Settings.Female_MaxAge, true);
			Settings.Female_MaxAgeBuffer = Settings.Female_MaxAge.ToString();
			Scribe_Values.Look<int>(ref Settings.Female_AgeTick, "Female_AgeTick", Settings.Female_AgeTick, true);
			Settings.Female_AgeTickBuffer = Settings.Female_AgeTick.ToString();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003B4C File Offset: 0x00001D4C
		public static void Draw_Root_Gender(Listing_Standard gui)
		{
			gui.CheckboxLabeled("Separate Gender Stats", ref Settings.SeparateGender, "If enabled, this will separate the stats for male and female.");
			gui.CheckboxLabeled("Override Gender Frequency", ref Settings.OverrideGender, "If enabled, allows you to set which gender is the most frequent.");
			bool flag = !Settings.OverrideGender;
			if (!flag)
			{
				gui.CheckboxLabeled("Override Forced Gender", ref Settings.UnforcedGender, "Some pawns have a 'forced' gender when being generated (backstory-related or generated as another pawn's father/mother). Enabling this will ignore it. May cause minor bugs (single fathers/mothers), but not game-breaking.");
				gui.Gap(10f);
				gui.LabelDouble(string.Format("{0}% Male", 100 - Settings.GenderSlider), string.Format("{0}% Female", Settings.GenderSlider), null);
				Settings.GenderSlider = (int)gui.Slider((float)Settings.GenderSlider, 0f, 100f);
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003C08 File Offset: 0x00001E08
		public static void Draw_Root_Male(Listing_Standard gui)
		{
			bool flag = gui.ButtonText(Settings.Male_BodyLabel, null);
			if (flag)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_MaleBody);
			}
			string format = "{0} Forced Trait(s)";
			HashSet<string> male_TraitsForced = Settings.Male_TraitsForced;
			bool flag2 = gui.ButtonText(string.Format(format, (male_TraitsForced != null) ? male_TraitsForced.Count : 0), null);
			if (flag2)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_MaleTraitsForced);
			}
			string format2 = "{0} Blocked Trait(s)";
			HashSet<string> male_TraitsBlocked = Settings.Male_TraitsBlocked;
			bool flag3 = gui.ButtonText(string.Format(format2, (male_TraitsBlocked != null) ? male_TraitsBlocked.Count : 0), null);
			if (flag3)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_MaleTraitsBlocked);
			}
			string format3 = "{0} Hediff(s)";
			Dictionary<string, int> male_Hediffs = Settings.Male_Hediffs;
			bool flag4 = gui.ButtonText(string.Format(format3, (male_Hediffs != null) ? male_Hediffs.Count : 0), null);
			if (flag4)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_MaleHediffs);
			}
			gui.Gap(10f);
			Settings.Draw_Root_Age(gui, ref Settings.Male_AgeCurve, ref Settings.Male_HasMinAge, ref Settings.Male_MinAgeSoft, ref Settings.Male_MinAge, ref Settings.Male_MinAgeBuffer, ref Settings.Male_HasMaxAge, ref Settings.Male_MaxAgeChrono, ref Settings.Male_MaxAge, ref Settings.Male_MaxAgeBuffer, ref Settings.Male_AgeTick, ref Settings.Male_AgeTickBuffer);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003D38 File Offset: 0x00001F38
		public static void Draw_Root_Female(Listing_Standard gui)
		{
			bool flag = gui.ButtonText(Settings.Female_BodyLabel, null);
			if (flag)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_FemaleBody);
			}
			string format = "{0} Forced Trait(s)";
			HashSet<string> female_TraitsForced = Settings.Female_TraitsForced;
			bool flag2 = gui.ButtonText(string.Format(format, (female_TraitsForced != null) ? female_TraitsForced.Count : 0), null);
			if (flag2)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_FemaleTraitsForced);
			}
			string format2 = "{0} Blocked Trait(s)";
			HashSet<string> female_TraitsBlocked = Settings.Female_TraitsBlocked;
			bool flag3 = gui.ButtonText(string.Format(format2, (female_TraitsBlocked != null) ? female_TraitsBlocked.Count : 0), null);
			if (flag3)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_FemaleTraitsBlocked);
			}
			string format3 = "{0} Hediff(s)";
			Dictionary<string, int> female_Hediffs = Settings.Female_Hediffs;
			bool flag4 = gui.ButtonText(string.Format(format3, (female_Hediffs != null) ? female_Hediffs.Count : 0), null);
			if (flag4)
			{
				Settings.draw = new Settings.Draw(Settings.Draw_FemaleHediffs);
			}
			gui.Gap(10f);
			Settings.Draw_Root_Age(gui, ref Settings.Female_AgeCurve, ref Settings.Female_HasMinAge, ref Settings.Female_MinAgeSoft, ref Settings.Female_MinAge, ref Settings.Female_MinAgeBuffer, ref Settings.Female_HasMaxAge, ref Settings.Female_MaxAgeChrono, ref Settings.Female_MaxAge, ref Settings.Female_MaxAgeBuffer, ref Settings.Female_AgeTick, ref Settings.Female_AgeTickBuffer);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003E68 File Offset: 0x00002068
		public static void Draw_Root_Age(Listing_Standard gui, ref bool AgeCurve, ref bool HasMinAge, ref bool MinAgeSoft, ref int MinAge, ref string MinAgeBuffer, ref bool HasMaxAge, ref bool MaxAgeChrono, ref int MaxAge, ref string MaxAgeBuffer, ref int AgeTick, ref string AgeTickBuffer)
		{
			bool flag = HasMinAge | HasMaxAge;
			if (flag)
			{
				gui.CheckboxLabeled("Preserve Age Curve", ref AgeCurve, "If enabled, this will attempt to translate a pawn's current age to the new age limit. This may not be accurate but it would generate a similar effect with the vanilla age variation. Disabling this will only clamp the pawn's age.");
			}
			gui.CheckboxLabeled("Has Minimum Age", ref HasMinAge, "If enabled, this will make sure all pawns can't be below a certain age. This will also affect pregnancy mods, meaning newborn babies will start at the minimum age.");
			bool flag2 = HasMinAge;
			if (flag2)
			{
				gui.CheckboxLabeled("Do Not Affect Pawns Below Minimum Age", ref MinAgeSoft, "If enabled, pawns being generated below the minimum age will not be changed (e.g. baby pawns).");
				gui.TextFieldNumericLabeled<int>("Minimum Age ", ref MinAge, ref MinAgeBuffer, 0f, HasMaxAge ? ((float)MaxAge) : 1E+09f);
				gui.Gap(10f);
			}
			gui.CheckboxLabeled("Has Maximum Age", ref HasMaxAge, "If enabled, this will make sure all pawns can't be above a certain age.");
			bool flag3 = HasMaxAge;
			if (flag3)
			{
				gui.CheckboxLabeled("Add Excess Biological Age as Chronological Age", ref MaxAgeChrono, "If enabled, this will increase the pawn's chronological age on every birthday if exceeding the maximum age.");
				gui.TextFieldNumericLabeled<int>("Maximum Age ", ref MaxAge, ref MaxAgeBuffer, (float)(HasMinAge ? MinAge : 0), 1E+09f);
			}
			gui.Gap(10f);
			gui.TextFieldNumericLabeled<int>("Aging Tick Speed [Default: 1] ", ref AgeTick, ref AgeTickBuffer, 0f, 1E+09f);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003F64 File Offset: 0x00002164
		public static void Draw_MaleTraitsBlocked(Listing_Standard gui, Rect inRect)
		{
			Settings.Draw_TraitsBlocked_Back(gui);
			gui.Gap(10f);
			Settings.Draw_TraitsBlocked(gui, inRect, Settings.Male_TraitsForced, ref Settings.Male_TraitsBlocked);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003F8C File Offset: 0x0000218C
		public static void Draw_FemaleTraitsBlocked(Listing_Standard gui, Rect inRect)
		{
			Settings.Draw_TraitsBlocked_Back(gui);
			gui.Gap(10f);
			Settings.Draw_TraitsBlocked(gui, inRect, Settings.Female_TraitsForced, ref Settings.Female_TraitsBlocked);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003FB4 File Offset: 0x000021B4
		public static void ExposeData_TraitsBlocked()
		{
			Scribe_Collections.Look<string>(ref Settings.Male_TraitsBlocked, "Male_TraitsBlocked", LookMode.Value);
			Scribe_Collections.Look<string>(ref Settings.Female_TraitsBlocked, "Female_TraitsBlocked", LookMode.Value);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003FDC File Offset: 0x000021DC
		public static void Draw_TraitsBlocked_Back(Listing_Standard gui)
		{
			bool flag = gui.ButtonText("Back", null);
			if (flag)
			{
				Settings.ScrollVector = Vector2.zero;
				Settings.ScrollRect = Rect.zero;
				Settings.draw = new Settings.Draw(Settings.Draw_Root);
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004024 File Offset: 0x00002224
		public static void Draw_TraitsBlocked(Listing_Standard gui, Rect inRect, HashSet<string> TraitsForced, ref HashSet<string> TraitsBlocked)
		{
			bool flag = TraitsBlocked == null;
			if (flag)
			{
				TraitsBlocked = new HashSet<string>();
			}
			gui.Label("Blocked Traits\n* Traits that are CHECKED will never be given to the respective pawns.\n* If a pawn rolls for a blocked trait, it will re-roll again.\n* The game may spam a lot of '[Pawn] already has [Trait]' messages in the console.\nWARNING: Blocking majority of the traits will set the game in a permanent loop, making you unable to play!\nTry to only block less than half of the traits.", -1f, null);
			float num = gui.CurHeight + 10f;
			gui.ColumnWidth /= 2f;
			gui.BeginScrollView(new Rect(0f, num, gui.ColumnWidth + 20f, inRect.height - num - 20f), ref Settings.ScrollVector, ref Settings.ScrollRect);
			foreach (TraitDef traitDef in DefDatabase<TraitDef>.AllDefs)
			{
				try
				{
					foreach (TraitDegreeData traitDegreeData in traitDef.degreeDatas)
					{
						string item = string.Format("{0}_{1}", traitDef.defName, traitDegreeData.degree);
						bool flag2 = TraitsForced != null && TraitsForced.Contains(item);
						if (!flag2)
						{
							bool flag3 = TraitsBlocked.Contains(item);
							gui.CheckboxLabeled("[" + traitDef.defName + "] " + (traitDegreeData.label ?? traitDef.label), ref flag3, traitDegreeData.description ?? traitDef.description);
							bool flag4 = flag3;
							if (flag4)
							{
								TraitsBlocked.Add(item);
							}
							else
							{
								TraitsBlocked.Remove(item);
							}
						}
					}
				}
				catch
				{
				}
			}
			gui.EndScrollView(ref Settings.ScrollRect);
			gui.ColumnWidth += 20f;
			gui.NewColumn();
			gui.Gap(num);
			gui.ColumnWidth = 120f;
			bool flag5 = gui.ButtonText("Enable All", null);
			if (flag5)
			{
				foreach (TraitDef traitDef2 in DefDatabase<TraitDef>.AllDefs)
				{
					try
					{
						foreach (TraitDegreeData traitDegreeData2 in traitDef2.degreeDatas)
						{
							string item2 = string.Format("{0}_{1}", traitDef2.defName, traitDegreeData2.degree);
							bool flag6 = (TraitsForced == null || !TraitsForced.Contains(item2)) && !TraitsBlocked.Contains(item2);
							if (flag6)
							{
								TraitsBlocked.Add(item2);
							}
						}
					}
					catch
					{
					}
				}
			}
			bool flag7 = gui.ButtonText("Disable All", null);
			if (flag7)
			{
				TraitsBlocked.Clear();
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004334 File Offset: 0x00002534
		public static void Draw_MaleTraitsForced(Listing_Standard gui, Rect inRect)
		{
			Settings.Draw_TraitsForced_Back(gui);
			gui.Gap(10f);
			Settings.Draw_TraitsForced(gui, inRect, Settings.Male_TraitsBlocked, ref Settings.Male_TraitsForced);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000435C File Offset: 0x0000255C
		public static void Draw_FemaleTraitsForced(Listing_Standard gui, Rect inRect)
		{
			Settings.Draw_TraitsForced_Back(gui);
			gui.Gap(10f);
			Settings.Draw_TraitsForced(gui, inRect, Settings.Female_TraitsBlocked, ref Settings.Female_TraitsForced);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004384 File Offset: 0x00002584
		public static void ExposeData_TraitsForced()
		{
			Scribe_Collections.Look<string>(ref Settings.Male_TraitsForced, "Male_TraitsForced", LookMode.Value);
			Scribe_Collections.Look<string>(ref Settings.Female_TraitsForced, "Female_TraitsForced", LookMode.Value);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000043AC File Offset: 0x000025AC
		public static void Draw_TraitsForced_Back(Listing_Standard gui)
		{
			bool flag = gui.ButtonText("Back", null);
			if (flag)
			{
				Settings.ScrollVector = Vector2.zero;
				Settings.ScrollRect = Rect.zero;
				Settings.draw = new Settings.Draw(Settings.Draw_Root);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000043F4 File Offset: 0x000025F4
		public static void Draw_TraitsForced(Listing_Standard gui, Rect inRect, HashSet<string> TraitsBlocked, ref HashSet<string> TraitsForced)
		{
			bool flag = TraitsForced == null;
			if (flag)
			{
				TraitsForced = new HashSet<string>();
			}
			gui.Label("Forced Traits\n* Traits that are CHECKED will always be given to the respective pawns.\n* The forced traits are added after generating traits, which may exceed max traits.\n* You can force the same trait with varying degrees.\n* The game may spam a lot of '[Pawn] already has [Trait]' messages in the console.\nWARNING: Forcing majority of the traits will set the game in a permanent loop, making you unable to play!\nTry to only force less than half of the traits.", -1f, null);
			float num = gui.CurHeight + 10f;
			gui.ColumnWidth /= 2f;
			gui.BeginScrollView(new Rect(0f, num, gui.ColumnWidth + 20f, inRect.height - num - 20f), ref Settings.ScrollVector, ref Settings.ScrollRect);
			foreach (TraitDef traitDef in DefDatabase<TraitDef>.AllDefs)
			{
				try
				{
					foreach (TraitDegreeData traitDegreeData in traitDef.degreeDatas)
					{
						string item = string.Format("{0}_{1}", traitDef.defName, traitDegreeData.degree);
						bool flag2 = TraitsBlocked != null && TraitsBlocked.Contains(item);
						if (!flag2)
						{
							bool flag3 = TraitsForced.Contains(item);
							gui.CheckboxLabeled("[" + traitDef.defName + "] " + (traitDegreeData.label ?? traitDef.label), ref flag3, traitDegreeData.description ?? traitDef.description);
							bool flag4 = flag3;
							if (flag4)
							{
								TraitsForced.Add(item);
							}
							else
							{
								TraitsForced.Remove(item);
							}
						}
					}
				}
				catch
				{
				}
			}
			gui.EndScrollView(ref Settings.ScrollRect);
			gui.ColumnWidth += 20f;
			gui.NewColumn();
			gui.Gap(num);
			gui.ColumnWidth = 120f;
			bool flag5 = gui.ButtonText("Enable All", null);
			if (flag5)
			{
				foreach (TraitDef traitDef2 in DefDatabase<TraitDef>.AllDefs)
				{
					try
					{
						foreach (TraitDegreeData traitDegreeData2 in traitDef2.degreeDatas)
						{
							string item2 = string.Format("{0}_{1}", traitDef2.defName, traitDegreeData2.degree);
							bool flag6 = (TraitsBlocked == null || !TraitsBlocked.Contains(item2)) && !TraitsForced.Contains(item2);
							if (flag6)
							{
								TraitsForced.Add(item2);
							}
						}
					}
					catch
					{
					}
				}
			}
			bool flag7 = gui.ButtonText("Disable All", null);
			if (flag7)
			{
				TraitsForced.Clear();
			}
		}

		// Token: 0x04000002 RID: 2
		public const string DESCRIPTION_BODY_FIX = "Some backstories will give pawns average body of the opposite gender. Enabling this will disable it.";

		// Token: 0x04000003 RID: 3
		public static bool Male_BodyFix = false;

		// Token: 0x04000004 RID: 4
		public static bool Male_BodyThin = true;

		// Token: 0x04000005 RID: 5
		public static bool Male_BodyAverage = true;

		// Token: 0x04000006 RID: 6
		public static bool Male_BodyFat = true;

		// Token: 0x04000007 RID: 7
		public static bool Male_BodyHulk = true;

		// Token: 0x04000008 RID: 8
		public static bool Female_BodyFix = false;

		// Token: 0x04000009 RID: 9
		public static bool Female_BodyThin = true;

		// Token: 0x0400000A RID: 10
		public static bool Female_BodyAverage = true;

		// Token: 0x0400000B RID: 11
		public static bool Female_BodyFat = true;

		// Token: 0x0400000C RID: 12
		public static bool Female_BodyHulk = true;

		// Token: 0x0400000D RID: 13
		public static string Male_BodyLabel;

		// Token: 0x0400000E RID: 14
		public static string Female_BodyLabel;

		// Token: 0x0400000F RID: 15
		public static Settings.Draw draw = new Settings.Draw(Settings.Draw_Root);

		// Token: 0x04000010 RID: 16
		public const string DESCRIPTION_HEDIFFS = "Hediffs\n* Allows you to give the pawns a chance to have any hediffs to the designated body part upon spawning.";

		// Token: 0x04000011 RID: 17
		public const string DESCRIPTION_HEDIFFS_RACE = "Hediffs > Race\n* Select which race will be affected by the selected hediff.";

		// Token: 0x04000012 RID: 18
		public const string DESCRIPTION_HEDIFFS_BODY = "Hediffs > Race > Body\n* Set the chance for each parts for the hediffs to appear.";

		// Token: 0x04000013 RID: 19
		public static Dictionary<string, int> Male_Hediffs;

		// Token: 0x04000014 RID: 20
		public static Dictionary<string, int> Female_Hediffs;

		// Token: 0x04000015 RID: 21
		public static HediffDef Hediff_Selected = null;

		// Token: 0x04000016 RID: 22
		public static BodyDef Body_Selected = null;

		// Token: 0x04000017 RID: 23
		public const string DESCRIPTION_SEPARATE_GENDER = "If enabled, this will separate the stats for male and female.";

		// Token: 0x04000018 RID: 24
		public const string DESCRIPTION_OVERRIDE_GENDER = "If enabled, allows you to set which gender is the most frequent.";

		// Token: 0x04000019 RID: 25
		public const string DESCRIPTION_UNFORCED_GENDER = "Some pawns have a 'forced' gender when being generated (backstory-related or generated as another pawn's father/mother). Enabling this will ignore it. May cause minor bugs (single fathers/mothers), but not game-breaking.";

		// Token: 0x0400001A RID: 26
		public const string DESCRIPTION_AGE_CURVE = "If enabled, this will attempt to translate a pawn's current age to the new age limit. This may not be accurate but it would generate a similar effect with the vanilla age variation. Disabling this will only clamp the pawn's age.";

		// Token: 0x0400001B RID: 27
		public const string DESCRIPTION_HAS_MIN_AGE = "If enabled, this will make sure all pawns can't be below a certain age. This will also affect pregnancy mods, meaning newborn babies will start at the minimum age.";

		// Token: 0x0400001C RID: 28
		public const string DESCRIPTION_MIN_AGE_SOFT = "If enabled, pawns being generated below the minimum age will not be changed (e.g. baby pawns).";

		// Token: 0x0400001D RID: 29
		public const string DESCRIPTION_HAS_MAX_AGE = "If enabled, this will make sure all pawns can't be above a certain age.";

		// Token: 0x0400001E RID: 30
		public const string DESCRIPTION_MAX_AGE_CHRONO = "If enabled, this will increase the pawn's chronological age on every birthday if exceeding the maximum age.";

		// Token: 0x0400001F RID: 31
		public const string OVERRIDE_GENDER = "Override Gender Frequency";

		// Token: 0x04000020 RID: 32
		public const string UNFORCED_GENDER = "Override Forced Gender";

		// Token: 0x04000021 RID: 33
		public const string SEPARATE_GENDER = "Separate Gender Stats";

		// Token: 0x04000022 RID: 34
		public const string AGE_CURVE = "Preserve Age Curve";

		// Token: 0x04000023 RID: 35
		public const string HAS_MIN_AGE = "Has Minimum Age";

		// Token: 0x04000024 RID: 36
		public const string MIN_AGE_SOFT = "Do Not Affect Pawns Below Minimum Age";

		// Token: 0x04000025 RID: 37
		public const string MIN_AGE = "Minimum Age ";

		// Token: 0x04000026 RID: 38
		public const string HAS_MAX_AGE = "Has Maximum Age";

		// Token: 0x04000027 RID: 39
		public const string MAX_AGE_CHRONO = "Add Excess Biological Age as Chronological Age";

		// Token: 0x04000028 RID: 40
		public const string MAX_AGE = "Maximum Age ";

		// Token: 0x04000029 RID: 41
		public const string AGE_TICK = "Aging Tick Speed [Default: 1] ";

		// Token: 0x0400002A RID: 42
		public static int GenderSlider = 50;

		// Token: 0x0400002B RID: 43
		public static bool SeparateGender = false;

		// Token: 0x0400002C RID: 44
		public static bool OverrideGender = true;

		// Token: 0x0400002D RID: 45
		public static bool UnforcedGender = false;

		// Token: 0x0400002E RID: 46
		public static bool Male_AgeCurve = true;

		// Token: 0x0400002F RID: 47
		public static bool Male_HasMinAge = true;

		// Token: 0x04000030 RID: 48
		public static bool Male_MinAgeSoft = true;

		// Token: 0x04000031 RID: 49
		public static int Male_MinAge = 0;

		// Token: 0x04000032 RID: 50
		public static string Male_MinAgeBuffer = "0";

		// Token: 0x04000033 RID: 51
		public static bool Male_HasMaxAge = true;

		// Token: 0x04000034 RID: 52
		public static bool Male_MaxAgeChrono = true;

		// Token: 0x04000035 RID: 53
		public static int Male_MaxAge = 999999;

		// Token: 0x04000036 RID: 54
		public static string Male_MaxAgeBuffer = "999999";

		// Token: 0x04000037 RID: 55
		public static int Male_AgeTick = 1;

		// Token: 0x04000038 RID: 56
		public static string Male_AgeTickBuffer = "1";

		// Token: 0x04000039 RID: 57
		public static bool Female_AgeCurve = true;

		// Token: 0x0400003A RID: 58
		public static bool Female_HasMinAge = true;

		// Token: 0x0400003B RID: 59
		public static bool Female_MinAgeSoft = true;

		// Token: 0x0400003C RID: 60
		public static int Female_MinAge = 0;

		// Token: 0x0400003D RID: 61
		public static string Female_MinAgeBuffer = "0";

		// Token: 0x0400003E RID: 62
		public static bool Female_HasMaxAge = true;

		// Token: 0x0400003F RID: 63
		public static bool Female_MaxAgeChrono = true;

		// Token: 0x04000040 RID: 64
		public static int Female_MaxAge = 999999;

		// Token: 0x04000041 RID: 65
		public static string Female_MaxAgeBuffer = "999999";

		// Token: 0x04000042 RID: 66
		public static int Female_AgeTick = 1;

		// Token: 0x04000043 RID: 67
		public static string Female_AgeTickBuffer = "1";

		// Token: 0x04000044 RID: 68
		public static Vector2 ScrollVector = Vector2.zero;

		// Token: 0x04000045 RID: 69
		public static Rect ScrollRect = Rect.zero;

		// Token: 0x04000046 RID: 70
		public const string DESCRIPTION_TRAITS_BLOCKED = "Blocked Traits\n* Traits that are CHECKED will never be given to the respective pawns.\n* If a pawn rolls for a blocked trait, it will re-roll again.\n* The game may spam a lot of '[Pawn] already has [Trait]' messages in the console.\nWARNING: Blocking majority of the traits will set the game in a permanent loop, making you unable to play!\nTry to only block less than half of the traits.";

		// Token: 0x04000047 RID: 71
		public static HashSet<string> Male_TraitsBlocked;

		// Token: 0x04000048 RID: 72
		public static HashSet<string> Female_TraitsBlocked;

		// Token: 0x04000049 RID: 73
		public const string DESCRIPTION_TRAITS_FORCED = "Forced Traits\n* Traits that are CHECKED will always be given to the respective pawns.\n* The forced traits are added after generating traits, which may exceed max traits.\n* You can force the same trait with varying degrees.\n* The game may spam a lot of '[Pawn] already has [Trait]' messages in the console.\nWARNING: Forcing majority of the traits will set the game in a permanent loop, making you unable to play!\nTry to only force less than half of the traits.";

		// Token: 0x0400004A RID: 74
		public static HashSet<string> Male_TraitsForced;

		// Token: 0x0400004B RID: 75
		public static HashSet<string> Female_TraitsForced;

		// Token: 0x02000015 RID: 21
		// (Invoke) Token: 0x0600003F RID: 63
		public delegate void Draw(Listing_Standard gui, Rect inRect);
	}
}
