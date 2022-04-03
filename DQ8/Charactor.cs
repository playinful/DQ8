using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DQ8
{
	class Charactor
    {
		private readonly uint mStatusAddress;
		private readonly uint mItemAddress;

		public ObservableCollection<CharactorItem> Items { get; set; } = new ObservableCollection<CharactorItem>();
		public List<Skill> Skills { get; set; } = new List<Skill>();
		public String Name { get; set; }

		public Charactor(uint statusAddress, uint itemAddress, List<String> skillNames)
		{
			mStatusAddress = statusAddress;
			mItemAddress = itemAddress;
			for (uint i = 0; i < skillNames.Count; i++)
			{
				// OLD: Skill skill = new Skill(mStatusAddress + 0x2C + i * 2);
				Skill skill = new Skill(mStatusAddress + Offsets.GetAddress("PartySkillAddress") + i * Offsets.GetLength("PartySkillAddress"));
				skill.Name = skillNames[(int)i];
				Skills.Add(skill);
			}
			for(uint i = 0; i < 12; i++)
			{
				Items.Add(new CharactorItem(itemAddress + i * 2));
			}
		}

		public uint HP
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress, 2);
				return SaveData.Instance().ReadNumber("PartyHP", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress, 2, value, 0, 999);
				Util.WriteNumber("PartyHP", value, 0, 999, mStatusAddress);
			}
		}

		public uint MP
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x08, 2);
				return SaveData.Instance().ReadNumber("PartyMP", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x08, 2, value, 0, 999);
				Util.WriteNumber("PartyMP", value, 0, 999, mStatusAddress);
			}
		}

		public uint Lv
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x14, 2);
				return SaveData.Instance().ReadNumber("PartyLv", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x14, 2, value, 1, 99);
				Util.WriteNumber("PartyLv", value, 1, 99, mStatusAddress);
			}
		}

		public uint Exp
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x0C, 4);
				return SaveData.Instance().ReadNumber("PartyExp", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x0C, 4, value, 0, 9999999);
				Util.WriteNumber("PartyExp", value, 0, 9999999, mStatusAddress);
			}
		}

		public uint Power
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x16, 2);
				return SaveData.Instance().ReadNumber("PartyPower", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x16, 2, value, 0, 999);
				Util.WriteNumber("PartyPower", value, 0, 999, mStatusAddress);
			}
		}

		public uint Defense
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x18, 2);
				return SaveData.Instance().ReadNumber("PartyDefense", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x18, 2, value, 0, 999);
				Util.WriteNumber("PartyDefense", value, 0, 999, mStatusAddress);
			}
		}

		public uint Speed
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x1A, 2);
				return SaveData.Instance().ReadNumber("PartySpeed", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x1A, 2, value, 0, 999);
				Util.WriteNumber("PartySpeed", value, 0, 999, mStatusAddress);
			}
		}

		public uint Cool
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x1C, 2);
				return SaveData.Instance().ReadNumber("PartyCool", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x1C, 2, value, 0, 999);
				Util.WriteNumber("PartyCool", value, 0, 999, mStatusAddress);
			}
		}

		public uint HPPlus
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x20, 2);
				return SaveData.Instance().ReadNumber("PartyHPPlus", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x20, 2, value, 0, 999);
				Util.WriteNumber("PartyHPPlus", value, 0, 999, mStatusAddress);
			}
		}

		public uint MPPlus
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x22, 2);
				return SaveData.Instance().ReadNumber("PartyMPPlus", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x22, 2, value, 0, 999);
				Util.WriteNumber("PartyMPPlus", value, 0, 999, mStatusAddress);
			}
		}

		public uint PowerPlus
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x24, 2);
				return SaveData.Instance().ReadNumber("PartyPowerPlus", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x24, 2, value, 0, 999);
				Util.WriteNumber("PartyPowerPlus", value, 0, 999, mStatusAddress);
			}
		}

		public uint DefensePlus
		{
			get
			{
				// OLD: return SaveData.Instance().ReadNumber(mStatusAddress + 0x26, 2);
				return SaveData.Instance().ReadNumber("PartyDefensePlus", mStatusAddress);
			}

			set
			{
				// OLD: Util.WriteNumber(mStatusAddress + 0x26, 2, value, 0, 999);
				Util.WriteNumber("PartyDefensePlus", value, 0, 999, mStatusAddress);
			}
		}

		public uint SpeedPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber("PartySpeedPlus", mStatusAddress);
			}

			set
			{
				Util.WriteNumber("PartySpeedPlus", value, 0, 999, mStatusAddress);
			}
		}

		public uint CoolPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber("PartyCoolPlus", mStatusAddress);
			}

			set
			{
				Util.WriteNumber("PartyCoolPlus", value, 0, 999, mStatusAddress);
			}
		}

		public uint SkillPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber("PartySkillPlus", mStatusAddress);
			}

			set
			{
				Util.WriteNumber("PartySkillPlus", value, 0, 999, mStatusAddress);
			}
		}

		public int EquipmentWeapon
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber("PartyWeapon", mItemAddress);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber("PartyWeapon", num, 0, 0xFFFF, mItemAddress);
			}
		}

		public int EquipmentArmor
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber("PartyArmor", mItemAddress);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber("PartyArmor", num, 0, 0xFFFF, mItemAddress);
			}
		}

		public int EquipmentShield
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber("PartyShield", mItemAddress);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber("PartyShield", num, 0, 0xFFFF, mItemAddress);
			}
		}

		public int EquipmentHelmet
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber("PartyHelmet", mItemAddress);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber("PartyHelmet", num, 0, 0xFFFF, mItemAddress);
			}
		}

		public int EquipmentAccessory
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber("PartyAccessory", mItemAddress);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber("PartyAccessory", num, 0, 0xFFFF, mItemAddress);
			}
		}
	}
}
