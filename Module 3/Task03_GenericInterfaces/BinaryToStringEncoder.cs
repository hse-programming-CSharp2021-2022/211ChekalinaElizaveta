using System;
using System.Collections.Generic;

namespace Task03_GenericInterfaces
{
    public abstract class BinaryToStringEncoder : IEncrypted<byte[], string>
    {
        protected abstract Dictionary<string, byte[]> GetDictionary();

        public byte[] Encode(string u)
        {
            var dict = GetDictionary();
            try
            {
                return dict[u];
            }
            catch (Exception)
            {
                return default;
            }
        }

        public string Decode(byte[] t)
        {
            var dict = GetDictionary();
            foreach (var key in dict.Keys)
            {
                if (t is null || t.Length != dict[key].Length)
                {
                    return default;
                }

                bool ok = true;
                for (int i = 0; i < t.Length; i++)
                {
                    if (dict[key][i] != t[i])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    return key;
                }
            }

            return default;
        }
    }
}