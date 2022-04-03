using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DQ8
{
    class Item : INotifyPropertyChanged
    {
		private readonly uint mID;

		public Item(uint id)
		{
			mID = id;
		}

		public String Name { get; set; }

		public bool Get
		{
			get
			{
				// OLD: return SaveData.Instance().ReadBit(0x11B0 + mID / 8, mID % 8);
				return SaveData.Instance().ReadBit(Offsets.GetAddress("CollectedItem") + mID / 8, mID % 8);
			}

			set
			{
				// OLD: SaveData.Instance().WriteBit(0x11B0 + mID / 8, mID % 8, value);
				SaveData.Instance().WriteBit(Offsets.GetAddress("CollectedItem") + mID / 8, mID % 8, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Get)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
