﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DQ8
{
	class Place : INotifyPropertyChanged
	{
		private readonly uint ID;

		public event PropertyChangedEventHandler PropertyChanged;

		public String Name { get; set; }

		public Place(uint id)
		{
			ID = id;
		}

		public bool Arrival
		{
			get
			{
				// OLD: return SaveData.Instance().ReadBit(0x2B34 + ID / 8, ID % 8);
				return SaveData.Instance().ReadBit(Offsets.GetAddress("Place") + ID / 8, ID % 8);
			}

			set
			{
				// OLD: SaveData.Instance().WriteBit(0x2B34 + ID / 8, ID % 8, value);
				SaveData.Instance().WriteBit(Offsets.GetAddress("Place") + ID / 8, ID % 8, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Arrival)));
			}
		}
	}
}
