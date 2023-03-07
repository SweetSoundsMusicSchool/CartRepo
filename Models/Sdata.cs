using System.ComponentModel.Design;
using System;
namespace Capstone1.Models

{
    public class Sdata
    {
        public static void LoadData(IApplicationBuilder application)
        {
            SweetDBContext context = application.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<SweetDBContext>();

            context.Services.AddRange(
                new Service
                {
                    ServiceName = "Private Piano Lessons",
                    Description = "1 on 1 private lessons for 30 minutes",
                    Category = "5 to 12 years old",
                    Price = 110

                },
                new Service
                {
                    ServiceName = "Private Ukulele Lessons",
                    Description = "1 on 1 private lessons for 30 minutes",
                    Category = "5 to 12 years old",
                    Price = 110

                },

                new Service
                {
                    ServiceName = "Preschool Piano Lessons",
                    Description = "1 on 1 private lessons for 30 minutes",
                    Category = "2 to 4 years old",
                    Price = 110
                },

                new Service
                {
                    ServiceName = "Early Music Classes",
                    Description = "Sing, dance, and play instruments in a group setting ",
                    Category = "0 to 4 years old",
                    Price = 110
                }
                );

            context.SaveChanges();


            }
    }
}
