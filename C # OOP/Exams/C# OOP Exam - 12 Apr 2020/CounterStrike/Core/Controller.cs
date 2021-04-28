using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository gunRepository;
        private PlayerRepository playerRepository;
        private IMap map;
        public Controller()
        {
            gunRepository = new GunRepository();
            playerRepository = new PlayerRepository();
            map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.gunRepository.Add(gun);
            return String.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
            //Adds a Gun and adds it to the GunRepository.Valid types are: "Pistol" and "Rifle".
            //If the Gun type is invalid, you have to throw an ArgumentException with the following message:
            //•	"Invalid gun type."
            //If the Gun is added successfully, the method should return the following string:
            //•	"Successfully added gun {gunName}."
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = null;
            if (type == "Terrorist")
            {
                IGun gun = this.gunRepository.FindByName(gunName);
                if (gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                IGun gun = this.gunRepository.FindByName(gunName);
                if (gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            this.playerRepository.Add(player);
            return String.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
            //Creates a Player of the given type and adds it to the PlayerRepository.
            //Valid types are: "Terrorist" and "CounterTerrorist".
            //If the gun is not found throw ArgumentException with message:
            //•	"Gun cannot be found!"
            //If the player type is invalid, throw an ArgumentException with message:
            //•	"Invalid player type!"
            //The method should return the following string if the operation is successful:
            //•	"Successfully added player {playerUsername}."

        }
        public string StartGame()
        {
            return this.map.Start(this.playerRepository.Models.ToList());
        }

        public string Report()
        {
            var sortedPLayers = this.playerRepository.Models.OrderBy(p => p.GetType().Name)
                                                          .ThenByDescending(p => p.Health)
                                                          .ThenBy(p => p.Username).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var player in sortedPLayers)
            {
                sb.AppendLine($"{player.GetType().Name}: {player.Username}")
                    .AppendLine($"--Health: {player.Health}")
                    .AppendLine($"--Armor: {player.Armor}")
                    .AppendLine($"--Gun: {player.Gun.Name}");
            }
            return sb.ToString().TrimEnd();
            //Returns information about each player separated with a new line.
            //Order them by type alphabetically, then by health descending, then by username alphabetically. 
            //You can use the overridden ToString Player method.
            //"{player type}: {player username}");
            //            "--Health: {player health}");
            //            "--Armor: {player armor}");
            //            "--Gun: {player gun name}")

        }

    }
}
