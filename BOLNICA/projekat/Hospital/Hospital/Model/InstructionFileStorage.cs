using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class InstructionFileStorage
    {
        public List<Instruction> GetAll()
        {
            List<Instruction> all = new List<Instruction>();
            all = JsonConvert.DeserializeObject<List<Instruction>>(File.ReadAllText(@"./../../../../Hospital/files/instructions.json"));
            return all;
        }

        public void Save(Instruction newInstruction)
        {
            List<Instruction> all = GetAll();
            all.Add(newInstruction);
            SaveAll(all);
        }

        public void SaveAll(List<Instruction> instruction)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/instructions.json"))
            {
                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(file, instruction);
            }
        }

        public void Delete(Instruction instructions)
        {
            List<Instruction> all = GetAll();
            foreach (Instruction instruction in all)
            {
                if (instruction.idInstruction == instructions.idInstruction)
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
                if (instruction.idInstruction == id)
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
                if (instruction.idInstruction == id)
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
                if (instruction.idInstruction == id)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}
