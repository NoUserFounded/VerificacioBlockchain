using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace SerialitzacioJSON
{
    public class Blockchain 
    {
        public List<Block> Chain { get; private set; }
        public int Difficulty { get; private set; }

        public Blockchain(int difficulty)
        {
            Difficulty = difficulty;
            Chain = new List<Block> { };
        }

        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddBlock(Block newBlock)
        {
            newBlock.PreviousHash = GetLatestBlock().Hash;
            newBlock.Hash = Block.CalculateHash(newBlock.Index, newBlock.Timestamp, newBlock.Data, newBlock.PreviousHash, newBlock.Nonce);
            newBlock.MineBlock(Difficulty);
            Chain.Add(newBlock);
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != Block.CalculateHash(currentBlock.Index, currentBlock.Timestamp, currentBlock.Data, currentBlock.PreviousHash, currentBlock.Nonce))
                    return false;

                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }
    }
}
