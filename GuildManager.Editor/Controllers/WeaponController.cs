using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Editor.ApiCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuildManager.Editor.Controllers
{
    public class WeaponController : Controller
    {
        // GET: Weapon
        public ActionResult Index()
        {
            return View();
        }

        // GET: Weapon/Details/5
        public ActionResult Details(int id)
        {
            var apiCall = new WeaponApiCall();
            var model = apiCall.GetWeapon(id);
            return View(model);
        }

        // GET: Weapon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weapon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Weapon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Weapon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Weapon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Weapon/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}