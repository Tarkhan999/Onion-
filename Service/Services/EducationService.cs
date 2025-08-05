using Domain.Entities;
using Repository.Repositories;
using Service.Services.Interfaces;
using System.Diagnostics;

namespace Service.Services
{
    public class EducationService:IEducationService
    {
        private readonly EducationRepository _educationRepo;
        public EducationService()
        {
            _educationRepo = new EducationRepository();
        }

        public void Create()
        {
            Console.WriteLine("Add Name:");
            string strName = Console.ReadLine();
            Price: Console.WriteLine("Add Price:");
            string strPrice = Console.ReadLine();
            bool isTruePrice = decimal.TryParse(strPrice, out decimal priceEdu);
            if (!isTruePrice)
            {
                Console.WriteLine("Add correct price");
                goto Price;
            }
            Education education = new()
            {
                Name= strName,
                Price = priceEdu

            };
            _educationRepo.Create(education);
        }

        public void Delete()
        {
            Console.WriteLine("Enter Id:");
        Id: string strId = Console.ReadLine();
            bool isTrueId = int.TryParse(strId, out int id);
            if (!isTrueId)
            {
                Console.WriteLine("Id is wrong");
                goto Id;
            }
            else
            {
                _educationRepo.Delete(_educationRepo.GetById(id));
                Console.WriteLine("Deleted");
            }
        }

        public void Edit(int id)
        {
            var education = _educationRepo.GetById(id);
            if (education is null)
            {
                Console.WriteLine("Education not found");
                return;
            }
            Console.WriteLine($"{education.Id},{education.Name},{education.Price}");
            Console.WriteLine($"Add Education New Name{education.Name}:");
            string strName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(strName))
            {
                strName = education.Name;
            }
            Console.WriteLine($"New Price{education.Price}");
            string strPrice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(strPrice))
            {
                strPrice = education.Price.ToString();
            }
            Education educationNew = new()
            {
                Id = education.Id,
                Name = strName,
                Price = decimal.Parse(strPrice),
               
            };


        }

       

        public void GetAll()
        {
           var datas= _educationRepo.GetAll();
            foreach (var item in datas)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}");
            }
        }

        public void GetAllWithExpression(Func<object, bool> predicate)
        {
            var res = _educationRepo.GetAll();
            List<Education> Search(List<Education> datas, Func<Education, bool> predicate)
            {
                return datas.Where(predicate).ToList();

            }
            string str=  Console.ReadLine();
            var result = Search(res, m => m.Name.Contains(str));
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }

        }


        public void GetById()
        {
            Console.WriteLine("Add Id");
        Id: string strId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(strId))
            {
                Console.WriteLine("Input is required,select again :");
                goto Id;
            }
            if(int.TryParse(strId,out int id))
            {
                var data= _educationRepo.GetById(id);
                if(data is null)
                {
                    Console.WriteLine("Data not Found");
                    goto Id;
                }
                Console.WriteLine($"Id: {data.Id}, Name: {data.Name}, Price: {data.Price}");
            }
            else
            {
                Console.WriteLine("Id is wrong,enter ID again ");
                goto Id;
            }
        }
    }
}
