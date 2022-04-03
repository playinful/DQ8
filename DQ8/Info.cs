﻿using System;
using System.Collections.Generic;

namespace DQ8
{
	class Info
	{
		public string Mode { get; set; } = "JP"; // "NA" or "JP"

		private static Info mThis;
		public List<NameValue> Items { get; private set; } = new List<NameValue>();
		public List<NameValue> Places { get; private set; } = new List<NameValue>();
		public List<NameValue> Orders { get; private set; } = new List<NameValue>();
		public List<NameValue> Recipes { get; private set; } = new List<NameValue>();
		public List<NameValue> Monsters { get; private set; } = new List<NameValue>();
		public List<BattleMonsterInfo> BattleLoadMonsters { get; private set; } = new List<BattleMonsterInfo>();

		private Info() { }

		public static Info Instance()
		{
			if (mThis == null)
			{
				mThis = new Info();
				mThis.Init();
			}
			return mThis;
		}

		public NameValue Item(uint id)
		{
			int min = 0;
			int max = Items.Count;
			for (; min < max;)
			{
				int mid = (min + max) / 2;
				if (Items[mid].Value == id) return Items[mid];
				else if (Items[mid].Value > id) max = mid;
				else min = mid + 1;
			}
			return null;
		}

		private void Init()
		{
			AppendList("info\\item.txt", Items);
			AppendList("info\\place.txt", Places);
			AppendList("info\\order.txt", Orders);
			AppendList("info\\recipe.txt", Recipes);
			AppendList("info\\monster.txt", Monsters);
			AppendList("info\\battleload.txt", BattleLoadMonsters);
		}

		private void AppendList<Type>(String filename, List<Type> items)
			where Type : ILineAnalysis, new()
		{
			if (!System.IO.File.Exists(filename)) return;
			String[] lines = System.IO.File.ReadAllLines(filename);
			foreach (String line in lines)
			{
				if (line.Length < 3) continue;
				if (line[0] == '#') continue;
				String[] values = line.Split('\t');
				if (values.Length < 2) continue;
				if (String.IsNullOrEmpty(values[0])) continue;
				if (String.IsNullOrEmpty(values[1])) continue;

				Type type = new Type();
				if(type.Line(values))
				{
					items.Add(type);
				}
			}
		}
	}
}
