using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
  public static  class Messages
    {
        public static string SuccessMessage = " İşlem başarıyla gerçekleştirilmiştir.";
        public static string ErrorMessage = "İşlem başarısız oldu.";
        public static string SuccessDataMessage = " İşlem başarıyla gerçekleştirilmiştir.";
        public static string ErrorDataMessage = " İşlem  başarısız oldu.";
        public static string ImagesAdded = "Resim eklenmiştir";
        public static string FailAddedImageLimit = "Resim sayısı 5 adetten fazla olamaz.";
        public static string CarImageExists = "Resim hali hazırda bulunmaktadır";
        public static string CarImageNotFound = "Resim bulunamadı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı.";
        public static string UserAlreadyExists = "Kullanıcı hali hazırda bulunmakta.";
        public static string userRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
