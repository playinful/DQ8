﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DQ8
{
	class Recipe : INotifyPropertyChanged
	{
		private readonly uint mNumber;
		public Recipe(uint number)
		{
			mNumber = number;
		}

		public String Name { get; set; }
		public bool Exist
		{
			get
			{
				// OLD: return SaveData.Instance().ReadBit(0x10208 + mNumber / 8, mNumber % 8);
				return SaveData.Instance().ReadBit(Offsets.GetAddress("AlchemyBook") + mNumber / 8, mNumber % 8);
			}

			set
			{
				// OLD: SaveData.Instance().WriteBit(0x10208 + mNumber / 8, mNumber % 8, value);
				SaveData.Instance().WriteBit(Offsets.GetAddress("AlchemyBook") + mNumber / 8, mNumber % 8, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Exist"));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
