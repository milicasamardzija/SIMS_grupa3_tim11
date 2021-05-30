using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    class MedicalRecordService
    {
        private IMedicalRecordFileStorage mrstorage;

        public MedicalRecordService()
        {
            mrstorage = new MedicalRecordsFileStorage("./../../../../Hospital/files/storageMRecords.json");

        }
        public List<MedicalRecord> getAll()
        {
            return mrstorage.GetAll();
        }

    }
}
