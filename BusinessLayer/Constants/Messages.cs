using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product Added";
        public static string ProductNameInvalid = "Ad kecersiz";
        public static string MaintenanceTime = "Baxim vaxti";
        public static string ProductCountOfCategory = "1 Kategoriyada 10dan cox mehsul ola bilmez";
        public static string ProductNameAlreadyExist = "Bu adda product var";
        public static string CategoryCount = "Kateqoriya sayi 15den boyukdur";

        public static string CategoryAded = "Kateqoriya Əlavə olundu.";
        public static string CategoryDeleted = "Kateqoriya silindi.";
    }
}
