using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BilhavkWeb.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category() { Name="Inaktif", Info="inaktif" },
                new Category() { Name="Başlangıç", Info="baslangic", Pic="../../Img/baslangic.jpg" },
                new Category() { Name="KulüpPilotu", Info="kuluppilotu", Pic="../../Img/kulupPilotu.jpg" },
                new Category() { Name="Mezun", Info="mezun", Pic="../../Img/mezun.jpg" }
            };
            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            List<User> users = new List<User>()
            {
                new User() { NickName="Admin", Name="Admin", Surname="Bilhavk", Info="admin", Password="mindA", CategoryId=1, BirthDate=DateTime.Now },
            };
            foreach (var item in users)
            {
                context.Users.Add(item);
            }
            context.SaveChanges();

            List<Day> days = new List<Day>()
            {
                new Day() { Name="Cumartesi", Date=DateTime.Now },
                new Day() { Name="Pazar", Date=DateTime.Now }
            };
            foreach (var item in days)
            {
                context.Days.Add(item);
            }
            context.SaveChanges();

            List<Participant> participants = new List<Participant>()
            {
                new Participant() { UserId = 1, DayId = 1 },
            };
            foreach (var item in participants)
            {
                context.Participants.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}