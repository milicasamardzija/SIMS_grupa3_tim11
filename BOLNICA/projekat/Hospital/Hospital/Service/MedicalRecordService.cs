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

        private IMedicalRecordFileStorage mrStorage;
        private IAlergensFileStorage alergensFileStorage;

        public MedicalRecordService()
        {
            mrStorage = new MedicalRecordsFileStorage("./../../../../Hospital/files/storageMRecords.json");
            alergensFileStorage = new AlergensFileStorage("./../../../../Hospital/files/alergens.json");

        }

        public List<Alergens> getAllAlergens()
        {
            return alergensFileStorage.GetAll();
        }

        public void saveAlergens(List<Alergens> alergens)
        {
            alergensFileStorage.SaveAll(alergens);
        }

        public MedicalRecord findMedicalRecordById(int id)
        {
            return mrStorage.FindById(id);
        }

        public void deleteRecordById(int id)
        {
            mrStorage.DeleteById(id);
        }

        public void saveMedicalRecord(MedicalRecord record)
        {
            mrStorage.Save(record);
        }
    }
  }
