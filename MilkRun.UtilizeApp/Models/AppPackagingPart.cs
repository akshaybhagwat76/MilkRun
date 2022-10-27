using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilkRun.UtilizeApp.Models
{
    [Table("Tbl_Packaging_Part")]
    public class AppPackagingPart
    {
        [Key]
        public string Part_No { get; set; }
        public string APROS_Part_No { get; set; }
        public string Part_Name { get; set; }

        public string Supplier_Code { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string Packaging_Type { get; set; }
        public Nullable<decimal> SNP { get; set; }
        public Nullable<decimal> Packaging_WIDTH { get; set; }
        public Nullable<decimal> Packaging_LENGTH { get; set; }
        public Nullable<decimal> Packaging_HEIGHT { get; set; }
        public Nullable<decimal> Packaging_WEIGHT { get; set; }
        public Nullable<decimal> ITEM_WEIGHT { get; set; }
        public string Packaging_Pallet_Type { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
    }
}
