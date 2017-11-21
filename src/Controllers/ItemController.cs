namespace todo.Controllers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Models;

    public class ItemController : Controller
    {
        const string Configuration = "DocumentDB";  //DocumentDB or MongoDB

        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            IRepository<Item> rep = CreateRepository();           
           
            var items = await rep.GetItemsAsync(d => !d.Completed);
            return View(items);
        }

        private IRepository<Item> CreateRepository()
        {
            if (Configuration == "DocumentDB")
                return new DocumentDBRepository<Item>();
            else
                return null;
        }

#pragma warning disable 1998
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }
#pragma warning restore 1998

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Name,Description,Completed,Category")] Item item)
        {
            if (ModelState.IsValid)
            {
                IRepository<Item> rep = CreateRepository();
                await rep.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,Name,Description,Completed,Category")] Item item)
        {
            if (ModelState.IsValid)
            {
                IRepository<Item> rep = CreateRepository();
                await rep.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IRepository<Item> rep = CreateRepository();
            Item item = await rep.GetItemAsync(id, category);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IRepository<Item> rep = CreateRepository();
            Item item = await rep.GetItemAsync(id, category);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Id, Category")] string id, string category)
        {
            IRepository<Item> rep = CreateRepository();
            await rep.DeleteItemAsync(id, category);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id, string category)
        {
            IRepository<Item> rep = CreateRepository();
            Item item = await rep.GetItemAsync(id, category);
            return View(item);
        }
    }
}