/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
using System;

namespace tests
{
	/// <summary>
	/// Description of MemAllocator.
	/// </summary>
	public class MemAllocator
	{
		Int32[] buffer;
		
		public MemAllocator()
		{
			
		}
		
		public void AllocMem(Int64 size_bytes)
		{
			buffer = new Int32[size_bytes / sizeof(Int32)];
			for (Int64 i = 0; i < buffer.Length; i++)
			{
				buffer[i] = 0x01010101;
			}
		}
		
		public void ResetMem()
		{
			buffer = null;
			GC.Collect();
		}
	}
}
