using ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService.Service
{
    [ServiceContract]
    public interface INorthwindService
    {
        [OperationContract]
        List<string> GetProducts();

        [OperationContract]
        ProductData GetProductData(string pName);

        [OperationContract]
        void UpdateProducts(ProductData pData);
    }
}
