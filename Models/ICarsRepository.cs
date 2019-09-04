using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVCRecap.Models
{
    public interface ICarsRepository
    {
        Car Create(string brand, string name);
        List<Car> AllCars();
        Car FindById(int id);
        Car Update(Car car);
        bool Delete(int id);
    }
}
