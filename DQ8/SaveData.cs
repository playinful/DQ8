using System;

namespace DQ8
{
	class SaveData
	{
		private static SaveData mThis;
		private String mFileName = null;
		private Byte[] mBuffer = null;
		private uint mAdventure = 0;
		public uint Adventure
		{
			set
			{
				Save();
				mAdventure = value;
			}
		}

		private SaveData()
		{}

		public static SaveData Instance()
		{
			if (mThis == null) mThis = new SaveData();
			return mThis;
		}

		public void Open(String filename)
		{
			mFileName = filename;
			mBuffer = System.IO.File.ReadAllBytes(mFileName);

			Backup();

			GetSetMode();
		}
		// playinful: this is called after we open a file to see which mode we should use.
		public String GetSetMode()
        {
			switch(mBuffer.Length)
            {
				case 212560:
				default:
					Info.Instance().Mode = "NA";
					break;
				case 212104:
					Info.Instance().Mode = "JP";
					break;
			}

			return Info.Instance().Mode;
        }

		public bool Save()
		{
			if (mFileName == null || mBuffer == null) return false;
			System.IO.File.WriteAllBytes(mFileName, mBuffer);
			return true;
		}

		public bool SaveAs(String filenname)
		{
			if (mBuffer == null) return false;
			mFileName = filenname;
			return Save();
		}

		public uint ReadNumber(uint address, uint size)
		{
			if (mBuffer == null) return 0;
			address = CalcAddress(address);
			if (address + size > mBuffer.Length) return 0;
			uint result = 0;
			for(int i = 0; i < size; i++)
			{
				result += (uint)(mBuffer[address + i]) << (i * 8);
			}
			return result;
		}
		// playinful: rewritten to be used with offset IDs
		public uint ReadNumber(string offset_id, int addOffset = 0)
		{
			OffsetData offsetData = Offsets.GetOffsetData(offset_id);
			if (offsetData != null)
				return ReadNumber((uint)(offsetData.Start + addOffset), offsetData.Length);
			return 0;
		}
		public uint ReadNumber(string offset_id, uint addOffset)
        {
			return ReadNumber(offset_id, (int)addOffset);
        }

		// 0 to 7.
		public bool ReadBit(uint address, uint bit)
		{
			if (bit < 0) return false;
			if (bit > 7) return false;
			if (mBuffer == null) return false;
			address = CalcAddress(address);
			if (address > mBuffer.Length) return false;
			Byte mask = (Byte)(1 << (int)bit);
			Byte result = (Byte)(mBuffer[address] & mask);
			return result != 0;
		}
		// playinful: rewritten to be used with offset IDs
		public bool ReadBit(string offset_id)
		{
			OffsetData offsetData = Offsets.GetOffsetData(offset_id);
			if (offsetData != null)
				return ReadBit(offsetData.Start, offsetData.Length);
			return false;
		}

		public String ReadUnicode(uint address, uint size)
		{
			if (mBuffer == null) return "";
			address = CalcAddress(address);
			if (address + size > mBuffer.Length) return "";

			Byte[] tmp = new Byte[size];
			for(uint i = 0; i < size; i++)
			{
				tmp[i] = mBuffer[address + i];
			}
			return System.Text.Encoding.Unicode.GetString(tmp).Trim('\0');
		}
		// playinful: rewritten to be used with offset IDs
		public String ReadUnicode(string offset_id)
		{
			OffsetData offsetData = Offsets.GetOffsetData(offset_id);
			if (offsetData != null)
				return ReadUnicode(offsetData.Start, offsetData.Length);
			return null;
		}

		public void WriteNumber(uint address, uint size, uint value)
		{
			if (mBuffer == null) return;
			address = CalcAddress(address);
			if (address + size > mBuffer.Length) return;
			for (uint i = 0; i < size; i++)
			{
				mBuffer[address + i] = (Byte)(value & 0xFF);
				value >>= 8;
			}
		}
		// playinful: rewritten to be used with offset IDs
		public void WriteNumber(string offset_id, uint value, int addOffset = 0)
		{
			OffsetData offsetData = Offsets.GetOffsetData(offset_id);
			if (offsetData != null)
				WriteNumber((uint)(offsetData.Start + addOffset), offsetData.Length, value);
		}

		// 0 to 7.
		public void WriteBit(uint address, uint bit, bool value)
		{
			if (bit < 0) return;
			if (bit > 7) return;
			if (mBuffer == null) return;
			address = CalcAddress(address);
			if (address > mBuffer.Length) return;
			Byte mask = (Byte)(1 << (int)bit);
			if (value) mBuffer[address] = (Byte)(mBuffer[address] | mask);
			else mBuffer[address] = (Byte)(mBuffer[address] & ~mask);
		}
		// playinful: rewritten to be used with offset IDs
		public void WriteBit(string offset_id, bool value)
		{
			OffsetData offsetData = Offsets.GetOffsetData(offset_id);
			if (offsetData != null)
				WriteBit(offsetData.Start, offsetData.Length, value);
		}

		public void WriteUnicode(uint address, uint size, String value)
		{
			if (mBuffer == null) return;
			address = CalcAddress(address);
			if (address + size > mBuffer.Length) return;
			Byte[] tmp = System.Text.Encoding.Unicode.GetBytes(value);
			Array.Resize(ref tmp, (int)size);
			for (uint i = 0; i < size; i++)
			{
				mBuffer[address + i] = tmp[i];
			}
		}
		// playinful: rewritten to be used with offset IDs
		public void WriteUnicode(string offset_id, String value)
		{
			OffsetData offsetData = Offsets.GetOffsetData(offset_id);
			if (offsetData != null)
				WriteUnicode(offsetData.Start, offsetData.Length, value);
		}

		public void Fill(uint address, uint size, Byte number)
		{
			if (mBuffer == null) return;
			address = CalcAddress(address);
			if (address + size > mBuffer.Length) return;
			for (uint i = 0; i < size; i++)
			{
				mBuffer[address + i] = number;
			}
		}

		public void Copy(uint from, uint to, uint size)
		{
			if (mBuffer == null) return;
			from = CalcAddress(from);
			to = CalcAddress(to);
			if (from + size > mBuffer.Length) return;
			if (to + size > mBuffer.Length) return;
			for(uint i = 0; i < size; i++)
			{
				mBuffer[to + i] = mBuffer[from + i];
			}
		}

		public void Swap(uint from, uint to, uint size)
		{
			if (mBuffer == null) return;
			from = CalcAddress(from);
			to = CalcAddress(to);
			if (from + size > mBuffer.Length) return;
			if (to + size > mBuffer.Length) return;
			for (uint i = 0; i < size; i++)
			{
				Byte tmp = mBuffer[to + i];
				mBuffer[to + i] = mBuffer[from + i];
				mBuffer[from + i] = tmp;
			}
		}

		private uint CalcAddress(uint address)
		{
			// OLD: return address + Util.BlockSize_US * mAdventure;
			// playinful: Replacing this to account for the different file sizes

			return address + Util.BlockSize * mAdventure;
		}

		private void Backup()
		{
			DateTime now = DateTime.Now;
			String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			path = System.IO.Path.Combine(path, "backup");
			if(!System.IO.Directory.Exists(path))
			{
				System.IO.Directory.CreateDirectory(path);
			}
			path = System.IO.Path.Combine(path, 
				String.Format("{0:0000}-{1:00}-{2:00} {3:00}-{4:00}", now.Year, now.Month, now.Day, now.Hour, now.Minute));
			System.IO.File.WriteAllBytes(path, mBuffer);
		}
	}
}
