using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using BAL;
using DAL;

namespace node_net
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MyService
    {
        [OperationContract]
        [WebGet()]
        public string GetCustomer(string input)
        {
            CustomerBAL _Cust = new CustomerBAL();
            try
            {
                var customers = _Cust.Load();
                var secondList = customers.Concat(new[] { new Customer() { ID = customers.Count() + 1, Name = input } });
                string json = new JavaScriptSerializer().Serialize(secondList);
                
                return json;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        //[OperationContract]
        //[WebPost]
        //public string SaveCustomer(string input)
        //{

        //}

    }
}
