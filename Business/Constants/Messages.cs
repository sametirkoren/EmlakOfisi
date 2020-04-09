using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AdvertAdded = "İlan başarıyla eklendi.";
        public static string AdvertDeleted = "İlan başarıyla silindi.";
        public static string AdvertUpdated = "İlan başarıyla güncellendi.";

        public static string AdminAdded = "Yeni admin başarıyla eklendi.";
        public static string AdminDeleted = "Admin başarıyla silindi.";
        public static string AdminUpdated = "Admin başarıyla güncellendi.";
        public static string AdminNotFound = "Admin bulunamadı.";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı.";
        public static string AlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string Registered = "Başarıyla kaydedildi";
    }
}