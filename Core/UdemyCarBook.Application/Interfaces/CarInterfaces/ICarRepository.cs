using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces;
public interface ICarRepository
{
    List<Car> GetCarsListWithBrand();
    List<Car> GetLast5CarWithBrand();
   int GetCarCount();
   Car GetCarWithBrandByID(int id);
    
}
