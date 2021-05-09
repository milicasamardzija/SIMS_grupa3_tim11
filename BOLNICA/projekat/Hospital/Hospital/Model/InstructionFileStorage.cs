using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.Model
{
    class InstructionFileStorage
    {
        public List<Instruction> GetAll()
        {
            List<Instruction> all = new List<Instruction>();

            all = JsonConvert.DeserializeObject<List<Instruction>>(File.ReadAllText(@"./../../../../Hospital/files/storageInstructions.json"));

            return all;
        }

        public void Save(Instruction newInstruction)
        {
            List<Instruction> all = GetAll();

            all.Add(newInstruction);

            SaveAll(all);
        }

        public void SaveAll(List<Instruction> instructions)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageInstructions.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, instructions);
            }
        }

        public void Delete(Instruction instr)
        {
            List<Instruction> all = GetAll();

            foreach (Instruction instruction in all)
            {
                if (instruction.IdInstruction == instr.IdInstruction)
                {
                    all.Remove(instruction);
                    break;
                }
            }
            SaveAll(all);
        }

        public void DeleteById(int id)
        {
            List<Instruction> all = GetAll();

            foreach (Instruction instruction in all)
            {
                if (instruction.IdInstruction == id)
                {
                    all.Remove(instruction);
                    break;
                }
            }
            SaveAll(all);
        }

        public Instruction FindById(int id)
        {
            List<Instruction> all = GetAll();
            Instruction ret = null;

            foreach (Instruction instruction in all)
            {
                if (instruction.IdInstruction == id)
                {
                    ret = instruction;
                    break;
                }
            }

            return ret;
        }

        public Boolean ExistsById(int id)
        {
            List<Instruction> all = GetAll();
            Boolean ret = false;

            foreach (Instruction instruction in all)
            {
                if (instruction.IdInstruction == id)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}
