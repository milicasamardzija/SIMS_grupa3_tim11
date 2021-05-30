using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage.Interfaces
{
    public interface MedicineIFileStorage : GenericRepository<Medicine>
    {
        List<Medicine> loadReplacementMedicines(Medicine medicine);
        List<Medicine> loadApprovedMedicines();
    }
}
