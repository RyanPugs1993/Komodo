using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUI
{
    class ProgramUI
    {
        private DevRepo _devRepo = new DevRepo();

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        //menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select an option:\n" +
                    "1. Developer Access\n" +
                    "2. DevTeam Access\n" +
                    "3. Exit");

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
                        //exit
                        Console.WriteLine("Goodbye!");
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
        private void CreateNewDev()
        {
            Console.Clear();
            AddDeveloperToList newDeveloper = new AddDeveloperToList();

            Console.WriteLine("Enter the name of the Developer:");
            newDeveloper.Name = Console.ReadLine();


            Console.WriteLine("Enter the ID Number of the Developer:");
            newDeveloper.ID = Console.ReadLine();

            Console.WriteLine("Do they have Sight Access?");
            string hasPluralSightAccess = Console.ReadLine().ToLower();

            if (hasPluralSightAccess == "y")
            {
                newDeveloper.hasPluralSightAccess = true;
            }
            else
            {
                newDeveloper.hasPluralSightAccess = false;
            }

        }

        private void DisplayAllContent()
        {
            Console.Clear();

            List<StreamingContent> listOfContent = _contentRepo.GetContentList();

            foreach (StreamingContent content in listOfContent)
            {
                Console.WriteLine($"Title: {content.Title}\n" +
                    $" Desc: {content.Description}");
            }
        }

        //view existing content by title
        private void DisplayContentByTitle()
        {
            Console.Clear();
            //Prompt user to give me a title
            Console.WriteLine("Enter the title of the content you'd like to see:");

            //get the users input
            string title = Console.ReadLine();

            //find content by title
            StreamingContent content = _contentRepo.GetContentByTitle(title);

            //display said content if it isn't null
            if (content != null)
            {
                Console.WriteLine($"Title: {content.Title}\n" +
                    $" Desc: {content.Description}\n" +
                    $"Maturity Rating: {content.MaturityRating}\n" +
                    $"Stars: {content.StarRating}\n" +
                    $"Is Family Friendly: {content.IsFamilyFriendly}\n" +
                    $"Genre: {content.TypeOfGenre}");
            }
            else
            {
                Console.WriteLine("No Content by that title.");
            }

        }

        //update existing content
        private void UpdateExistingContent()
        {
            //Display all content
            DisplayAllContent();

            // ask for the title of the content to update
            Console.WriteLine("Enter the title of the content you'd like to update:");

            //get that title
            string oldTitle = Console.ReadLine();

            //we will build a new object
            StreamingContent newContent = new StreamingContent();

            Console.WriteLine("Enter the title for the content:");
            newContent.Title = Console.ReadLine();


            Console.WriteLine("Enter the description for the content:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Enter the rating for the content (G, PG, PG-13, R, M, etc: ");
            newContent.MaturityRating = Console.ReadLine();

            Console.WriteLine("Enter the star count for the content:");
            string starsAsString = Console.ReadLine();
            newContent.StarRating = double.Parse(starsAsString);

            Console.WriteLine("Is this content family friendly?");
            string familyFriendlyString = Console.ReadLine().ToLower();

            if (familyFriendlyString == "y")
            {
                newContent.IsFamilyFriendly = true;
            }
            else
            {
                newContent.IsFamilyFriendly = false;
            }

            Console.WriteLine("Enter the Genre number:\n" +
                "1. Horror\n" +
                "2. RomCom\n" +
                "3. SciFi\n" +
                "4. Documentary\n" +
                "5. Drama\n" +
                "6. Action");

            string genreAsString = Console.ReadLine();
            int genreAsInt = int.Parse(genreAsString);
            newContent.TypeOfGenre = (GenreType)genreAsInt;

            //verify the update worked
            bool wasUpdated = _contentRepo.UpdateExistingContent(oldTitle, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Content successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update content.");
            }
        }

        //delete existing content
        private void DeleteExistingContent()
        {

            DisplayAllContent();

            //get the title they want to remove
            Console.WriteLine("\nEnter the title of the content you'd like you remove:");

            string input = Console.ReadLine();

            //call the delete method
            bool wasDeleted = _contentRepo.RemoveContentFromList(input);

            //if the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("the content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("the content could not be deleted.");
            }
            //otherwise state it could not be deleted
        }

        //See method
        private void SeedContentList()
        {
            StreamingContent sharknado = new StreamingContent("Sharknado", "Tornadoes, but with Sharks.", "TV-14", 3.3, true, GenreType.Action);
            StreamingContent theRoom = new StreamingContent("The Room", "Banker's life gets turned upside down.", "R", 3.7, false, GenreType.Drama);
            StreamingContent rubber = new StreamingContent("Rubber", "Car tire comes to life and goes on killing spree.", "R", 5.8, false, GenreType.Documentary);

            _contentRepo.AddContentToList(sharknado);
            _contentRepo.AddContentToList(theRoom);
            _contentRepo.AddContentToList(rubber);
        }
    }
}