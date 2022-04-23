using System.Collections.Generic;
using System.IO;

namespace LZW
{
    internal class LZWProvider
    {
        private static List<byte> AddByteToByteList(List<byte> oldList, byte newByte)
        {
            List<byte> newList = new List<byte>(oldList.Count + 1);
            newList.AddRange(oldList);
            newList.Add(newByte);
            return newList;
        }

        private static Dictionary<List<byte>, ushort> FillDictionary()
        {
            var dictionary = new Dictionary<List<byte>, ushort>(new ArrayComparer());
            for (var i = 0; i < 256; i++)
            {
                var e = new List<byte> { (byte)i };
                dictionary.Add(e, (ushort)i);
            }
            return dictionary;
        }

        public static void Compress(BinaryReader input, BinaryWriter output)
        {
            var dictionary = FillDictionary();

            var line = new List<byte>() { input.ReadByte() };

            while (input.BaseStream.Position != input.BaseStream.Length)
            {
                if (dictionary.Count == ushort.MaxValue)
                {
                    output.Write(dictionary[line]);
                    output.Write(ushort.MaxValue);
                    dictionary = FillDictionary();
                    line = new List<byte>() { input.ReadByte() };
                }
                var symbol = input.ReadByte();
                var concatenationLineSymbol = AddByteToByteList(line, symbol);

                if (dictionary.ContainsKey(concatenationLineSymbol))
                    line = new List<byte>(concatenationLineSymbol);
                else
                {
                    output.Write(dictionary[line]);
                    dictionary.Add(concatenationLineSymbol, (ushort)dictionary.Count);
                    line = new List<byte>() { symbol };
                }
            }
            output.Write(dictionary[line]);
        }

        private static List<List<byte>> FillTable()
        {
            var table = new List<List<byte>>();
            for (var i = 0; i < 256; i++)
            {
                var e = new List<byte> { (byte)i };
                table.Add(e);
            }
            return table;
        }

        public static void Decompress(BinaryReader input, BinaryWriter output)
        {
            var table = FillTable();

            List<byte> translationOldCode = new List<byte>(table[input.ReadUInt16()]);
            output.Write(translationOldCode.ToArray());

            while (input.BaseStream.Position != input.BaseStream.Length)
            {
                var newCode = input.ReadUInt16();
                if (newCode == ushort.MaxValue)
                {
                    table = FillTable();
                    translationOldCode = new List<byte>(table[input.ReadUInt16()]);
                    output.Write(translationOldCode.ToArray());
                    continue;
                }
                List<byte> line;
                if (newCode < table.Count)
                    line = new List<byte>(table[newCode]);
                else
                    line = AddByteToByteList(translationOldCode, translationOldCode[0]);

                output.Write(line.ToArray());
                table.Add(AddByteToByteList(translationOldCode, line[0]));
                translationOldCode = new List<byte>(line);
            }
        }

    }
}
