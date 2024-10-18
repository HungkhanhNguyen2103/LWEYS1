using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Service
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }
        public ServicePackageEnum ServicePackage { get; set; }
        public ServiceType ServiceType { get; set; }
    }

    public static class ServicePackage
    {
        public static string BasicPackage = "Gói cơ bản";
        public static string StandardPackage = "Gói tiêu chuẩn";
        public static string PremiumPackage = "Gói cao cấp";
    }

    public enum ServicePackageEnum
    {
        BasicPackage = 0,
        StandardPackage = 1,
        PremiumPackage = 2
    }

    public enum ServiceType
    {
        Online = 0,
        Offline = 1,
    }

    public static class ServiceTypeCls
    {
        public static string Online = "Online";
        public static string Offline = "Offline";
    }
}
