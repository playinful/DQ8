using System.Collections.Generic;

namespace DQ8
{
	class Util
	{
		// OLD: public static uint BlockSize = 0x10B78;
		// playinful: I'd like to replace this with a dictionary, since it seems that the US and JP versions have different block sizes.
		public static uint BlockSize {
            get
            {
				switch(Info.Instance().Mode)
                {
					case "NA":
					default:
						return 0x10C10; // 68624
					case "JP":
						return 0x10B78; // 68472
				}
            }
		}
		public static uint ItemCount = 430; // might actually be 433
		// OLD: public static uint ItemAddress = 0x0ADC; // 2780; NA: 0x0AE4 (2788)
		public static uint ItemAddress {
			get {
				return Offsets.GetOffsetData("ItemAddress").Start;
			}
		}

		public static void WriteNumber(uint address, uint size, uint value, uint min, uint max)
		{
			if (value < min) value = min;
			if (value > max) value = max;
			SaveData.Instance().WriteNumber(address, size, value);
		}
		public static void WriteNumber(string offset_id, uint value, uint min, uint max, int addOffset = 0)
		{
			if (value < min) value = min;
			if (value > max) value = max;
			SaveData.Instance().WriteNumber(offset_id, value, addOffset);
		}
		public static void WriteNumber(string offset_id, uint value, uint min, uint max, uint addOffset)
        {
			WriteNumber(offset_id, value, min, max, (int)addOffset);
        }
	}
}
