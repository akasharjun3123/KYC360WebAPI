using WebAPIAssignment.Model;

namespace WebAPIAssignment.Database
{
    public static class SampleDataGenerator
    {
        public static void AddSampleData(EntityAPIDbContext dbContext)
        {
            var entities = new List<Entity>
{
    // First Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "USA", AddressLine = "456 Elm Street", City = "Another City" },
                        new Address { Country = "Canada", AddressLine = "789 Maple Avenue", City = "Some City" }
                    },
                    Deceased = false,
                    Gender = "Female",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "Alice", MiddleName = "M.", Surname = "Smith" },
                        new Name { FirstName = "Bob", MiddleName = "L.", Surname = "Johnson" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1990, 5, 15) },
                        new Date { DateType = "Death", DateValue = null }
                    }
                },
                // Second Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "India", AddressLine = "123 MG Road", City = "Mumbai" },
                        new Address { Country = "UK", AddressLine = "456 High Street", City = "London" }
                    },
                    Deceased = true,
                    Gender = "Male",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "Charlie", MiddleName = "R.", Surname = "Brown" },
                        new Name { FirstName = "Daisy", MiddleName = "L.", Surname = "Miller" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1985, 10, 20) },
                        new Date { DateType = "Death", DateValue = new DateTime(2020, 8, 25) }
                    }
                },
                // Third Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "India", AddressLine = "789 XYZ Street", City = "New Delhi" },
                        new Address { Country = "USA", AddressLine = "123 Main Street", City = "Anytown" }
                    },
                    Deceased = false,
                    Gender = "Female",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "Emily", MiddleName = "A.", Surname = "Patel" },
                        new Name { FirstName = "Finn", MiddleName = "B.", Surname = "Singh" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1995, 3, 10) },
                        new Date { DateType = "Death", DateValue = null }
                    }
                },

                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "USA", AddressLine = "123 Oak Street", City = "Smalltown" },
                        new Address { Country = "Canada", AddressLine = "456 Cedar Avenue", City = "Village" }
                    },
                    Deceased = false,
                    Gender = "Male",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "John", MiddleName = "D.", Surname = "Doe" },
                        new Name { FirstName = "Jane", MiddleName = "E.", Surname = "Smith" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1980, 7, 25) },
                        new Date { DateType = "Death", DateValue = null }
                    }
                },
                // Fifth Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "India", AddressLine = "789 MG Road", City = "Bangalore" },
                        new Address { Country = "UK", AddressLine = "123 High Street", City = "Edinburgh" }
                    },
                    Deceased = true,
                    Gender = "Female",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "Emma", MiddleName = "K.", Surname = "Jones" },
                        new Name { FirstName = "William", MiddleName = "J.", Surname = "Brown" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1975, 12, 10) },
                        new Date { DateType = "Death", DateValue = new DateTime(2022, 2, 28) }
                    }
                },
                // Sixth Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "USA", AddressLine = "789 Pine Street", City = "Ruralville" },
                        new Address { Country = "Canada", AddressLine = "456 Birch Avenue", City = "Suburbia" }
                    },
                    Deceased = false,
                    Gender = "Male",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "Michael", MiddleName = "S.", Surname = "Wilson" },
                        new Name { FirstName = "Samantha", MiddleName = "L.", Surname = "Taylor" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1992, 3, 18) },
                        new Date { DateType = "Death", DateValue = null }
                    }
                },
                // Seventh Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "India", AddressLine = "456 ABC Street", City = "Chennai" },
                        new Address { Country = "USA", AddressLine = "789 Elm Street", City = "Metropolis" }
                    },
                    Deceased = true,
                    Gender = "Female",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "Olivia", MiddleName = "R.", Surname = "Garcia" },
                        new Name { FirstName = "Noah", MiddleName = "M.", Surname = "Adams" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1988, 9, 5) },
                        new Date { DateType = "Death", DateValue = new DateTime(2021, 5, 15) }
                    }
                },
                // Eighth Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "USA", AddressLine = "123 Oak Street", City = "Smalltown" },
                        new Address { Country = "Canada", AddressLine = "456 Cedar Avenue", City = "Village" }
                    },
                    Deceased = false,
                    Gender = "Male",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "John", MiddleName = "D.", Surname = "Doe" },
                        new Name { FirstName = "Jane", MiddleName = "E.", Surname = "Smith" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1980, 7, 25) },
                        new Date { DateType = "Death", DateValue = null }
                    }
                },
                // Ninth Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "India", AddressLine = "789 MG Road", City = "Bangalore" },
                        new Address { Country = "UK", AddressLine = "123 High Street", City = "Edinburgh" }
                    },
                    Deceased = true,
                    Gender = "Female",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "Emma", MiddleName = "K.", Surname = "Jones" },
                        new Name { FirstName = "William", MiddleName = "J.", Surname = "Brown" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1975, 12, 10) },
                        new Date { DateType = "Death", DateValue = new DateTime(2022, 2, 28) }
                    }
                },
                // Tenth Entity
                new Entity
                {
                    Addresses = new List<Address>
                    {
                        new Address { Country = "USA", AddressLine = "789 Pine Street", City = "Ruralville" },
                        new Address { Country = "Canada", AddressLine = "456 Birch Avenue", City = "Suburbia" }
                    },
                    Deceased = false,
                    Gender = "Male",
                    Names = new List<Name>
                    {
                        new Name { FirstName = "Michael", MiddleName = "S.", Surname = "Wilson" },
                        new Name { FirstName = "Samantha", MiddleName = "L.", Surname = "Taylor" }
                    },
                    Dates = new List<Date>
                    {
                        new Date { DateType = "Birth", DateValue = new DateTime(1992, 3, 18) },
                        new Date { DateType = "Death", DateValue = null }
                    }
                }


};


            dbContext.Entities.AddRange(entities);
            dbContext.SaveChangesAsync();
        }
    }
}
