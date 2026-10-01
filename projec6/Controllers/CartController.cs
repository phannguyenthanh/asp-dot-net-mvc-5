using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project5.Models;
using projec6.Cart;
using System.Web.Script.Serialization;



namespace projec6.Controllers
{
    
    public class CartController : Controller
    {
        footwear_db db = new footwear_db();
        private const string CartSession = "CartSession";

        // GET: Cart
        public ActionResult ListCart()
        {
            var cart = Session[CartSession];
            var list = new List<ItemCart>();
            if (cart!= null)
            {
               list = (List<ItemCart>)cart;
            }
            return View(list);
        }
        public ActionResult Paymen()
        {
            var cart = Session[CartSession];
            var list = new List<ItemCart>();
            if (cart != null)
            {
                list = (List<ItemCart>)cart;
            }
            return View(list);
        }
        public ActionResult AddCart(int IdPro, int Quantity)
        {
            var product = db.Products.Find(IdPro);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<ItemCart>)cart;
                if (list.Exists(x => x.Product.Id == IdPro))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.Id == IdPro)
                        {
                            item.Quantity += Quantity;

                        }
                       
                    }
                }
                else
                {
                    var item = new ItemCart();
                    item.Product = product;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;

            }
            else
            {
                var item = new ItemCart();
                item.Product = product;
                item.Quantity = Quantity;
                var list = new List<ItemCart>();
                list.Add(item);
                Session[CartSession] = list;

            }
            return  RedirectToAction("ListCart");
        }
        public PartialViewResult Form_pay()
        {
            ViewBag.IdPay = new SelectList(db.Pays, "Id", "Name");
          
            return PartialView();
        }
        [HttpPost]
        public ActionResult Check_form_pay(string First_name , string Last_name ,string Email , string Address , string Phone ,int IdPay)
        {
            var order = new Order();
            var transaction = new Transaction();
            if (ModelState.IsValid)
            {
                transaction.IdPay = IdPay;
                transaction.First_name = First_name.ToString();
                transaction.Last_name = Last_name.ToString();
                transaction.Email = Email.ToString();
                transaction.Address = Address.ToString();
                transaction.Phone = Phone.ToString();
                transaction.Createtime = DateTime.Now;
                db.Transactions.Add(transaction);
                db.SaveChanges();


                var sessioncart = Session[CartSession];
                var list = new List<ItemCart>();
                list = (List<ItemCart>)sessioncart;
                foreach (var i in list)
                {
                    order.IdProduct = i.Product.Id;
                 
                    order.IdTransaction = db.Transactions.Where(f=>f.First_name.Equals(First_name) && f.Last_name.Equals(Last_name) && f.Phone.Equals(Phone)).FirstOrDefault().Id;

                    order.Price = i.Product.Price;
                    order.Sale = i.Product.Sale;
                    order.Quantity = i.Quantity;
                    order.Createtime = DateTime.Now;
                    db.Orders.Add(order);
                    db.SaveChanges();

                }
                Session[CartSession] = null;
                return RedirectToAction("Index","Home");
            }

            ViewBag.IdPay = new SelectList(db.Pays, "Id", "Name", transaction.IdPay);
            return View("Paymen");
        }
        //public ActionResult Create([Bind(Include = "Id,IdUser,IdPay,First_name,Last_name,Email,Phone,Security,Createtime")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Transactions.Add(transaction);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IdPay = new SelectList(db.Pays, "Id", "Name", transaction.IdPay);
        //    return View(transaction);
        //}
        public JsonResult UpdateAll(string CartModel)
        {
            var cart = new JavaScriptSerializer().Deserialize<List<ItemCart>>(CartModel);
            var sessionCart = (List<ItemCart>)Session[CartSession];
            foreach (var i in sessionCart)
            {
                var jsonItem = cart.SingleOrDefault(x=>x.Product.Id == i.Product.Id);
                if (jsonItem!= null)
                {
                    i.Quantity = jsonItem.Quantity;

                }

            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            
            Session[CartSession] = null;
            return Json(new
            {

                status = true

            });
        }
        public JsonResult DeleteId(int id)
        {
            var sessionCart = (List<ItemCart>)Session[CartSession];
            sessionCart.RemoveAll(x=>x.Product.Id == id);
            Session[CartSession] = sessionCart;
            return Json(new {status = true});
        }
    }
}