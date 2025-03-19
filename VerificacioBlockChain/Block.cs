using System;
using System.Security.Cryptography;
using System.Text;

namespace SerialitzacioJSON
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public string Data { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public int Nonce { get; set; }


        public Block(int index, DateTime timestamp, string data, string previousHash, int nonce)
        {
            Index = index;
            Timestamp = timestamp;
            Data = data;
            PreviousHash = previousHash;
            Nonce = nonce;
            Hash = string.Empty; // El hash se calcula al crear el bloque
        }

        // Método para calcular el hash del bloque
        public static string CalculateHash(int index, DateTime timestamp, string data, string previousHash, int nonce)
        {
            string blockData = index.ToString() + timestamp.ToString() + data + previousHash + nonce.ToString();
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(blockData));
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }
    
        public void MineBlock(int difficulty)
        {
            string target = new string('0', difficulty);
            while (!Hash.StartsWith(target))
            {
                Nonce++;
                Hash = CalculateHash(this.Index,this.Timestamp,this.Data,this.PreviousHash,this.Nonce);
            }
        }
    }
}