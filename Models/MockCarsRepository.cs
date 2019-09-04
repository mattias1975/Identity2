using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVCRecap.Models
{
    public class MockCarsRepository : ICarsRepository
    {
        int idCounter;
        List<Car> cars;

        public MockCarsRepository()
        {
            idCounter = 0;
            cars = new List<Car>();
        }
        public MockCarsRepository(List<Car> cars)
        {
            this.cars = cars;
            idCounter = cars.Count;
        }
        public Car Create(string brand, string name)
        {
            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            Car car = new Car() { Id = ++idCounter, Brand = brand, Name = name };
            cars.Add(car);

            return car;
        }

        public Car FindById(int id)
        {
            return cars.SingleOrDefault(c => c.Id == id);
        }

        public List<Car> AllCars()
        {
            return cars;
        }

        public Car Update(Car car)
        {
            if (car == null)
            {
                return null;
            }

            Car carOrginal = cars.SingleOrDefault(c => c.Id == car.Id);

            if (carOrginal == null)
            {
                return null;
            }
            else
            {
                carOrginal.Brand = car.Brand;
                carOrginal.Name = car.Name;
            }

            return carOrginal;
        }

        public bool Delete(int id)
        {
            Car car = cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return false;
            }

            return cars.Remove(car);
        }
    }
}
