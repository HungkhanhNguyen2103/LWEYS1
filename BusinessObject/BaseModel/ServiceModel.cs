using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public string? ServicePackage { get; set; }
        public ServicePackageEnum ServicePackageEnum { get; set; }
        public string? ServiceType { get; set; }
        public ServiceType ServiceTypeEnum { get; set; }
    }
}
