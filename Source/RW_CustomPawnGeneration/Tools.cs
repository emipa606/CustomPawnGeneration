using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RW_CustomPawnGeneration
{
	// Token: 0x02000014 RID: 20
	public static class Tools
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00004880 File Offset: 0x00002A80
		public static Dictionary<string, Func<Trait>> Traits
		{
			get
			{
				bool flag = Tools._Traits == null;
				if (flag)
				{
					Tools._Traits = new Dictionary<string, Func<Trait>>();
					using (IEnumerator<TraitDef> enumerator = DefDatabase<TraitDef>.AllDefs.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							TraitDef def = enumerator.Current;
							try
							{
								using (List<TraitDegreeData>.Enumerator enumerator2 = def.degreeDatas.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										TraitDegreeData data = enumerator2.Current;
										Tools._Traits[string.Format("{0}_{1}", def.defName, data.degree)] = (() => new Trait(def, data.degree, false));
									}
								}
							}
							catch
							{
							}
						}
					}
				}
				return Tools._Traits;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000049B0 File Offset: 0x00002BB0
		public static Trait NewTrait(string key)
		{
			return Tools.Traits.ContainsKey(key) ? Tools.Traits[key]() : null;
		}

		// Token: 0x0400004C RID: 76
		public static Dictionary<string, Func<Trait>> _Traits = null;
	}
}
