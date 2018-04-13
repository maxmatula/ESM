namespace ESM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ESM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ESMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ESMDbContext";
        }

        protected override void Seed(ESMDbContext context)
        {
          


            context.Companies.AddOrUpdate(x => x.Id,

                new Company { Id = Guid.Parse("a19d451a-0956-4b56-9a38-4e62b244678d"), Name = "MM&GW Solutions", Description = "Future best software company ever :)", Logo = "/Images/esm200x200.jpg" },
                new Company { Id = Guid.Parse("c266df8c-8f91-4a5c-9595-1ec02ef72ef6"), Name = "Assecorp Solutions", Description = "MM&GW Solutions biggest competitor", Logo = "https://irp-cdn.multiscreensite.com/61d13f83/dms3rep/multi/mobile/solutions-icon-200x200.png" },
                new Company { Id = Guid.Parse("2c4243a5-9133-4103-80a8-c9ad8bcd2947"), Name = "Cyberdyne Systems", Description = "Some kind of robots and cybernetics... Boring!", Logo = "https://botw-pd.s3.amazonaws.com/styles/logo-thumbnail/s3/0022/0350/brand.gif?itok=QaeqJuLk" }
                );

            //    context.userCompanyReferences.AddOrUpdate(x => x.Id,

            //        new UserCompanyReference { UserId = "c199460d-9fe2-4ea6-8e29-9fea8e2efe79", CompanyId = "2c4243a5-9133-4103-80a8-c9ad8bcd2947" },
            //        new UserCompanyReference { UserId = "b45998c2-6732-4c8a-a02c-ba0dce5215fb", CompanyId = "a19d451a-0956-4b56-9a38-4e62b244678d" },
            //        new UserCompanyReference { UserId = "37edaefb-429c-4642-8915-51c0e451c9ed", CompanyId = "a19d451a-0956-4b56-9a38-4e62b244678d" },
            //        new UserCompanyReference { UserId = "c199460d-9fe2-4ea6-8e29-9fea8e2efe79", CompanyId = "c266df8c-8f91-4a5c-9595-1ec02ef72ef6" }
            //    );


            context.Employees.AddOrUpdate(x => x.Id,

               new Employee { Name = "Piotr", Surname = "Makowski", Title = ".Net Specialist", Picture = "http://placehold.it/200x200", CompanyId = "a19d451a-0956-4b56-9a38-4e62b244678d" },
               new Employee { Name = "Jakub", Surname = "Jan", Title = ".Net Specialist", Picture = "http://placehold.it/200x200", CompanyId = "a19d451a-0956-4b56-9a38-4e62b244678d" },
               new Employee { Name = "Maciej", Surname = "Szthur", Title = ".Net Specialist", Picture = "http://placehold.it/200x200", CompanyId = "a19d451a-0956-4b56-9a38-4e62b244678d" },
               new Employee { Name = "Katarzyna", Surname = "Zaj¹c", Title = "Manager", Picture = "http://placehold.it/200x200", CompanyId = "a19d451a-0956-4b56-9a38-4e62b244678d" },
               new Employee { Name = "Zofia", Surname = "Ko³aczka", Title = "Accountant", Picture = "http://placehold.it/200x200", CompanyId = "c266df8c-8f91-4a5c-9595-1ec02ef72ef6" },
               new Employee { Name = "W³adys³aw", Surname = "Kupierz", Title = ".Net Specialist", Picture = "http://placehold.it/200x200", CompanyId = "c266df8c-8f91-4a5c-9595-1ec02ef72ef6" },
               new Employee { Name = "Magdalena", Surname = "Sabkowska", Title = "C# junior", Picture = "http://placehold.it/200x200", CompanyId = "c266df8c-8f91-4a5c-9595-1ec02ef72ef6" },
               new Employee { Name = "S³awomir", Surname = "Murias", Title = "C# Specialist", Picture = "http://placehold.it/200x200", CompanyId = "c266df8c-8f91-4a5c-9595-1ec02ef72ef6" },
               new Employee { Name = "Zbyszek", Surname = "Sok", Title = ".Net Specialist", Picture = "http://placehold.it/200x200", CompanyId = "c266df8c-8f91-4a5c-9595-1ec02ef72ef6" },
               new Employee { Name = "Maksymilian", Surname = "Matu³a", Title = "CEO", Picture = "https://media.licdn.com/dms/image/C4D03AQFTVYTgwGgVHg/profile-displayphoto-shrink_200_200/0?e=1528408800&v=beta&t=aWb6w4ngiaKzIC3_tCywU7YSR7OiYgUA9Yksiox0gCY", CompanyId = "a19d451a-0956-4b56-9a38-4e62b244678d" },
               new Employee { Name = "Grzegorz", Surname = "Wójcik", Title = "CEO", Picture = "https://scontent-waw1-1.xx.fbcdn.net/v/t1.0-1/p160x160/16387855_1326920610697782_6985400701682627839_n.jpg?_nc_cat=0&oh=4d3d5a8f04d0d259cfea5734559567db&oe=5B309557", CompanyId = "a19d451a-0956-4b56-9a38-4e62b244678d" }

           );



        }
    }
}
