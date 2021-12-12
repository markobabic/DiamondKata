using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const char PaddingChar = ' ';

        public List<string> Generate(char seed)
        {
            var result = new List<string>();

            var index = Alphabet.IndexOf(char.ToUpper(seed)) + 1;
            var size = 2 * index - 1;
            var line = new string(PaddingChar, size);

            for (var i = 0; i < index; i++)
                result.Add(GetLineWithInsertedChars(line, i, index - 1));

            result.AddRange(GetMirroredRows(result));

            return result;
        }

        private IEnumerable<string> GetMirroredRows(List<string> rows)
        {
            return rows
                    .AsEnumerable()
                    .Reverse()
                    .Skip(1)
                    .ToList();
        }

        private string GetLineWithInsertedChars(string line, int i, int index)
        {
            var charToInsert = Alphabet[i];
            var array = line.ToCharArray();
            array[index - i] = array[index + i] = charToInsert;

            return new string(array);
        }
    }
}
