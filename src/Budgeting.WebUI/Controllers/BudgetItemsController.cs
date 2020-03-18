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
        public async Task<ActionResult> DetailsAsync(int id)
        {
            try
            {
                var request = new GetBudgetItemsQuery()
                {
                    Id = id
                };

                var budgetItem = await Mediator.Send(request);

                return View(budgetItem.FirstOrDefault());
            }
            catch
            {
                return View();
            }
        }

        // GET: BudgetItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            try
            {
                var request = new CreateBudgetItemCommand()
                {
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Amount = decimal.Parse(collection["Amount"].ToString()),
                    Frequency = collection["Frequency"],
                    Type = collection["Type"],
                    StartDate = DateTime.Parse(collection["StartDate"]),
                    EndDate = DateTime.Parse(collection["EndDate"])
                };

                await Mediator.Send(request);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BudgetItems/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            try
            {
                var request = new GetBudgetItemsQuery()
                {
                    Id = id
                };

                var budgetItem = await Mediator.Send(request);

                return View(budgetItem.FirstOrDefault());
            }
            catch
            {
                return View();
            }
        }

        // POST: BudgetItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, IFormCollection collection)
        {
            try
            {
                var request = new UpdateBudgetItemCommand()
                {
                    Id = id,
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Amount = decimal.Parse(collection["Amount"].ToString()),
                    Frequency = collection["Frequency"],
                    Type = collection["Type"],
                    StartDate = DateTime.Parse(collection["StartDate"]),
                    EndDate = DateTime.Parse(collection["EndDate"])
                };

                await Mediator.Send(request);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BudgetItems/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var request = new GetBudgetItemsQuery()
                {
                    Id = id
                };

                var budgetItem = await Mediator.Send(request);

                return View(budgetItem.FirstOrDefault());
            }
            catch
            {
                return View();
            }
        }

        // POST: BudgetItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                var request = new DeleteBudgetItemCommand()
                {
                    Id = id
                };

                await Mediator.Send(request);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}