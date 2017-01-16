using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICA6;
using BazzasBazaarExternalServiceProxyWCF;
using DodgeyDealersExternalServiceProxy;
using KhansKwikimartExternalServiceProxy;
using ExternalServiceProxy;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Data.SqlClient;


namespace cache
{
    public class Program
    {

        
        public string ConnectionString { get; set; }

        //This is the connection string
        SqlConnection m_sqlConn = null;
        
        public bool Connect()
        {
            m_sqlConn = new SqlConnection(ConnectionString);

            m_sqlConn.Open();

            return m_sqlConn.State == System.Data.ConnectionState.Open;
        }

        public bool Disconnect()
        {
            m_sqlConn = new SqlConnection(ConnectionString);
            m_sqlConn.Close();

            return m_sqlConn.State == System.Data.ConnectionState.Closed;
        }

        static void Main(string[] args)
        {
            undercutters();
            //bazzas();
            khans();
            doddgy();
        }

        public async static void undercutters()
        {

            ExternalServiceProxy.ServiceProxy proxy = new ExternalServiceProxy.ServiceProxy(new ExternalServiceProxy.ServiceInteraction());
            productsEntities2 db = new productsEntities2();
         
            ExternalServiceProxy.Responses.UndercuttersResponse<IEnumerable<ExternalServiceProxy.DTO.ProductDTO>> products = await proxy.GetAllProducts();
            //Undercutters products

            try
            {
                foreach (ExternalServiceProxy.DTO.ProductDTO p in products.target)
                {
                    var test = new cache.products { productname = p.Name, productid = p.Id, productdescription = p.Description, categoryid = p.CategoryId, categoryname = p.CategoryName, brandid = p.BrandId, minprice = p.Price, maxprice = p.Price };

                    db.products.Add(test);
                    db.SaveChanges();
                }

            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());

            }
        }

        public async static void bazzas()
        {
            productsEntities2 db = new productsEntities2();

            //bazzas
            BazzasBazaarExternalServiceProxyWCF.ServiceProxy proxy2 = new BazzasBazaarExternalServiceProxyWCF.ServiceProxy();
            BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Category[] products6 = await proxy2.getAllCategories();
            await proxy2.getAllCategories();

            int cacheId = 0;
            string cacheName = "";

            foreach (BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Category c in products6)
            {
                cacheId = c.Id;
                cacheName = c.Name;
            }

            BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Product[] products2 = await proxy2.getFilteredProducts(3, "Covers", 0, 100);


            try
            {
                foreach (BazzasBazaarExternalServiceProxyWCF.BazzasBazaarService.Product p in products2)
                {
                    var test = new cache.products { categoryid = p.CategoryId, categoryname = p.CategoryName, minprice = 0, maxprice = 100, productdescription = p.Description, brandid = p.Id };

                    db.products.Add(test);
                    db.SaveChanges();
                }

            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());

            }
        }

        public async static void khans()
        {
            //khansKwikimart
            KhansKwikimartExternalServiceProxy.ServiceProxy proxy4 = new KhansKwikimartExternalServiceProxy.ServiceProxy(new KhansKwikimartExternalServiceProxy.ServiceInteraction());
            KhansKwikimartExternalServiceProxy.Responses.KhansKwikimartResponse<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.RangeDTO>> products4 = await proxy4.GetGiftWrappingByRange();
            KhansKwikimartExternalServiceProxy.Responses.KhansKwikimartResponse<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.TypeDTO>> products5 = await proxy4.GetGiftWrappingByType();
            productsEntities2 db = new productsEntities2();


            for (int i = 0; i < products4.target.ToList().Count; i++)
            {
                KhansKwikimartExternalServiceProxy.DTO.RangeDTO currentrange = products4.target.ToList()[i];
                for (var j = 0; j < products5.target.ToList().Count; j++)
                {
                    KhansKwikimartExternalServiceProxy.DTO.TypeDTO currenttype = products5.target.ToList()[i];

                    KhansKwikimartExternalServiceProxy.Responses.KhansKwikimartResponse<IEnumerable<KhansKwikimartExternalServiceProxy.DTO.ProductDTO>> currentproduct = await proxy4.GetGiftWrapping(currenttype.Id, currentrange.Id, 0, 100, 0, 100);

                    try
                    {
                        foreach (KhansKwikimartExternalServiceProxy.DTO.ProductDTO p in currentproduct.target)
                        {
                            KhansKwikimartExternalServiceProxy.DTO.ProductDTO current = currentproduct.target.ToList()[i];
                            var test = new cache.wrappings { id = current.Id, typeid = current.Id, typename = current.TypeName, rangeid = current.RangeId, rangename = current.RangeName, price = current.Price, size = current.Size };

                            db.wrappings.Add(test);
                            db.SaveChanges();
                        }

                    }

                    catch (Exception e)
                    {

                        Console.WriteLine(e.ToString());

                    }
                }
            }

        }
        

        public async static void doddgy()
        {
            //DodgeyDealers
            DodgeyDealersExternalServiceProxy.ServiceProxy proxy3 = new DodgeyDealersExternalServiceProxy.ServiceProxy(new DodgeyDealersExternalServiceProxy.ServiceInteraction());
            DodgeyDealersExternalServiceProxy.Responses.DodgyDealersServiceResponse<IEnumerable<DodgeyDealersExternalServiceProxy.DTO.ProductDTO>> products3 = await proxy3.GetAllProducts();
            productsEntities2 db = new productsEntities2();


            try
            {
                foreach (DodgeyDealersExternalServiceProxy.DTO.ProductDTO p in products3.target)
                {
                    var test = new cache.products { productname = p.Name, productid = p.Id, productdescription = p.Description, categoryid = p.CategoryId, categoryname = p.CategoryName, brandid = p.BrandId, minprice = p.Price, maxprice = p.Price };

                    db.products.Add(test);
                    db.SaveChanges();
                }

            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());

            }
        }

        
    }
}
