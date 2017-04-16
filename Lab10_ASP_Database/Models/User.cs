using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Lab10_ASP_Database
{
    public class User
    {
        public ObjectId Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression("[a-zA-Zа-яА-Я]{1,20}", ErrorMessage = "Только буквы")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression("[a-zA-Zа-яА-Я]{1,20}", ErrorMessage = "Только буквы")]
        public string lastName { get; set; }

        [RegularExpression("[a-zA-Zа-яА-Я]{1,100}", ErrorMessage = "Только буквы")]
        public string city { get; set; }

        public string date { get; set; }
    }
}
