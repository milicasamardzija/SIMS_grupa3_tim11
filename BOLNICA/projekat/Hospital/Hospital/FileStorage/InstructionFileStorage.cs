using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class InstructionFileStorage : GenericFileStorage<Instruction>, IInstructionFileStorage
    {
        public InstructionFileStorage(string filePath) : base(filePath)
        {
        }
    }
}
