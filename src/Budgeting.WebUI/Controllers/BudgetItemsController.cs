using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgeting.Application.Features.BudgetItems;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budgeting.WebUI.Controllers
{
    public class BudgetItemsController : BaseController
    {
        public BudgetItemsController(IMediator mediator) : base(mediator) { }

        // GET: BudgetItems
        public async Task<ActionResult> IndexAsync()
        {
            var budgetItems = await Mediator.Send(new GetBudgetItemsQuery());
            return View(budgetItems);
        }

        // GET: BudgetItems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BudgetItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: BudgetItems/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BudgetItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: BudgetItems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BudgetItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}