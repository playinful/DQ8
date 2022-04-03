using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DQ8
{
	class DataContext
	{
		public Info Info { get; set; } = Info.Instance();
		public ObservableCollection<Charactor> Party { get; set; } = new ObservableCollection<Charactor>();
		public ObservableCollection<Place> Places { get; set; } = new ObservableCollection<Place>();
		public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
		public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();
		public ObservableCollection<Monster> Monsters { get; set; } = new ObservableCollection<Monster>();
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<BattleMonster> BattleLoadMonsters { get; set; } = new ObservableCollection<BattleMonster>();
		public ObservableCollection<BattleMonsterRank> Ranks { get; set; } = new ObservableCollection<BattleMonsterRank>();
		public Bag Bag { get; set; } = new Bag();

		public DataContext()
		{
			// 人物
			List<List<String>> skills = new List<List<string>>()
			{
				new List<String>{"Swords", "Spears", "Boomerangs", "Fisticuffs", "Courage"    },
				new List<String>{"Axes"  , "Clubs" , "Scythes"   , "Fisticuffs", "Humanity"   },
				new List<String>{"Knives", "Whips" , "Staves"    , "Fisticuffs", "Sex Appeal" },
				new List<String>{"Swords", "Bows"  , "Staves"    , "Fisticuffs", "Charisma"   },
				new List<String>{"Fans"  , "Whips" , "Knives"    , "Fisticuffs", "Roguery"    },
				new List<String>{"Claws" , "Clubs" , "Boomerangs", "Fisticuffs", "Passion"    },
			};
			foreach (var member in Info.Instance().Orders)
			{
				if (member.Value == 0xFF) continue;
				// OLD : Charactor ch = new Charactor(0x11EC + member.Value * 64, 0xA10 + member.Value * 34, skills[(int)member.Value]);
				Charactor ch = new Charactor(
					Offsets.GetAddress("PartyStatus") + member.Value * Offsets.GetLength("PartyStatus"),
					Offsets.GetAddress("PartyItem")   + member.Value * Offsets.GetLength("PartyItem"),
					skills[(int)member.Value]
				);
				ch.Name = member.Name;
				Party.Add(ch);
			}

			// ルーラ
			foreach (var item in Info.Instance().Places)
			{
				Place zoom = new Place(item.Value);
				zoom.Name = item.Name;
				Places.Add(zoom);
			}

			// パーティ並び
			for (uint i = 0; i < 6; i++)
			{
				// OLD: Orders.Add(new Order(0x11A0 + i));
				Orders.Add(new Order(Offsets.GetAddress("Order") + i));
			}

			// 錬金釜
			foreach (var recipe in Info.Instance().Recipes)
			{
				Recipes.Add(new Recipe(recipe.Value) { Name = recipe.Name });
			}

			// モンスター図鑑
			foreach (var monster in Info.Instance().Monsters)
			{
				Monsters.Add(new Monster(monster.Value) { Name = monster.Name });
			}

			// アイテム図鑑
			foreach (var item in Info.Instance().Items)
			{
				if (item.Value == 0) continue;
				Items.Add(new Item(item.Value) { Name = item.Name });
			}

			// バトルロードモンスター
			for (uint i = 0; i < 24; i++)
			{
				// OLD: BattleLoadMonsters.Add(new BattleMonster(0x13F0 + i * 8));
				BattleLoadMonsters.Add(new BattleMonster(Offsets.GetAddress("BattleMonster") + i * 8));
			}

			String[] names = { "G", "F", "E", "D", "C", "B", "A", "S" };
			for (uint i = 0; i < names.Length; i++)
			{
				Ranks.Add(new BattleMonsterRank(i) { Name = "Rank " + names[i] });
			}
		}

		public uint PlayHour
		{ //TODO
			get
			{
				return SaveData.Instance().ReadNumber("PlayTime") / 3600;
			}
			set
			{
				uint number = SaveData.Instance().ReadNumber(0x2C48, 4) % 3600;
				SaveData.Instance().WriteNumber("PlayTime", value * 3600 + number);
			}
		}

		public uint PlayMinute
		{
			get
			{
				return SaveData.Instance().ReadNumber("PlayTime") % 3600 / 60;
			}
			set
			{
				uint number = SaveData.Instance().ReadNumber("PlayTime");
				number = number / 3600 * 3600 + number % 60;
				SaveData.Instance().WriteNumber("PlayTime", value * 60 + number);
			}
		}

		public uint PlaySecond
		{
			get
			{
				return SaveData.Instance().ReadNumber("PlayTime") % 60;
			}
			set
			{
				uint number = SaveData.Instance().ReadNumber("PlayTime");
				number = number / 60 * 60;
				SaveData.Instance().WriteNumber("PlayTime", value + number);
			}
		}

		public String HeroName
		{
			get
			{
				// OLD: return SaveData.Instance().ReadUnicode(0x09F8, 8);
				return SaveData.Instance().ReadUnicode("HeroName");
			}

			set
			{
				SaveData.Instance().WriteUnicode("HeroName", value);
			}
		}

		public uint BattleCount
		{
			get
			{
				return SaveData.Instance().ReadNumber("BattleCount");
			}
			set
			{
				Util.WriteNumber("BattleCount", value, 0, 9999999);
			}
		}

		public uint GoldHand
		{
			get
			{
				return SaveData.Instance().ReadNumber("GoldHand");
			}
			set
			{
				Util.WriteNumber("GoldHand", value, 0, 99999999);
			}
		}

		public uint GoldBank
		{
			get
			{
				return SaveData.Instance().ReadNumber("GoldBank");
			}
			set
			{
				Util.WriteNumber("GoldBank", value, 0, 99999000);
			}
		}

		public uint CasinoCoin
		{
			get
			{
				return SaveData.Instance().ReadNumber("CasinoCoin");
			}
			set
			{
				Util.WriteNumber("CasinoCoin", value, 0, 99999999);
			}
		}

		public uint SmallMedal
		{
			get
			{
				return SaveData.Instance().ReadNumber("SmallMedal");
			}
			set
			{
				Util.WriteNumber("SmallMedal", value, 0, 9999999);
			}
		}

		public uint KillCount
		{
			get
			{
				return SaveData.Instance().ReadNumber("KillCount");
			}
			set
			{
				Util.WriteNumber("KillCount", value, 0, 9999999);
			}
		}

		public uint WardOffCount
		{
			get
			{
				return SaveData.Instance().ReadNumber("WardOffCount");
			}
			set
			{
				Util.WriteNumber("WardOffCount", value, 0, 9999999);
			}
		}

		public uint EscapeCount
		{
			get
			{
				return SaveData.Instance().ReadNumber("EscapeCount");
			}
			set
			{
				Util.WriteNumber("EscapeCount", value, 0, 9999999);
			}
		}

		public uint VictoryCount
		{
			get
			{
				return SaveData.Instance().ReadNumber("VictoryCount");
			}
			set
			{
				Util.WriteNumber("VictoryCount", value, 0, 9999999);
			}
		}

		public uint AnnihilationCount
		{
			get
			{
				return SaveData.Instance().ReadNumber("AnnihilationCount");
			}
			set
			{
				Util.WriteNumber("AnnihilationCount", value, 0, 9999999);
			}
		}

		public uint TotalGold
		{
			get
			{
				return SaveData.Instance().ReadNumber("TotalGold");
			}
			set
			{
				Util.WriteNumber("TotalGold", value, 0, 9999999);
			}
		}

		public uint MaxDamage
		{
			get
			{
				return SaveData.Instance().ReadNumber("MaxDamage");
			}
			set
			{
				Util.WriteNumber("MaxDamage", value, 0, 9999999);
			}
		}

		public String TermName1
		{
			get
			{
				return SaveData.Instance().ReadUnicode("TermName1");
			}

			set
			{
				SaveData.Instance().WriteUnicode("TermName1", value);
			}
		}

		public String TermName2
		{
			get
			{
				return SaveData.Instance().ReadUnicode("TermName2");
			}

			set
			{
				SaveData.Instance().WriteUnicode("TermName2", value);
			}
		}

		public uint Term11
		{
			get
			{
				return SaveData.Instance().ReadNumber("Term11");
			}
			set
			{
				Util.WriteNumber("Term11", value, 0, 23);
			}
		}

		public uint Term12
		{
			get
			{
				return SaveData.Instance().ReadNumber("Term12");
			}
			set
			{
				Util.WriteNumber("Term12", value, 0, 23);
			}
		}

		public uint Term13
		{
			get
			{
				return SaveData.Instance().ReadNumber("Term13");
			}
			set
			{
				Util.WriteNumber("Term13", value, 0, 23);
			}
		}

		public uint Term21
		{
			get
			{
				return SaveData.Instance().ReadNumber("Term21");
			}
			set
			{
				Util.WriteNumber("Term21", value, 0, 23);
			}
		}

		public uint Term22
		{
			get
			{
				return SaveData.Instance().ReadNumber("Term22");
			}
			set
			{
				Util.WriteNumber("Term22", value, 0, 23);
			}
		}

		public uint Term23
		{
			get
			{
				return SaveData.Instance().ReadNumber("Term23");
			}
			set
			{
				Util.WriteNumber("Term23", value, 0, 23);
			}
		}

		public bool Alchemy
		{
			get
			{
				return SaveData.Instance().ReadNumber("Alchemy") == 1;
			}

			set
			{
				SaveData.Instance().WriteNumber("Alchemy", value ? 1U : 0);
			}
		}

		public bool TermMake
		{
			get
			{
				return SaveData.Instance().ReadBit("TermMake");
			}

			set
			{
				SaveData.Instance().WriteBit("TermMake", value);
			}
		}

		public bool TermCall
		{
			get
			{
				return SaveData.Instance().ReadBit("TermCall");
			}

			set
			{
				SaveData.Instance().WriteBit("TermCall", value);
			}
		}
	}
}
