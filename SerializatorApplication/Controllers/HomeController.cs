using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using SerializatorApplication.Characters;
using SerializatorApplication.CustomServices;
using SerializatorApplication.Interfaces;
using SerializatorApplication.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace SerializatorApplication.Controllers
{
    public class Data
    {
        public List<Berserker> berserkers = new List<Berserker>();
        public List<SwordMan> swordMen = new List<SwordMan>();
        public List<Tank> tanks = new List<Tank>();
        public List<Mage> mages = new List<Mage>();
        public List<FireWizard> fireWizards = new List<FireWizard>();
        public List<IceWizard> iceWizards = new List<IceWizard>();
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Human> characters = new List<Human>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(characters);
        }
        
        //Create Characters Section Starts Here
        public IActionResult CreateCharacter()
        {
            return View();
        }
        public IActionResult CreateBerserker()
        {
            var berserker = new Berserker();
            return View(berserker);
        }
        public IActionResult AddBerserker(Berserker berserker)
        {
            characters.Add(berserker);
            return RedirectToAction("Index");
        }
        public IActionResult CreateFireWizard()
        {
            var fireWizard = new FireWizard();
            return View(fireWizard);
        }
        public IActionResult AddFireWizard(FireWizard wizard)
        {
            characters.Add(wizard);
            return RedirectToAction("Index");
        }
        public IActionResult CreateHuman()
        {
            var human = new Human();
            return View(human);
        }
        public IActionResult AddHuman(Human human)
        {
            characters.Add(human);
            return RedirectToAction("Index");
        }
        public IActionResult CreateIceWizard()
        {
            var iceWizard = new IceWizard();
            return View(iceWizard);
        }
        public IActionResult AddIceWizard(IceWizard wizard)
        {
            characters.Add(wizard);
            return RedirectToAction("Index");
        }
        public IActionResult CreateMage()
        {
            var mage = new Mage();
            return View(mage);
        }
        public IActionResult AddMage(Mage mage)
        {
            characters.Add(mage);
            return RedirectToAction("Index");
        }
        public IActionResult CreateSwordMan()
        {
            var swordMan = new SwordMan();
            return View(swordMan);
        }
        public IActionResult AddSwordMan(SwordMan swordMan)
        {
            characters.Add(swordMan);
            return RedirectToAction("Index");
        }
        public IActionResult CreateTank()
        {
            var tank = new Tank();
            return View(tank);
        }
        public IActionResult AddTank(Tank tank)
        {
            characters.Add(tank);
            return RedirectToAction("Index");
        }

        //Create Characters Section Ends Here

        //Create Info Section Starts Here
        public IActionResult ChangeCharacterInfo(int index)
        {
            var character = characters[index];
            return RedirectToAction($"Change{character.GetType().Name}", new {index = index});
        }
        public IActionResult ChangeBerserker(int index)
        {
            return View(characters[index]);
        }
        public IActionResult SaveBerserkerChanges(Berserker character, int index)
        {
            characters[index] = character;
            return RedirectToAction("Index");
        }
        public IActionResult ChangeFireWizard(int index)
        {
            return View(characters[index]);
        }
        public IActionResult SaveFireWizardChanges(FireWizard character, int index)
        {
            characters[index] = character;
            return RedirectToAction("Index");
        }
        public IActionResult ChangeIceWizard(int index)
        {
            return View(characters[index]);
        }
        public IActionResult SaveIceWizardChanges(IceWizard character, int index)
        {
            characters[index] = character;
            return RedirectToAction("Index");
        }
        public IActionResult ChangeMage(int index)
        {
            return View(characters[index]);
        }
        public IActionResult SaveMageChanges(Mage character, int index)
        {
            characters[index] = character;
            return RedirectToAction("Index");
        }
        public IActionResult ChangeSwordMan(int index)
        {
            return View(characters[index]);
        }
        public IActionResult SaveSwordManChanges(SwordMan character, int index)
        {
            characters[index] = character;
            return RedirectToAction("Index");
        }
        public IActionResult ChangeTank(int index)
        {
            return View(characters[index]);
        }
        public IActionResult SaveTankChanges(Tank character, int index)
        {
            characters[index] = character;
            return RedirectToAction("Index");
        }

        //Create Info Section Ends Here

        public IActionResult DeleteCharacter(int index)
        {
            characters.RemoveAt(index);
            return RedirectToAction("Index");
        }

        public IActionResult Serialize()
        {
            //var data = new Data();
            //foreach (var character in characters)
            //{
            //    var characterClass = character.GetType().Name;
            //    if (characterClass == "Berserker")
            //        data.berserkers.Add((Berserker)character);
            //    if (characterClass == "SwordMan")
            //        data.swordMen.Add((SwordMan)character);
            //    if (characterClass == "Tank")
            //        data.tanks.Add((Tank)character);
            //    if (characterClass == "Mage")
            //        data.mages.Add((Mage)character);
            //    if (characterClass == "FireWizard")
            //        data.fireWizards.Add((FireWizard)character);
            //    if (characterClass == "IceWizard")
            //        data.iceWizards.Add((IceWizard)character);
            //}

            //using (MemoryStream ms = new MemoryStream())
            //using (BsonDataWriter datawriter = new BsonDataWriter(ms))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(datawriter, data);
            //    var str = Convert.ToBase64String(ms.ToArray());

            //    using (StreamWriter writetext = new StreamWriter("BsonData.txt"))
            //    {
            //        writetext.Write(str);
            //    }
            //}
            //return RedirectToAction("Index");
            int charactersCounter = 1;
            foreach (var character in characters)
            {
                CustomSerializerContainer customSerializerContainer = new CustomSerializerContainer($"CharactersData/BsonCharacterData{charactersCounter}.txt");
                customSerializerContainer.CustomSerialize(character.GetType(), character);
                charactersCounter++;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Deserialize()
        {
            //string str = string.Empty;
            //using (StreamReader readtext = new StreamReader("BsonData.txt"))
            //{
            //    str = readtext.ReadLine();
            //}

            //byte[] data = Convert.FromBase64String(str);

            //using (MemoryStream ms = new MemoryStream(data))
            //using (BsonDataReader reader = new BsonDataReader(ms))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    var info = serializer.Deserialize<Data>(reader);

            //    characters = new List<Human>();
            //    foreach (var character in info.berserkers)
            //        characters.Add(character);
            //    foreach (var character in info.swordMen)
            //        characters.Add(character);
            //    foreach (var character in info.tanks)
            //        characters.Add(character);
            //    foreach (var character in info.mages)
            //        characters.Add(character);
            //    foreach (var character in info.fireWizards)
            //        characters.Add(character);
            //    foreach (var character in info.iceWizards)
            //        characters.Add(character);
            //}

            //return RedirectToAction("Index");

            string[] allCharacters = Directory.GetFiles("CharactersData");
            characters = new List<Human>();
            foreach (string character in allCharacters)
            {
                CustomSerializerContainer customSerializerContainer = new CustomSerializerContainer($"{character}");
                var person = customSerializerContainer.CustomDeserialize();
                characters.Add((Human)person);
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}