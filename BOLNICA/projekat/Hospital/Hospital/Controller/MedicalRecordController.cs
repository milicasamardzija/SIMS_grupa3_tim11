using Hospital.DTO;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
  public class MedicalRecordController
    {
        private MedicalRecordService servis;

        public MedicalRecordController()
        {
            servis = new MedicalRecordService();
        }
        public ObservableCollection<AlergensDTO> getAllAlergens()
        {
            ObservableCollection<AlergensDTO> alergens = new ObservableCollection<AlergensDTO>();
            foreach (Alergens a in servis.getAllAlergens())
            {
                alergens.Add(new AlergensDTO(a.Name, a.Code));
            }
            return alergens;
        }

        public void saveAlergens(ObservableCollection<AlergensDTO> selectedAlergens)
        {
            List<Alergens> alergens = new List<Alergens>((IEnumerable<Alergens>)selectedAlergens);
            servis.saveAlergens(alergens);
        }

        public ObservableCollection<AlergensDTO> loadPatientAlergens(int id)
        {

            ObservableCollection<AlergensDTO> alergens = new ObservableCollection<AlergensDTO>();

            MedicalRecord record = new MedicalRecord();
            record=servis.findMedicalRecordById(id);

            foreach (Alergens a in record.Alergens)
            {

                alergens.Add(new AlergensDTO(a.Name, a.Code));
            }
            return alergens;

        }
        public MedicalRecordDTO findRecordById(int id)
        {
            MedicalRecord record = new MedicalRecord();
            record = servis.findMedicalRecordById(id);
            ObservableCollection<AlergensDTO> alergens = new ObservableCollection<AlergensDTO>(); //zbog konverzije 

            foreach (Alergens a in record.Alergens)
            {
                alergens.Add(new AlergensDTO(a.Name, a.Code)); 
            }
            MedicalRecordDTO foundRecord = new MedicalRecordDTO(record.Name, record.Surname, record.Jmbg, record.Gender, record.BirthdayDate, record.MedicalRecordId, record.HealthCareCategory, record.IdHealthCard, record.BloodType, alergens);

            return foundRecord;
        }
        public void deleteRecordById(int id)
        {
            servis.deleteRecordById(id);
        }
        public void saveMedicalRecord(MedicalRecordDTO record)
        {
            ObservableCollection<Alergens> alergeni = new ObservableCollection<Alergens>();
            foreach(AlergensDTO a in record.Alergens)
            {
                alergeni.Add(new Alergens(a.Name, a.Code));
            }

            MedicalRecord medicalRecord = new MedicalRecord(record.Name, record.Surname, record.Jmbg, record.Gender, record.BirthdayDate, record.MedicalRecordId, record.HealthCareCategory, record.IdHealthCard, record.BloodType, alergeni);
            servis.saveMedicalRecord(medicalRecord);
        }
    }
}
