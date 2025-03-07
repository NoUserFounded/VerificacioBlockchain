﻿using System;
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
            newBlock.MineBlock(Difficulty);
            Chain.Add(newBlock);
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                    return false;

                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }
    }
}
