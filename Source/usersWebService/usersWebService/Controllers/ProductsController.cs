using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories1;

namespace usersWebService.Controllers
{
    public class ProductsController : Controller
    {
        // private productsEntities pdb = new productsEntities(); used before repo
        private IProductrepository productrepository; //this has been added for use with repos

        public ProductsController() //repo use
        {
            this.productrepository = new ProductRepository(new productsEntities());
        } //repo use end

        // GET: Products
        public ActionResult Index()
        {
            products test1 = new usersWebService.products();
            test1.productname = "Dan's Mum";
            Create(test1);
            return View();
        }

        //GET: Products/Create
        public ActionResult Create()
        {
            var records = productrepository.products;
            ViewBag.user = new SelectList(records, "productID", "productName", "productDescription");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(usersWebService.products pn)
        {
            try
            {

                productrepository.products.Add(pn);
                productrepository.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View(pn);
            }
        }
        //GET: Products/Edit
        public ActionResult Edit(int id)
        {
            products product = productrepository.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // POST: Order/Edit
        [HttpPost]
        public ActionResult Edit(
            [Bind(
                Include =
                    "productID, productName"
                )] products product)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    productrepository.Entry(product).State = EntityState.Modified;
                    productrepository.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.product = new SelectList(productrepository.products, "productID", "productName",
                    product.productid);
                return View(product);
            }
        }
    }
}