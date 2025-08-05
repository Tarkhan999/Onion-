using Service.Services;
using System.Numerics;


EducationService educationService = new();

while (true)
{
    Menues();
Opt: string optStr = Console.ReadLine();
    bool isTrueOption = int.TryParse(optStr, out int option);
    if (!isTrueOption)
    {
        Console.WriteLine("Please Enter Correct Option!");
        goto Opt;
    }

    switch (option)
    {
       case 1:
            educationService.GetAll();

            break;
        case 2:
            educationService.Delete();
            break;
        case 3:
            educationService.Create();
            break;
        
        case 4:
            educationService.GetById();
            break;

        default:
            Console.WriteLine("Option not found,Select again!");

            goto Opt;
    }

}
void Menues()
{
    Console.WriteLine("Select one Option: GetAll---1, Delete---2,Create---3,GetById---4");
}