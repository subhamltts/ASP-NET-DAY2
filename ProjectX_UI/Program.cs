using ProjectX_BL;
using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                ParticipantDTO dto = new ParticipantDTO();
                ParticipantsBL dbl = new ParticipantsBL();

                Console.WriteLine("Enter the Department Id to be updated: ");
                int PId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name: ");
                string PName = Console.ReadLine();

                Console.WriteLine("Group Name: ");
                string PEmail = Console.ReadLine();

                dto = dbl.ParticipantInputValues(PId, PName, PEmail);
                int status = dbl.UpdateParticipantInfo(dto);
                if (status == 1)
                {
                    Console.WriteLine("Updated Successfully! ");
                    Console.WriteLine("-------------------------Check List------------------------------------");
                    foreach (var item in dbl.DisplayDepartment())
                    {
                        Console.WriteLine($"{item.ParticipantID}  {item.ParticipantName}  {item.ParticipantEmailID}");
                    }
                }

                Console.WriteLine("Do you want to delete any records? (y/n)");
                if (Console.ReadLine() == "y")
                {
                    Console.WriteLine("Enter the Department Id to be deleted: ");
                    string name = Console.ReadLine();
                    int st = dbl.UpdateParticipantInfo(name);
                    if (st == 1)
                    {
                        Console.WriteLine("Deleted Successfully! ");
                        Console.WriteLine("-------------------------Check List------------------------------------");
                        foreach (var item in dbl.DisplayDepartment())
                        {
                            Console.WriteLine($"{item.ParticipantID}  {item.ParticipantName}  {item.ParticipantEmailID}");
                        }
                    }
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input");
                throw ex;
            }
        }
    } 
}

