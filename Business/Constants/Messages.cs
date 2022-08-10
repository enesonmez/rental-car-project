using System;
using System.Runtime.Serialization;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string CarDailyPriceValid = "Araba günlük fiyatı 0'dan büyük olmalıdır";
        public static string CarNameValid = "Araba ismi en az 2 karakter olmalıdır";
        public static string RentalReturnDateValid = "Araba müşteride gözüküyor";
        public static string ImageDeleted = "Resim silindi";
        public static string ImageUpdated = "Resim güncellendi";
        public static string CarImageLimit = "Araba için maksimum resim limitine ulaşılmıştır";
        public static string UploadImage = "Resim yüklendi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccesfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı sistemde bulunmaktadır";
        public static string UserRegistered = "Kayıt başarılı";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}