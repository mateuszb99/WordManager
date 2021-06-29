using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordManager2.Models;

namespace WordManager2.Controllers
{
    public class WordController : Controller
    {

        private static IList<WordModel> words = new List<WordModel>()
        {
            new WordModel(){WordID = 1, Name = "Praca" },
            new WordModel(){WordID = 2, Name = "Praca"},
            new WordModel(){WordID = 3, Name = "Szkoła"},
            new WordModel(){WordID = 4, Name = "Dom"},
            new WordModel(){WordID = 5, Name = "Samochód"},
            new WordModel(){WordID = 6, Name = "Praca"},
            new WordModel(){WordID = 7, Name = "Kot"},
            new WordModel(){WordID = 8, Name = "Pies"},
            new WordModel(){WordID = 9, Name = "Samochód"},
            new WordModel(){WordID = 10, Name = "Ogród"}

        };
        // GET: Word
        public ActionResult Index()
        {

            return View(words);
        }

        // GET: Word/Create
        public ActionResult Create()
        {
            return View(new WordModel());
        }

        // POST: Word/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WordModel wordModel)
        {
            wordModel.WordID = words.Count + 1;
            words.Add(wordModel);
            

                return RedirectToAction(nameof(Index));
           
        }


        // GET: Word/Delete
        public ActionResult Delete(int id)
        {
            return View(words.FirstOrDefault(x => x.WordID == id));
        }

        // POST: Word/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, WordModel wordModel)
        {
            WordModel word = words.FirstOrDefault(x => x.WordID == id);
            words.Remove(word);


            return RedirectToAction(nameof(Index));

        }
        // GET: Word/Unique
        public List<String> Unique(int id)
        {
            List<String> uniqueList = new List<String>();
            foreach (WordModel elem in words)
            {
                Boolean isElemInUniqList = false;
                foreach (String uniqueElem in uniqueList)
                {
                    if (uniqueElem.Equals(elem.Name))
                    {
                        isElemInUniqList = true;
                        break;
                    }
                }
                if (!isElemInUniqList)
                {
                    uniqueList.Add(elem.Name);
                }
            }
            return uniqueList;

        }

        // GET: Word/Occur
        public int Occur(int id)
        {
            WordModel wordModel = words.First(x => x.WordID == id);
            int count = 0;
            foreach (WordModel elem in words)
            {
                if (wordModel.Name.Equals(elem.Name))
                    count++;
            }
            ViewData["Count"] = count;
            ViewBag.TotalCount = count;
            return count;
            
        }

    }
}
