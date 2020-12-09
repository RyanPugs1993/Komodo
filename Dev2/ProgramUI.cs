using KomoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ProgramUI
{
    public class ProgramUI
    {
        public DevRepo _devRepo = new DevRepo();
        public TeamRepo _teamRepo = new TeamRepo();

        public void Run()
        {
            SeedTeamList();
            SeedDevList();
            Menu();
        }

        //menu
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select an option:\n" +
                    "1. Developer Add\n" +
                    "2. Developer List\n" +
                    "3. Lookup Dev ID\n" +
                    "4. Remove Dev\n" +
                    "5. Team Lookup\n" +
                    "6. Add Member to Team\n" +
                    "7. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewDev();
                        break;
                    case "2":
                        CreateNewTeam();
                        break;
                    case "3":
                        GetDeveloperByID();
                        break;
                    case "4": 
                        RemoveDeveloperFromList();
                        break;
                    case "5":
                        TeamList();
                        break;
                    case "6":
                        AddDevToTeam();
                        break;
                    case "7":
                        //exit
                        Console.WriteLine("This Session Has Ended.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }
        public void CreateNewDev()
        {
            Console.Clear();

            Dev newDeveloper = new Dev();

            Console.WriteLine("Enter the name of the Developer:");
            newDeveloper.Name = Console.ReadLine();


            Console.WriteLine("Enter the ID Number of the Developer:");
            string newDevAsString = Console.ReadLine();
            newDeveloper.ID = int.Parse(newDevAsString);

            Console.WriteLine("Do they have Sight Access?");
            string hasPluralSightAccess = Console.ReadLine().ToLower();

            if (hasPluralSightAccess == "y")
            {
                newDeveloper.HasPluralSightAccess = true;
            }
            else
            {
                newDeveloper.HasPluralSightAccess = false;
            }
            _devRepo.AddDeveloperToList(newDeveloper);

        }

        public void CreateNewTeam()
        {
            Console.Clear();

            List<Dev> listOfContent = _devRepo.GetDeveloperList();

            foreach (Dev content in listOfContent)
            {
                Console.WriteLine($"Name: {content.Name}\n" +
                    $" ID Number: {content.ID}\n" +
                    $"Plural Access {content.HasPluralSightAccess}");

            }
        }
        public void TeamList()
        {
            Console.Clear();

            List<Team> listOfContent = _teamRepo.GetTeamList();

            foreach (Team content in listOfContent)
            {
                Console.WriteLine($"Team: {content.Teams}");

            }
        }

        public void AddDevToTeam()
        {
            Console.Clear();

            Team newTeam = new Team();

            Console.WriteLine("Enter the name of the Developer:");
            newTeam.Name = Console.ReadLine();


            Console.WriteLine("Enter the ID Number of the Developer:");
            string newTeamAsString = Console.ReadLine();
            newTeam.ID = int.Parse(newTeamAsString);

            Console.WriteLine("Enter Which team you'd like the Dev to be placed.");
            newTeam.Teams = Console.ReadLine();

        }

        public void GetDeveloperByID()
        {
            Console.Clear();
            Console.WriteLine("Enter The ID of The Employee.");

            int originId = Convert.ToInt32(Console.ReadLine());
            Dev content = _devRepo.GetDeveloperByID(originId);


            if (content != null)
            {
                Console.WriteLine($"Name: {content.Name}\n" +
                    $" ID Number: {content.ID}\n" +
                    $"Plural Access: {content.HasPluralSightAccess}");

            }
            else
            {
                Console.WriteLine("No ID number present.");
            }

        }
        public void RemoveDeveloperFromList()
        {
            CreateNewTeam();

            Console.WriteLine("Enter the ID of the user you'd like to remove.");

            int input = Convert.ToInt32(Console.ReadLine());

            bool wasDeleted = _devRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Dev was successfully removed");
            }
            else
            {
                Console.WriteLine("The Dev could not be removed.");
            }


        }


        private void SeedDevList()
        {
            Dev Teddy = new Dev("Teddy", 45, true);
            Dev Uther = new Dev("Uther", 20, false);
            Dev Joey = new Dev("Joey", 33, true);
            Dev Rexxar = new Dev("Rexxar", 90, true);

            _devRepo.AddDeveloperToList(Teddy);
            _devRepo.AddDeveloperToList(Uther);
            _devRepo.AddDeveloperToList(Joey);
            _devRepo.AddDeveloperToList(Rexxar);
        }
        private void SeedTeamList()
        {
            Team Snake = new Team("Snakes");
            Team Dragon = new Team("Dragon");

            _teamRepo.AddTeamToList(Snake);
            _teamRepo.AddTeamToList(Dragon);
        }
    }
}
