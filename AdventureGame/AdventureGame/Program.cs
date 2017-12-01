using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AdventureGame
{
    class Program
    {
        private static AdventureGameModel _gameModel;
        private static string _saveFile;

        static void Main(string[] args)
        {
            if (args != null & args.Length > 0)
            {
                _saveFile = args[0];
                _gameModel = ReadFromFile();
            }
            else
            {
                _gameModel = ReadFromFile();
            }

            while (true)
            {
                DescribeRoom();
                Console.Write("Hva vil du gjøre? (HJELP=Vis hjelpetekst) ");
                var command = Console.ReadLine()?.ToLower() ?? string.Empty;
                if (command == "hjelp") ShowHelpText();
                else if (command == "n" || command == "s"
                    || command == "ø" || command == "v") Go(command);
                else if (command.StartsWith("ta")) Take(command);
                else if (command.StartsWith("slipp")) Drop(command);
                else if (command.StartsWith("låsopp")) Unlock(command);
                else if (command == "exit") Exit();
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ukjent kommando " + command);
                }
            }
        }

        private static void DescribeRoom()
        {
            var room = GetCurrentRoom();
            Console.WriteLine(Environment.NewLine + room.Text);
            ShowInventory(room.Inventory, "Følgende finnes i rommet: ");
            ShowInventory(_gameModel.Player.Inventory, "Du har følgende med deg: ");
        }

        private static void ShowInventory(AdventureGameModelRoomInventory inventory, string text)
        {
            var roomItems = inventory.Item;
            if (roomItems == null || roomItems.Length <= 0) return;
            Console.WriteLine(text);
            foreach (var item in roomItems)
            {
                Console.WriteLine(" - " + item.Color + " nøkkel");
            }
        }

        private static void ShowInventory(AdventureGameModelPlayerInventory inventory, string text)
        {
            var playerItems = inventory.Item;
            if (playerItems == null || playerItems.Length <= 0) return;
            Console.WriteLine(text);
            foreach (var item in playerItems)
            {
                Console.WriteLine(" - " + item.Color + " nøkkel");
            }
        }

        private static AdventureGameModelRoom GetCurrentRoom()
        {
            var playerRoomId = _gameModel.Player.Room;
            var room = _gameModel.Rooms.First(r => r.Id == playerRoomId);
            return room;
        }

        private static void Go(string command)
        {
            // forventer n, s, e eller w
            var room = GetCurrentRoom();
            AdventureGameModelRoomDoor door = null;
            string nextRoom = null;
            if (command == "n")
            {
                door = room.Doors.FirstOrDefault(d => d.North != null);
                nextRoom = door?.North;
            }
            else if (command == "s")
            {
                door = room.Doors.FirstOrDefault(d => d.South != null);
                nextRoom = door?.South;
            }
            else if (command == "v")
            {
                door = room.Doors.FirstOrDefault(d => d.West != null);
                nextRoom = door?.West;
            }
            else if (command == "ø")
            {
                door = room.Doors.FirstOrDefault(d => d.East != null);
                nextRoom = door?.East;

            }

            Console.Clear();
            if (door == null)
            {
                Console.WriteLine("Det er ikke noen dør i den retningen.");
                return;
            }
            if (door.IsOpen)
            {
                Console.WriteLine("Går gjennom døra.");
                if (nextRoom == "FINISH")
                {
                    GameFinished();
                }
                _gameModel.Player.Room = nextRoom;
            }
            else
            {
                Console.WriteLine("Du ser en " + door.Color + " dør som er låst.");
            }
        }

        private static void GameFinished()
        {
            Console.Clear();
            Console.WriteLine("Gratulerer, du har fullført spillet!");
            Environment.Exit(0);
        }

        private static void Take(string command)
        {
            var color = command.Split(' ')[1];
            var room = GetCurrentRoom();
            var roomItems = room.Inventory.Item;
            if (roomItems == null || roomItems.Length == 0) return;
            var item = roomItems.FirstOrDefault(i => i.Color == color);
            Console.Clear();
            if (item == null)
            {
                Console.WriteLine(command + " finnes ikke i rommet.");
                return;
            }
            _gameModel.Player.Inventory.Item = AddKey(item);
            var list = new List<AdventureGameModelRoomInventoryKey>(room.Inventory.Item);
            list.Remove(item);
            room.Inventory.Item = list.ToArray();

        }

        private static AdventureGameModelPlayerInventoryKey[] AddKey(AdventureGameModelRoomInventoryKey item)
        {
            var keys = new List<AdventureGameModelPlayerInventoryKey>();
            var existingItems = _gameModel.Player.Inventory.Item;
            if (existingItems != null) keys.AddRange(existingItems);
            keys.Add(new AdventureGameModelPlayerInventoryKey() { Color = item.Color });
            var array = keys.ToArray();
            return array;
        }
        
        private static void Drop(string command)
        {
            var color = command.Split(' ')[1];
            var items = _gameModel.Player.Inventory.Item;
            var item = GetItemForDrop(command, items);
            Console.Clear();
            if (item == null)
            {                Console.Clear();
                Console.WriteLine("Du har ingen " + color + " nøkkel");
                return;
            }
            _gameModel.Player.Inventory.RemoveItem(item);
            var room = GetCurrentRoom();
            var newRoomItem = new AdventureGameModelRoomInventoryKey {Color = item.Color};
            room.Inventory.AddItem(newRoomItem);
        }

        private static AdventureGameModelPlayerInventoryKey GetItemForDrop(string command,
            AdventureGameModelPlayerInventoryKey[] items)
        {
            if (items == null)
            {
                Console.Clear();
                Console.WriteLine("Du har ingenting!");
                return null;
            }
            var color = command.Split(' ')[1];
            var item = items.FirstOrDefault(i => i.Color == color);
            if (item == null)
            {
                Console.Clear();
                Console.WriteLine("Du har ikke " + color + " nøkkel. ");
            }
            return item;
        }

        private static void Unlock(string command)
        {
            var doorColor = command.Split(' ' )[1];
            var keys = _gameModel.Player.Inventory.Item;
            var hasCorrectKey = keys != null && keys.Any(k=>k.Color==doorColor);
            if (!hasCorrectKey)
            {
                Console.Clear();
                Console.WriteLine("Du mangler " + doorColor + " nøkkel.");
                return;
            }
            var room = GetCurrentRoom();
            var door = room.Doors.FirstOrDefault(d => d.Color == doorColor);
            if (door == null)
            {
                Console.Clear();
                Console.WriteLine("Det er ingen " + doorColor + " dør å låse opp i dette rommet.");
                return;
            }
            var destinationRoomId = door.East ?? door.North ?? door.West ?? door.South;
            var destinationRoom = _gameModel.Rooms.FirstOrDefault(r=>r.Id== destinationRoomId);
            if (destinationRoom != null)
            {
                var matchingDoor = destinationRoom.Doors.First(d => d.Color == doorColor);
                matchingDoor.IsOpen = true;
            }
            door.IsOpen = true;
            Console.Clear();
            Console.WriteLine( doorColor + " dør er nå åpen!");
        }

        private static void Exit()
        {
            SaveToFile();
            Environment.Exit(0);
        }

        private static AdventureGameModel ReadFromFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(AdventureGameModel));
            var fileName = _saveFile ?? "InitialGameSetup.xml";
            using (var stream = File.OpenRead(fileName))
            {
                return (AdventureGameModel)xmlSerializer.Deserialize(stream);
            }
        }

        private static void SaveToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(AdventureGameModel));
            var fileName = _saveFile;
            var count = 1;
            while (fileName == null)
            {
                var candidateFileName = "adv" + count + ".dat";
                if (!File.Exists(candidateFileName)) fileName = candidateFileName;
                count++;
            }

            using (var stream = File.OpenWrite(fileName))
            {
                xmlSerializer.Serialize(stream, _gameModel);
            }

            Console.Clear();
            Console.WriteLine("Lagret spillet: " + fileName);
        }

        private static void ShowHelpText()
        {
            const string text =
              @"VIS           = Vis teksten til rommet - og hva som er i det. 
                TA <ting>     = Ta noe som er i rommet.
                SLIPP <ting>  = Legge fra seg
                N,S,Ø,V       = Gå i angitt retning 
                LÅSOPP <door> = Låse opp dør - og åpne
                EXIT          = Lagrer gjeldende situasjon ny fil, skriver ut 
                                filnavn og avslutter.

                Start programmet med navnet på en save-fil som kommandolinjeparameter
                og du fortsetter der du slapp.";
            Console.Clear();
            Console.WriteLine(text);
        }
    }
}
