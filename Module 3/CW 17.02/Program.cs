using System;
using System.IO;
using System.Text;

namespace CW_17._02
{
    namespace Task01
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (File.Exists("test.txt"))
                {
                    using (FileStream fs = new FileStream("test.txt", FileMode.Open))
                    {
                        fs.Seek(-1, SeekOrigin.End);
                        switch ((char) fs.ReadByte())
                        {
                            case 'A':
                                Console.WriteLine("Read A! Wrote B");
                                fs.Write(System.Text.Encoding.Default.GetBytes("B"));
                                break;
                            case 'B':
                                Console.WriteLine("Read B! Wrote C");
                                fs.Write(System.Text.Encoding.Default.GetBytes("C"));
                                break;
                            case 'C':
                                Console.WriteLine("Read C!");
                                byte[] data = new byte[fs.Length];
                                fs.Seek(0, SeekOrigin.Begin);
                                fs.Read(data, 0, (int) fs.Length);
                                Console.WriteLine(System.Text.Encoding.Default.GetString(data));
                                break;
                        }
                    }

                    return;
                }


                using (FileStream fs = new FileStream("test.txt", FileMode.Create))
                {
                    byte[] bytes = new UTF8Encoding().GetBytes("A");
                    fs.Write(bytes, 0, bytes.Length);
                    Console.WriteLine("Wrote A!");
                }
            }
        }
    }
}