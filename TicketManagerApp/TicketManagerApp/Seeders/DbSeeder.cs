
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;
using static System.Net.Mime.MediaTypeNames;

namespace TicketManager.Infrastructure.Seeders
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public DbSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            // Seed AspNetRoles
            // ToDO : Code seeding user roles lie customer, specialist, manager, admin


            // Seed TicketManager db
            if (await _dbContext.Database.CanConnectAsync())
            {

                // Seed asp net roles
                if (!_dbContext.Roles.Any())
                {
                    var role1 = new IdentityRole()
                    {
                        Name = "Customer",
                        NormalizedName = "CUSTOMER"
                    };
                    _dbContext.Roles.Add(role1);

                    var role2 = new IdentityRole()
                    {
                        Name = "Specialist",
                        NormalizedName = "SPECIALIST"
                    };
                    _dbContext.Roles.Add(role2);

                    var role3 = new IdentityRole()
                    {
                        Name = "Manager",
                        NormalizedName = "MANAGER"
                    };
                    _dbContext.Roles.Add(role3);

                    var role4 = new IdentityRole()
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    };
                    _dbContext.Roles.Add(role3);


                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("Roles data exist - no need to seed.");
                }

                // Seed FactoryLocations db
                if (!_dbContext.FactoryLocations.Any())
                {
                    var factoryLoc1 = new FactoryLocation()
                    {
                        Country = "USA",
                        Factory = "HOP"
                    };
                    _dbContext.FactoryLocations.Add(factoryLoc1);

                    var factoryLoc2 = new FactoryLocation()
                    {
                        Country = "Poland",
                        Factory = "WRC"
                    };

                    _dbContext.FactoryLocations.Add(factoryLoc2);
                    await _dbContext.SaveChangesAsync();

                }
                else
                {
                    System.Console.WriteLine("FactoryLocations data exist - no need to seed.");
                }


                // Seed Departments db
                if (!_dbContext.Departments.Any())
                {
                    var department1 = new Department()
                    {
                        DepartmentDescription = "Test Department 1",
                        FactoryLocationId = 1
                    };
                    _dbContext.Departments.Add(department1);

                    var department2 = new Department()
                    {
                        DepartmentDescription = "Test Department 2",
                        FactoryLocationId = 2
                    };
                    _dbContext.Departments.Add(department2);

                    var department3 = new Department()
                    {
                        DepartmentDescription = "Test Department 3",
                        FactoryLocationId = 2
                    };
                    _dbContext.Departments.Add(department3);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("Departments data exist - no need to seed.");
                }

                // Seed LabLocations db
                if (!_dbContext.LabLocations.Any())
                {
                    var labLoc1 = new LabLocation()
                    {
                        Country = "USA",
                        Factory = "HOP"
                    };
                    _dbContext.LabLocations.Add(labLoc1);

                    var labLoc2 = new LabLocation()
                    {
                        Country = "Poland",
                        Factory = "WRC"
                    };
                    _dbContext.LabLocations.Add(labLoc2);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("LabLocations data exist - no need to seed.");
                }

                // Seed ProductFamily db
                if (!_dbContext.ProductFamilies.Any())
                {
                    var family1 = new ProductFamily()
                    {
                        FamilyDescription = "Motor"
                    };
                    _dbContext.ProductFamilies.Add(family1);

                    var family2 = new ProductFamily()
                    {
                        FamilyDescription = "Steering"
                    };
                    _dbContext.ProductFamilies.Add(family2);

                    var family3 = new ProductFamily()
                    {
                        FamilyDescription = "Priority Valve"
                    };
                    _dbContext.ProductFamilies.Add(family3);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ProductFamilies data exist - no need to seed.");
                }

                // Seed ProductTypes db
                if (!_dbContext.ProductTypes.Any())
                {
                    var productTypes = new List<ProductType>
                    {
                        new ProductType { ProductTypeDesc = "OMS", ProductFamilyId = 1 }, // id1
                        new ProductType { ProductTypeDesc = "OMP", ProductFamilyId = 1 }, // id 2
                        new ProductType { ProductTypeDesc = "OMR", ProductFamilyId = 1 }, // id 3
                        new ProductType { ProductTypeDesc = "OMPX", ProductFamilyId = 1 }, // id 4
                        new ProductType { ProductTypeDesc = "OMRX", ProductFamilyId = 1 }, // id 5
                        new ProductType { ProductTypeDesc = "OMEW", ProductFamilyId = 1 }, // id 6
                        new ProductType { ProductTypeDesc = "OMRS", ProductFamilyId = 1 }, // id 7
                        new ProductType { ProductTypeDesc = "OMH", ProductFamilyId = 1 }, // id 8
                        new ProductType { ProductTypeDesc = "OMR NA", ProductFamilyId = 1 }, // id 9
                        new ProductType { ProductTypeDesc = "OMR F", ProductFamilyId = 1 }, // id 10
                        new ProductType { ProductTypeDesc = "OMP F", ProductFamilyId = 1 }, // id 11
                        new ProductType { ProductTypeDesc = "OMM", ProductFamilyId = 1 }, // id 12
                        new ProductType { ProductTypeDesc = "OML", ProductFamilyId = 1 }, // id 13
                        new ProductType { ProductTypeDesc = "VIS", ProductFamilyId = 1 }, // id 14
                        new ProductType { ProductTypeDesc = "HP", ProductFamilyId = 1 }, // id 15
                        new ProductType { ProductTypeDesc = "RS", ProductFamilyId = 1 }, // id 16
                        new ProductType { ProductTypeDesc = "D9", ProductFamilyId = 1 }, // id 17
                        new ProductType { ProductTypeDesc = "RE", ProductFamilyId = 1 }, // id 18
                        new ProductType { ProductTypeDesc = "RC", ProductFamilyId = 1 }, // id 19
                        new ProductType { ProductTypeDesc = "DH", ProductFamilyId = 1 }, // id 20
                        new ProductType { ProductTypeDesc = "DT", ProductFamilyId = 1 }, // id 21
                        new ProductType { ProductTypeDesc = "DS", ProductFamilyId = 1 }, // id 22
                        new ProductType { ProductTypeDesc = "DR", ProductFamilyId = 1 }, // id 23
                        new ProductType { ProductTypeDesc = "CE", ProductFamilyId = 1 }, // id 24
                        new ProductType { ProductTypeDesc = "HB", ProductFamilyId = 1 }, // id 25
                        new ProductType { ProductTypeDesc = "HK", ProductFamilyId = 1 }, // id 26
                        new ProductType { ProductTypeDesc = "WS", ProductFamilyId = 1 }, // id 27
                        new ProductType { ProductTypeDesc = "OSPM", ProductFamilyId = 2 }, // id 28
                        new ProductType { ProductTypeDesc = "OSPP", ProductFamilyId = 2 }, // id 29
                        new ProductType { ProductTypeDesc = "OSMPS", ProductFamilyId = 2 }, // id 30
                        new ProductType { ProductTypeDesc = "S10", ProductFamilyId = 2 }, // id 31
                        new ProductType { ProductTypeDesc = "S20", ProductFamilyId = 2 }, // id 32
                        new ProductType { ProductTypeDesc = "LAGU", ProductFamilyId = 2 }, // id 33
                        new ProductType { ProductTypeDesc = "LAGZ", ProductFamilyId = 2 }, // id 34
                        new ProductType { ProductTypeDesc = "LAGC", ProductFamilyId = 2 } // id 35
                    };

                    await _dbContext.ProductTypes.AddRangeAsync(productTypes);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ProductTypes data exist - no need to seed.");
                }

                // Seed ProductDisplacements db
                if (!_dbContext.ProductDisplacements.Any())
                {
                    var productDisplacements = new List<ProductDisplacement>
                    {

                          // OMS Product Displacements 1
                          new ProductDisplacement { Displacement = "80", ProductTypeId = 1 }, // id1
                          new ProductDisplacement { Displacement = "100", ProductTypeId = 1 }, // id2
                          new ProductDisplacement { Displacement = "125", ProductTypeId = 1 }, // id3
                          new ProductDisplacement { Displacement = "160", ProductTypeId = 1 }, // id4
                          new ProductDisplacement { Displacement = "200", ProductTypeId = 1 }, // id5
                          new ProductDisplacement { Displacement = "250", ProductTypeId = 1 }, // id6
                          new ProductDisplacement { Displacement = "315", ProductTypeId = 1 }, // id7
                          new ProductDisplacement { Displacement = "400", ProductTypeId = 1 }, // id8
                          new ProductDisplacement { Displacement = "500", ProductTypeId = 1 }, // id9

                          // OMP Product Displacements 2
                          new ProductDisplacement { Displacement = "25", ProductTypeId = 2 }, // id10
                          new ProductDisplacement { Displacement = "32", ProductTypeId = 2 }, // id11
                          new ProductDisplacement { Displacement = "40", ProductTypeId = 2 }, // id12
                          new ProductDisplacement { Displacement = "50", ProductTypeId = 2 }, // id13
                          new ProductDisplacement { Displacement = "80", ProductTypeId = 2 }, // id14
                          new ProductDisplacement { Displacement = "100", ProductTypeId = 2 }, // id15
                          new ProductDisplacement { Displacement = "125", ProductTypeId = 2 }, // id16
                          new ProductDisplacement { Displacement = "160", ProductTypeId = 2 }, // id17
                          new ProductDisplacement { Displacement = "200", ProductTypeId = 2 }, // id18
                          new ProductDisplacement { Displacement = "250", ProductTypeId = 2 }, // id19
                          new ProductDisplacement { Displacement = "315", ProductTypeId = 2 }, // id20
                          new ProductDisplacement { Displacement = "400", ProductTypeId = 2 }, // id21

                          // OMR Product Displacements 3
                          new ProductDisplacement { Displacement = "50", ProductTypeId = 3 }, // id22
                          new ProductDisplacement { Displacement = "80", ProductTypeId = 3 }, // id23
                          new ProductDisplacement { Displacement = "100", ProductTypeId = 3 }, // id24
                          new ProductDisplacement { Displacement = "125", ProductTypeId = 3 }, // id25
                          new ProductDisplacement { Displacement = "160", ProductTypeId = 3 }, // id26
                          new ProductDisplacement { Displacement = "200", ProductTypeId = 3 }, // id27
                          new ProductDisplacement { Displacement = "250", ProductTypeId = 3 }, // id28
                          new ProductDisplacement { Displacement = "315", ProductTypeId = 3 }, // id29
                          new ProductDisplacement { Displacement = "375", ProductTypeId = 3 }, // id30 
                          new ProductDisplacement { Displacement = "400", ProductTypeId = 3 }, // id31

                          // OMPX Product Displacements 4
                          new ProductDisplacement { Displacement = "25", ProductTypeId = 4 }, // id32
                          new ProductDisplacement { Displacement = "32", ProductTypeId = 4 }, // id33 
                          new ProductDisplacement { Displacement = "40", ProductTypeId = 4 }, // id34
                          new ProductDisplacement { Displacement = "50", ProductTypeId = 4 }, // id35
                          new ProductDisplacement { Displacement = "80", ProductTypeId = 4 }, // id36
                          new ProductDisplacement { Displacement = "100", ProductTypeId = 4 }, // id37
                          new ProductDisplacement { Displacement = "125", ProductTypeId = 4 }, // id38
                          new ProductDisplacement { Displacement = "160", ProductTypeId = 4 }, // id39
                          new ProductDisplacement { Displacement = "200", ProductTypeId = 4 }, // id40
                          new ProductDisplacement { Displacement = "250", ProductTypeId = 4 }, // id41
                          new ProductDisplacement { Displacement = "315", ProductTypeId = 4 }, // id42
                          new ProductDisplacement { Displacement = "375", ProductTypeId = 4 }, // id43
                          new ProductDisplacement { Displacement = "400", ProductTypeId = 4 }, // id44

                        // OMEW Product Displacements
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 6 }, // id45
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 6 }, // id46
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 6 }, // id47
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 6 }, // id48
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 6 }, // id49
                        new ProductDisplacement { Displacement = "315", ProductTypeId = 6 }, // id50
                        new ProductDisplacement { Displacement = "345", ProductTypeId = 6 }, // id51
                        new ProductDisplacement { Displacement = "400", ProductTypeId = 6 }, // id52

                        // OMRS Product Displacements
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 7 }, // id53
                        new ProductDisplacement { Displacement = "65", ProductTypeId = 7 }, // id54
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 7 }, // id55
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 7 }, // id56
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 7 }, // id57
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 7 }, // id58
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 7 }, // id59
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 7 }, // id60
                        new ProductDisplacement { Displacement = "315", ProductTypeId = 7 }, // id61

                        // OMH Product Displacements
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 8 }, // id62
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 8 }, // id63
                        new ProductDisplacement { Displacement = "325", ProductTypeId = 8 }, // id64
                        new ProductDisplacement { Displacement = "400", ProductTypeId = 8 }, // id65
                        new ProductDisplacement { Displacement = "500", ProductTypeId = 8 }, // id66

                        // OMR NA Product Displacements
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 9 }, // id67
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 9 }, // id68
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 9 }, // id69
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 9 }, // id70
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 9 }, // id71
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 9 }, // id72
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 9 }, // id73
                        new ProductDisplacement { Displacement = "315", ProductTypeId = 9 }, // id74
                        new ProductDisplacement { Displacement = "375", ProductTypeId = 9 }, // id75
                        new ProductDisplacement { Displacement = "400", ProductTypeId = 9 }, // id76

                        // OMR F Product Displacements
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 10 }, // id77
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 10 }, // id78
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 10 }, // id79
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 10 }, // id80
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 10 }, // id81
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 10 }, // id82
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 10 }, // id83
                        new ProductDisplacement { Displacement = "315", ProductTypeId = 10 }, // id84
                        new ProductDisplacement { Displacement = "375", ProductTypeId = 10 }, // id85
                        new ProductDisplacement { Displacement = "400", ProductTypeId = 10 }, // id86

                        // OMP F Product Displacements
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 11 }, // id87
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 11 }, // id88
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 11 }, // id89
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 11 }, // id90
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 11 }, // id91
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 11 }, // id92
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 11 }, // id93
                        new ProductDisplacement { Displacement = "315", ProductTypeId = 11 }, // id94
                        new ProductDisplacement { Displacement = "375", ProductTypeId = 11 }, // id95
                        new ProductDisplacement { Displacement = "400", ProductTypeId = 11 }, // id96

                        // OMM Product Displacements
                        new ProductDisplacement { Displacement = "8", ProductTypeId = 12 }, // id97
                        new ProductDisplacement { Displacement = "12.5", ProductTypeId = 12 }, // id98
                        new ProductDisplacement { Displacement = "20", ProductTypeId = 12 }, // id99
                        new ProductDisplacement { Displacement = "32", ProductTypeId = 12 }, // id100
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 12 }, // id101

                        // OML Product Displacements
                        new ProductDisplacement { Displacement = "8", ProductTypeId = 13 }, // id102
                        new ProductDisplacement { Displacement = "12.5", ProductTypeId = 13 }, // id103
                        new ProductDisplacement { Displacement = "20", ProductTypeId = 13 }, // id104
                        new ProductDisplacement { Displacement = "32", ProductTypeId = 13 }, // id105

                        // VIS
                        new ProductDisplacement { Displacement = "19.8", ProductTypeId = 14 }, // id106
                        new ProductDisplacement { Displacement = "24.4", ProductTypeId = 14 }, // id107
                        new ProductDisplacement { Displacement = "30.7", ProductTypeId = 14 }, // id108
                        new ProductDisplacement { Displacement = "34.9", ProductTypeId = 14 }, // id109
                        new ProductDisplacement { Displacement = "38.5", ProductTypeId = 14 }, // id110
                        new ProductDisplacement { Displacement = "42.7", ProductTypeId = 14 }, // id111
                        new ProductDisplacement { Displacement = "48", ProductTypeId = 14 }, // id112
                        new ProductDisplacement { Displacement = "57.4", ProductTypeId = 14 }, // id113

                        // HP Product Displacements
                        new ProductDisplacement { Displacement = "21", ProductTypeId = 15 }, // id114
                        new ProductDisplacement { Displacement = "24.4", ProductTypeId = 15 }, // id115
                        new ProductDisplacement { Displacement = "26.5", ProductTypeId = 15 }, // id116
                        new ProductDisplacement { Displacement = "29.3", ProductTypeId = 15 }, // id117
                        new ProductDisplacement { Displacement = "41.3", ProductTypeId = 15 }, // id118

                        // RS Product Displacements
                        new ProductDisplacement { Displacement = "3.2", ProductTypeId = 16 }, // id119
                        new ProductDisplacement { Displacement = "4.6", ProductTypeId = 16 }, // id120 
                        new ProductDisplacement { Displacement = "5.4", ProductTypeId = 16 }, // id121 
                        new ProductDisplacement { Displacement = "6.3", ProductTypeId = 16 }, // id122
                        new ProductDisplacement { Displacement = "6.8", ProductTypeId = 16 }, // id123
                        new ProductDisplacement { Displacement = "7.7", ProductTypeId = 16 }, // id124
                        new ProductDisplacement { Displacement = "10", ProductTypeId = 16 }, // id125
                        new ProductDisplacement { Displacement = "12.5", ProductTypeId = 16 }, // id126
                        new ProductDisplacement { Displacement = "15.5", ProductTypeId = 16 }, // id127
                        new ProductDisplacement { Displacement = "17.9", ProductTypeId = 16 }, // id128
                        new ProductDisplacement { Displacement = "24.9", ProductTypeId = 16 }, // id129

                        // D9 Product Displacements
                        new ProductDisplacement { Displacement = "15.6", ProductTypeId = 17 }, // id130
                        new ProductDisplacement { Displacement = "17.9", ProductTypeId = 17 }, // id131
                        new ProductDisplacement { Displacement = "22.4", ProductTypeId = 17 }, // id132
                        new ProductDisplacement { Displacement = "27.8", ProductTypeId = 17 }, // id133
                        new ProductDisplacement { Displacement = "32.1", ProductTypeId = 17 }, // id134
                        new ProductDisplacement { Displacement = "38.1", ProductTypeId = 17 }, // id135
                        new ProductDisplacement { Displacement = "44.8", ProductTypeId = 17 }, // id136
                        new ProductDisplacement { Displacement = "55.6", ProductTypeId = 17 }, // id137
                        new ProductDisplacement { Displacement = "62.7", ProductTypeId = 17 }, // id138

                        // RE Product Displacements
                        new ProductDisplacement { Displacement = "7.4", ProductTypeId = 18 }, // id139
                        new ProductDisplacement { Displacement = "9.9", ProductTypeId = 18 }, // id140
                        new ProductDisplacement { Displacement = "12.4", ProductTypeId = 18 }, // id141
                        new ProductDisplacement { Displacement = "14.2", ProductTypeId = 18 }, // id142
                        new ProductDisplacement { Displacement = "15.9", ProductTypeId = 18 }, // id143
                        new ProductDisplacement { Displacement = "18.3", ProductTypeId = 18 }, // id144
                        new ProductDisplacement { Displacement = "21.2", ProductTypeId = 18 }, // id145
                        new ProductDisplacement { Displacement = "22.8", ProductTypeId = 18 }, // id146
                        new ProductDisplacement { Displacement = "28.3", ProductTypeId = 18 }, // id147
                        new ProductDisplacement { Displacement = "32.7", ProductTypeId = 18 }, // id148
                        new ProductDisplacement { Displacement = "38.5", ProductTypeId = 18 }, // id149
                        new ProductDisplacement { Displacement = "45.6", ProductTypeId = 18 }, // id150

                        // RC Product Displacements
                        new ProductDisplacement { Displacement = "7.4", ProductTypeId = 19 }, // id151
                        new ProductDisplacement { Displacement = "9.9", ProductTypeId = 19 }, // id152
                        new ProductDisplacement { Displacement = "12.4", ProductTypeId = 19 }, // id153
                        new ProductDisplacement { Displacement = "14.2", ProductTypeId = 19 }, // id154
                        new ProductDisplacement { Displacement = "15.9", ProductTypeId = 19 }, // id155
                        new ProductDisplacement { Displacement = "18.3", ProductTypeId = 19 }, // id156
                        new ProductDisplacement { Displacement = "21.2", ProductTypeId = 19 }, // id157
                        new ProductDisplacement { Displacement = "22.8", ProductTypeId = 19 }, // id158
                        new ProductDisplacement { Displacement = "28.3", ProductTypeId = 19 }, // id159
                        new ProductDisplacement { Displacement = "32.7", ProductTypeId = 19 }, // id160
                        new ProductDisplacement { Displacement = "38.5", ProductTypeId = 19 }, // id161
                        new ProductDisplacement { Displacement = "45.6", ProductTypeId = 19 }, // id162

                        // DH Product Displacements
                        new ProductDisplacement { Displacement = "36", ProductTypeId = 20 }, // id163
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 20 }, // id164
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 20 }, // id165
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 20 }, // id166
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 20 }, // id167
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 20 }, // id168
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 20 }, // id169
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 20 }, // id170
                        new ProductDisplacement { Displacement = "315", ProductTypeId = 20 }, // id171
                        new ProductDisplacement { Displacement = "400", ProductTypeId = 20 }, // id172

                        // DT Product Displacements
                        new ProductDisplacement { Displacement = "18.3", ProductTypeId = 21 }, // id173
                        new ProductDisplacement { Displacement = "22.8", ProductTypeId = 21 }, // id174
                        new ProductDisplacement { Displacement = "28.3", ProductTypeId = 21 }, // id175
                        new ProductDisplacement { Displacement = "32.7", ProductTypeId = 21 }, // id176
                        new ProductDisplacement { Displacement = "45.6", ProductTypeId = 21 }, // id177
                        new ProductDisplacement { Displacement = "56.7", ProductTypeId = 21 }, // id178
                        new ProductDisplacement { Displacement = "63.9", ProductTypeId = 21 }, // id179
                        new ProductDisplacement { Displacement = "91.2", ProductTypeId = 21 }, // id180
                        new ProductDisplacement { Displacement = "127.7", ProductTypeId = 21 }, // id181

                        // DS Product Displacements
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 22 }, // id182
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 22 }, // id183
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 22 }, // id184
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 22 }, // id185
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 22 }, // id186
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 22 }, // id187
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 22 }, // id188
                        new ProductDisplacement { Displacement = "315", ProductTypeId = 22 }, // id189
                        new ProductDisplacement { Displacement = "375", ProductTypeId = 22 }, // id190

                        // DR Product Displacements
                        new ProductDisplacement { Displacement = "12.4", ProductTypeId = 23 }, // id191
                        new ProductDisplacement { Displacement = "15.9", ProductTypeId = 23 }, // id192
                        new ProductDisplacement { Displacement = "18.3", ProductTypeId = 23 }, // id193
                        new ProductDisplacement { Displacement = "21.2", ProductTypeId = 23 }, // id194
                        new ProductDisplacement { Displacement = "22.8", ProductTypeId = 23 }, // id195
                        new ProductDisplacement { Displacement = "28.3", ProductTypeId = 23 }, // id196
                        new ProductDisplacement { Displacement = "32.7", ProductTypeId = 23 }, // id197
                        new ProductDisplacement { Displacement = "45.6", ProductTypeId = 23 }, // id198

                        // CE Product Displacements
                        new ProductDisplacement { Displacement = "7.4", ProductTypeId = 24 }, // id199
                        new ProductDisplacement { Displacement = "9.9", ProductTypeId = 24 }, // id200
                        new ProductDisplacement { Displacement = "12.4", ProductTypeId = 24 }, // id201
                        new ProductDisplacement { Displacement = "14.2", ProductTypeId = 24 }, // id202
                        new ProductDisplacement { Displacement = "15.9", ProductTypeId = 24 }, // id203
                        new ProductDisplacement { Displacement = "18.3", ProductTypeId = 24 }, // id204
                        new ProductDisplacement { Displacement = "21.2", ProductTypeId = 24 }, // id205
                        new ProductDisplacement { Displacement = "22.8", ProductTypeId = 24 }, // id206
                        new ProductDisplacement { Displacement = "28.3", ProductTypeId = 24 }, // id207
                        new ProductDisplacement { Displacement = "32.7", ProductTypeId = 24 }, // id208
                        new ProductDisplacement { Displacement = "45.6", ProductTypeId = 24 }, // id209

                        // HB Product Displacements
                        new ProductDisplacement { Displacement = "3.2", ProductTypeId = 25 }, // id210
                        new ProductDisplacement { Displacement = "4.6", ProductTypeId = 25 }, // id211
                        new ProductDisplacement { Displacement = "5.4", ProductTypeId = 25 }, // id212
                        new ProductDisplacement { Displacement = "6.8", ProductTypeId = 25 }, // id213
                        new ProductDisplacement { Displacement = "7.7", ProductTypeId = 25 }, // id214
                        new ProductDisplacement { Displacement = "10", ProductTypeId = 25 }, // id215
                        new ProductDisplacement { Displacement = "12.5", ProductTypeId = 25 }, // id216
                        new ProductDisplacement { Displacement = "15.5", ProductTypeId = 25 }, // id217
                        new ProductDisplacement { Displacement = "17.9", ProductTypeId = 25 }, // id218
                        new ProductDisplacement { Displacement = "24.9", ProductTypeId = 25 }, // id219

                        // HK Product Displacements
                        new ProductDisplacement { Displacement = "3.2", ProductTypeId = 26 }, // id220
                        new ProductDisplacement { Displacement = "4.6", ProductTypeId = 26 }, // id221
                        new ProductDisplacement { Displacement = "5.4", ProductTypeId = 26 }, // id222
                        new ProductDisplacement { Displacement = "6.8", ProductTypeId = 26 }, // id223
                        new ProductDisplacement { Displacement = "7.7", ProductTypeId = 26 }, // id224
                        new ProductDisplacement { Displacement = "10", ProductTypeId = 26 }, // id225
                        new ProductDisplacement { Displacement = "12.5", ProductTypeId = 26 }, // id226
                        new ProductDisplacement { Displacement = "15.5", ProductTypeId = 26 }, // id227
                        new ProductDisplacement { Displacement = "17.9", ProductTypeId = 26 }, // id228
                        new ProductDisplacement { Displacement = "24.9", ProductTypeId = 26 }, // id229

                        // WS Product Displacements
                        new ProductDisplacement { Displacement = "4.8", ProductTypeId = 27 }, // id230
                        new ProductDisplacement { Displacement = "6.1", ProductTypeId = 27 }, // id231
                        new ProductDisplacement { Displacement = "6.8", ProductTypeId = 27 }, // id232
                        new ProductDisplacement { Displacement = "7.9", ProductTypeId = 27 }, // id233
                        new ProductDisplacement { Displacement = "9.8", ProductTypeId = 27 }, // id234
                        new ProductDisplacement { Displacement = "12.3", ProductTypeId = 27 }, // id235
                        new ProductDisplacement { Displacement = "14", ProductTypeId = 27 }, // id236
                        new ProductDisplacement { Displacement = "15.1", ProductTypeId = 27 }, // id237
                        new ProductDisplacement { Displacement = "19.6", ProductTypeId = 27 }, // id238
                        new ProductDisplacement { Displacement = "24.2", ProductTypeId = 27 }, // id239
                        new ProductDisplacement { Displacement = "30.2", ProductTypeId = 27 }, // id240

                        // OSPM Product Displacements
                        new ProductDisplacement { Displacement = "32", ProductTypeId = 28 }, // id241
                        new ProductDisplacement { Displacement = "40", ProductTypeId = 28 }, // id242
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 28 }, // id243
                        new ProductDisplacement { Displacement = "63", ProductTypeId = 28 }, // id244
                        new ProductDisplacement { Displacement = "70", ProductTypeId = 28 }, // id245
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 28 }, // id246
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 28 }, // id247

                        // OSPP Product Displacements
                        new ProductDisplacement { Displacement = "32", ProductTypeId = 29 }, // id248
                        new ProductDisplacement { Displacement = "40", ProductTypeId = 29 }, // id249
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 29 }, // id250
                        new ProductDisplacement { Displacement = "63", ProductTypeId = 29 }, // id251
                        new ProductDisplacement { Displacement = "70", ProductTypeId = 29 }, // id252
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 29 }, // id253
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 29 }, // id254

                        // OSPMS Product Displacements
                        new ProductDisplacement { Displacement = "32", ProductTypeId = 30 }, // id255
                        new ProductDisplacement { Displacement = "40", ProductTypeId = 30 }, // id256
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 30 }, // id257
                        new ProductDisplacement { Displacement = "63", ProductTypeId = 30 }, // id258
                        new ProductDisplacement { Displacement = "70", ProductTypeId = 30 }, // id259
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 30 }, // id260
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 30 }, // id261

                        // S10 Product Displacements
                        new ProductDisplacement { Displacement = "3.6", ProductTypeId = 31 }, // id262
                        new ProductDisplacement { Displacement = "4.5", ProductTypeId = 31 }, // id263
                        new ProductDisplacement { Displacement = "5.9", ProductTypeId = 31 }, // id264
                        new ProductDisplacement { Displacement = "7.3", ProductTypeId = 31 }, // id265
                        new ProductDisplacement { Displacement = "8.9", ProductTypeId = 31 }, // id266
                        new ProductDisplacement { Displacement = "9.7", ProductTypeId = 31 }, // id267
                        new ProductDisplacement { Displacement = "11.3", ProductTypeId = 31 }, // id268
                        new ProductDisplacement { Displacement = "14.1", ProductTypeId = 31 }, // id269
                        new ProductDisplacement { Displacement = "17.9", ProductTypeId = 31 }, // id270
                        new ProductDisplacement { Displacement = "22.6", ProductTypeId = 31 }, // id271
                        new ProductDisplacement { Displacement = "28.2", ProductTypeId = 31 }, // id272
                        new ProductDisplacement { Displacement = "35.9", ProductTypeId = 31 }, // id273
                        new ProductDisplacement { Displacement = "45.1", ProductTypeId = 31 }, // id274

                        // LAGU Product Displacements
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 33 }, // id275
                        new ProductDisplacement { Displacement = "60", ProductTypeId = 33 }, // id276
                        new ProductDisplacement { Displacement = "70", ProductTypeId = 33 }, // id277
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 33 }, // id278
                        new ProductDisplacement { Displacement = "90", ProductTypeId = 33 }, // id279
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 33 }, // id280
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 33 }, // id281
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 33 }, // id282

                        // LAGZ Product Displacements
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 34 }, // id283
                        new ProductDisplacement { Displacement = "140", ProductTypeId = 34 }, // id284
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 34 }, // id285
                        new ProductDisplacement { Displacement = "190", ProductTypeId = 34 }, // id286
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 34 }, // id287
                        new ProductDisplacement { Displacement = "220", ProductTypeId = 34 }, // id288
                        new ProductDisplacement { Displacement = "240", ProductTypeId = 34 }, // id289
                        new ProductDisplacement { Displacement = "300", ProductTypeId = 34 }, // id290
                        new ProductDisplacement { Displacement = "420", ProductTypeId = 34 }, // id291
                        new ProductDisplacement { Displacement = "500", ProductTypeId = 34 }, // id292
                        new ProductDisplacement { Displacement = "620", ProductTypeId = 34 }, // id293

                        // LAGC Product Displacements
                        new ProductDisplacement { Displacement = "40", ProductTypeId = 35 }, // id294
                        new ProductDisplacement { Displacement = "50", ProductTypeId = 35 }, // id295
                        new ProductDisplacement { Displacement = "63", ProductTypeId = 35 }, // id296
                        new ProductDisplacement { Displacement = "70", ProductTypeId = 35 }, // id297
                        new ProductDisplacement { Displacement = "80", ProductTypeId = 35 }, // id298
                        new ProductDisplacement { Displacement = "100", ProductTypeId = 35 }, // id299
                        new ProductDisplacement { Displacement = "125", ProductTypeId = 35 }, // id300
                        new ProductDisplacement { Displacement = "140", ProductTypeId = 35 }, // id301
                        new ProductDisplacement { Displacement = "160", ProductTypeId = 35 }, // id302
                        new ProductDisplacement { Displacement = "200", ProductTypeId = 35 }, // id303
                        new ProductDisplacement { Displacement = "250", ProductTypeId = 35 }, // id304
                        new ProductDisplacement { Displacement = "320", ProductTypeId = 35 }, // id305
                        new ProductDisplacement { Displacement = "400", ProductTypeId = 35 }, // id306
                        new ProductDisplacement { Displacement = "500", ProductTypeId = 35 }, // id307
                        new ProductDisplacement { Displacement = "630", ProductTypeId = 35 }, // id308
                        new ProductDisplacement { Displacement = "800", ProductTypeId = 35 }  // id309
                    };

                    await _dbContext.ProductDisplacements.AddRangeAsync(productDisplacements);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ProductDisplacements data exist - no need to seed.");
                }



                // Seed Products db
                if (!_dbContext.Products.Any())
                {
                    var products = new List<Product>
                    {
                        // OMS Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 1 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 2 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 3 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 4 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 5 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 6 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 7 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 8 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 1, ProductDisplacementId = 9 },
        
                        // OMP Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 10 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 11 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 12 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 13 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 14 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 15 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 16 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 17 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 18 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 19 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 20 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 2, ProductDisplacementId = 21 },
        
                        // OMR Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 22 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 23 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 24 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 25 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 26 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 27 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 28 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 29 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 30 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 3, ProductDisplacementId = 31 },
        
                        // OMPX Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 32 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 33 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 34 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 35 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 36 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 37 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 38 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 39 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 40 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 41 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 42 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 43 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 5, ProductDisplacementId = 44 },

                        // OMEW Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 8, ProductDisplacementId = 45 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 8, ProductDisplacementId = 46 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 8, ProductDisplacementId = 47 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 8, ProductDisplacementId = 48 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 8, ProductDisplacementId = 49 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 8, ProductDisplacementId = 50 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 8, ProductDisplacementId = 51 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 8, ProductDisplacementId = 52 },

                        // OMRS Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 53 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 54 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 55 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 56 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 57 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 58 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 59 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 60 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 9, ProductDisplacementId = 61 },


                        // OMH Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 10, ProductDisplacementId = 62 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 10, ProductDisplacementId = 63 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 10, ProductDisplacementId = 64 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 10, ProductDisplacementId = 65 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 10, ProductDisplacementId = 66 },

                        // OMR NA Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 67 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 68 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 69 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 70 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 71 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 72 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 73 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 74 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 75 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 11, ProductDisplacementId = 76 },

                        // OMR F Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 77 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 78 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 79 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 80 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 81 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 82 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 83 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 84 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 85 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 12, ProductDisplacementId = 86 },

                        // OMP F Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 87 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 88 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 89 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 90 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 91 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 92 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 93 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 94 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 95 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 13, ProductDisplacementId = 96 },


                        // OMM Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 14, ProductDisplacementId = 97 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 14, ProductDisplacementId = 98 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 14, ProductDisplacementId = 99 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 14, ProductDisplacementId = 100 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 14, ProductDisplacementId = 101 },

                        // start here 
                        // OML Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 15, ProductDisplacementId = 102 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 15, ProductDisplacementId = 103 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 15, ProductDisplacementId = 104 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 15, ProductDisplacementId = 105 },

                        // VIS Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 16, ProductDisplacementId = 106 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 16, ProductDisplacementId = 107 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 16, ProductDisplacementId = 108 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 16, ProductDisplacementId = 109 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 16, ProductDisplacementId = 110 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 16, ProductDisplacementId = 111 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 16, ProductDisplacementId = 112 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 16, ProductDisplacementId = 113 },

                        // HP Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 17, ProductDisplacementId = 114 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 17, ProductDisplacementId = 115 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 17, ProductDisplacementId = 116 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 17, ProductDisplacementId = 117 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 17, ProductDisplacementId = 118 },

                        // RS Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 119 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 120 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 121 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 122 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 123 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 124 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 125 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 126 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 127 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 128 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 18, ProductDisplacementId = 129 },

                        // D9 Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 130 }, // id130
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 131 }, // id131
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 132 }, // id132
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 133 }, // id133
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 134 }, // id134
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 135 }, // id135
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 136 }, // id136
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 137 }, // id137
                        new Product { ProductFamilyId = 1, ProductTypeId = 19, ProductDisplacementId = 138 }, // id138

                        // RE Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 139 }, // id139
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 140 }, // id140
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 141 }, // id141
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 142 }, // id142
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 143 }, // id143
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 144 }, // id144
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 145 }, // id145
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 146 }, // id146
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 147 }, // id147
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 148 }, // id148
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 149 }, // id149
                        new Product { ProductFamilyId = 1, ProductTypeId = 20, ProductDisplacementId = 150 }, // id150

                        // RC Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 151 }, // id151
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 152 }, // id152
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 153 }, // id153
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 154 }, // id154
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 155 }, // id155
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 156 }, // id156
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 157 }, // id157
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 158 }, // id158
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 159 }, // id159
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 160 }, // id160
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 161 }, // id161
                        new Product { ProductFamilyId = 1, ProductTypeId = 21, ProductDisplacementId = 162 }, // id162

                        // DH Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 163 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 164 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 165 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 166 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 167 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 168 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 169 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 170 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 171 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 22, ProductDisplacementId = 172 },

                        // DT Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 173 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 174 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 175 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 176 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 177 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 178 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 179 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 180 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 23, ProductDisplacementId = 181 },

                        // DS Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 182 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 183 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 184 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 185 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 186 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 187 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 188 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 189 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 24, ProductDisplacementId = 190 },

                        // DR Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 25, ProductDisplacementId = 191 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 25, ProductDisplacementId = 192 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 25, ProductDisplacementId = 193 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 25, ProductDisplacementId = 194 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 25, ProductDisplacementId = 195 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 25, ProductDisplacementId = 196 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 25, ProductDisplacementId = 197 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 25, ProductDisplacementId = 198 },

                        // CE Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 199 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 200 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 201 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 202 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 203 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 204 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 205 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 206 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 207 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 208 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 26, ProductDisplacementId = 209 },

                        // HB Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 210 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 211 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 212 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 213 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 214 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 215 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 216 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 217 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 218 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 27, ProductDisplacementId = 219 },

                        // HK Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 220 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 221 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 222 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 223 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 224 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 225 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 226 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 227 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 228 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 28, ProductDisplacementId = 229 },

                        // WS Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 230 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 231 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 232 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 233 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 234 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 235 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 236 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 237 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 238 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 239 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 29, ProductDisplacementId = 240 },

                        // OSPM Products
                        new Product { ProductFamilyId = 2, ProductTypeId = 30, ProductDisplacementId = 241 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 30, ProductDisplacementId = 242 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 30, ProductDisplacementId = 243 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 30, ProductDisplacementId = 244 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 30, ProductDisplacementId = 245 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 30, ProductDisplacementId = 246 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 30, ProductDisplacementId = 247 },

                        // OSPP Products
                        new Product { ProductFamilyId = 2, ProductTypeId = 31, ProductDisplacementId = 248 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 31, ProductDisplacementId = 249 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 31, ProductDisplacementId = 250 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 31, ProductDisplacementId = 251 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 31, ProductDisplacementId = 252 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 31, ProductDisplacementId = 253 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 31, ProductDisplacementId = 254 },

                        // S10 Products
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 255 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 256 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 257 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 258 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 259 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 260 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 261 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 262 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 263 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 264 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 265 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 266 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 267 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 268 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 269 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 270 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 271 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 272 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 273 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 33, ProductDisplacementId = 274 },

                        // LAGU Products
                        new Product { ProductFamilyId = 2, ProductTypeId = 35, ProductDisplacementId = 275 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 35, ProductDisplacementId = 276 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 35, ProductDisplacementId = 277 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 35, ProductDisplacementId = 278 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 35, ProductDisplacementId = 279 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 35, ProductDisplacementId = 280 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 35, ProductDisplacementId = 281 },
                        new Product { ProductFamilyId = 2, ProductTypeId = 35, ProductDisplacementId = 282 },

                        // LAGZ Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 283 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 284 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 285 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 286 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 287 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 288 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 289 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 290 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 291 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 292 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 35, ProductDisplacementId = 293 },

                        // LAGC Products
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 294 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 295 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 296 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 297 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 298 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 299 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 300 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 301 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 302 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 303 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 304 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 305 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 306 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 307 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 308 },
                        new Product { ProductFamilyId = 1, ProductTypeId = 37, ProductDisplacementId = 309 },
                    };

                    await _dbContext.Products.AddRangeAsync(products);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ReportStructures data exist - no need to seed.");
                }

                // Seed ReportTypes db
                if (!_dbContext.ReportTypes.Any())
                {
                    var reptype1 = new ReportType()
                    {
                        ReportShortType = "MER",
                        ReportDescription = "Motor Engineering Report",
                        ProductFamilyId = 1
                    };
                    _dbContext.ReportTypes.Add(reptype1);

                    var reptype2 = new ReportType()
                    {
                        ReportShortType = "SER",
                        ReportDescription = "Steering Engineering Report",
                        ProductFamilyId = 2
                    };
                    _dbContext.ReportTypes.Add(reptype2);

                    var reptype3 = new ReportType()
                    {
                        ReportShortType = "CTR",
                        ReportDescription = "Custom Test Request",
                        ProductFamilyId = 1
                    };
                    _dbContext.ReportTypes.Add(reptype3);

                    var reptype4 = new ReportType()
                    {
                        ReportShortType = "SER",
                        ReportDescription = "Steering Engineering Report",
                        ProductFamilyId = 3
                    };
                    _dbContext.ReportTypes.Add(reptype4);

                    var reptype5 = new ReportType()
                    {
                        ReportShortType = "CTR",
                        ReportDescription = "Custom Test Request",
                        ProductFamilyId = 2
                    };
                    _dbContext.ReportTypes.Add(reptype5);

                    var reptype6 = new ReportType()
                    {
                        ReportShortType = "CTR",
                        ReportDescription = "Custom Test Request",
                        ProductFamilyId = 3
                    };
                    _dbContext.ReportTypes.Add(reptype6);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ReportTypes data exist - no need to seed.");
                }

                // Seed ReportStructure db
                if (!_dbContext.ReportStructures.Any())
                {
                    var repstructure1 = new ReportStructure()
                    {
                        FolderDescription = "01 Test data Lab",
                        ReportTypeId = 1
                    };
                    _dbContext.ReportStructures.Add(repstructure1);

                    var repstructure2 = new ReportStructure()
                    {
                        FolderDescription = "02 Calculations",
                        ReportTypeId = 1
                    };
                    _dbContext.ReportStructures.Add(repstructure2);

                    var repstructure3 = new ReportStructure()
                    {
                        FolderDescription = "03 Pictures",
                        ReportTypeId = 1
                    };
                    _dbContext.ReportStructures.Add(repstructure3);

                    var repstructure4 = new ReportStructure()
                    {
                        FolderDescription = "04 Communication",
                        ReportTypeId = 1
                    };
                    _dbContext.ReportStructures.Add(repstructure4);

                    var repstructure5 = new ReportStructure()
                    {
                        FolderDescription = "05 Meetings",
                        ReportTypeId = 1
                    };
                    _dbContext.ReportStructures.Add(repstructure5);


                    var repstructure11 = new ReportStructure()
                    {
                        FolderDescription = "01 Test data Lab",
                        ReportTypeId = 2
                    };
                    _dbContext.ReportStructures.Add(repstructure11);

                    var repstructure22 = new ReportStructure()
                    {
                        FolderDescription = "02 Calculations",
                        ReportTypeId = 2
                    };
                    _dbContext.ReportStructures.Add(repstructure22);

                    var repstructure33 = new ReportStructure()
                    {
                        FolderDescription = "03 Pictures",
                        ReportTypeId = 2
                    };
                    _dbContext.ReportStructures.Add(repstructure33);

                    var repstructure44 = new ReportStructure()
                    {
                        FolderDescription = "04 Communication",
                        ReportTypeId = 2
                    };
                    _dbContext.ReportStructures.Add(repstructure44);

                    var repstructure55 = new ReportStructure()
                    {
                        FolderDescription = "05 Meetings",
                        ReportTypeId = 2
                    };
                    _dbContext.ReportStructures.Add(repstructure55);

                    var repstructure113 = new ReportStructure()
                    {
                        FolderDescription = "01 Test data Lab",
                        ReportTypeId = 3
                    };
                    _dbContext.ReportStructures.Add(repstructure113);

                    var repstructure223 = new ReportStructure()
                    {
                        FolderDescription = "02 Calculations",
                        ReportTypeId = 3
                    };
                    _dbContext.ReportStructures.Add(repstructure223);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("ReportStructures data exist - no need to seed.");
                }

                // Seed Tests db
                if (!_dbContext.Tests.Any())
                {
                    var tests = new List<Test>
                    {
                        new Test { TestDescription = "Poślizg", TestUnits = "RPM", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Przecieki DC", TestUnits = "L/min", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Przecieki RV", TestUnits = "L/min", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Nastawa RV", TestUnits = "bar", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Nastawa DC", TestUnits = "bar", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Spadki Ciśnienia", TestUnits = "bar", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Pozycja Neutralna", TestUnits = "bar", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Przepływ tryb awaryjny", TestUnits = "L/min", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Life Time", TestUnits = "", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "Wytrzy na obciążenie pulsowe", TestUnits = "Cykli", LabLocationId = 2, ProductFamilyId = 2 },
                        new Test { TestDescription = "QP", TestUnits = "L/min", LabLocationId = 2, ProductFamilyId = 1 },
                        new Test { TestDescription = "NP", TestUnits = "bar", LabLocationId = 2, ProductFamilyId = 1 },
                        new Test { TestDescription = "Start torque", TestUnits = "Nm", LabLocationId = 2, ProductFamilyId = 1 },
                        new Test { TestDescription = "Input Torque", TestUnits = "Nm", LabLocationId = 2, ProductFamilyId = 1 },
                        new Test { TestDescription = "Pressure drop", TestUnits = "bar", LabLocationId = 2, ProductFamilyId = 1 },
                        new Test { TestDescription = "Static Leakage", TestUnits = "L/min", LabLocationId = 2, ProductFamilyId = 1 },
                        new Test { TestDescription = "Certyfikat 3.1", TestUnits = "", LabLocationId = 2, ProductFamilyId = 1 },
                        new Test { TestDescription = "Nastawa zaworów maks.", TestUnits = "bar", LabLocationId = 2, ProductFamilyId = 3 },
                        new Test { TestDescription = "Przecieki na zaworach", TestUnits = "L/min", LabLocationId = 2, ProductFamilyId = 3 },
                        new Test { TestDescription = "Badanie przepływu", TestUnits = "L/min", LabLocationId = 2, ProductFamilyId = 3 },
                        new Test { TestDescription = "Performance", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Pressure Drop", TestUnits = "Bar", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Endurance", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Cyclic", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "1 RPM", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Side load", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Burst", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Roller dyno", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Destructive", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Disp check", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Field application", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Other", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Inspection", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Material testing", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Ccm evaluation", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Static pressure test", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Seal endurance", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Brake testing", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Modification", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Maintanance", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "10 Rpm", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 },
                        new Test { TestDescription = "Overcoming load", TestUnits = "TBD", LabLocationId = 1, ProductFamilyId = 1 }
                    };

                    await _dbContext.Tests.AddRangeAsync(tests);
                    await _dbContext.SaveChangesAsync();
                }


                else
                {
                    System.Console.WriteLine("Tests data exist - no need to seed.");
                }

                // Seed TicketStatuses db
                if (!_dbContext.TicketStatuses.Any())
                {
                    var status1 = new TicketStatus()
                    {
                        StatusDescription = "Waiting"
                    };
                    _dbContext.TicketStatuses.Add(status1);

                    var status2 = new TicketStatus()
                    {
                        StatusDescription = "In Progress"
                    };
                    _dbContext.TicketStatuses.Add(status2);

                    var status3 = new TicketStatus()
                    {
                        StatusDescription = "Finished"
                    };
                    _dbContext.TicketStatuses.Add(status3);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("TicketStatuses data exist - no need to seed.");
                }


                // Seed TestParameter db
                if (!_dbContext.TestParameters.Any())
                {
                    var testParameters = new List<TestParameter>
                    {
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 1 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 1 },
                        new TestParameter { ParameterDescription = "Obciążenie na cylindrze", ParameterUnit = "bar", TestId = 1 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 2 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 2 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 3 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 3 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 4 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 4 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 5 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 5 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 6 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 6 },
                        new TestParameter { ParameterDescription = "Obciążenie na cylindrze", ParameterUnit = "bar", TestId = 6 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 7 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 7 },
                        new TestParameter { ParameterDescription = "Obciążenie na cylindrze", ParameterUnit = "bar", TestId = 7 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 8 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 8 },
                        new TestParameter { ParameterDescription = "Obciążenie na cylindrze", ParameterUnit = "bar", TestId = 8 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 9 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 9 },
                        new TestParameter { ParameterDescription = "Obciążenie R", ParameterUnit = "bar", TestId = 9 },
                        new TestParameter { ParameterDescription = "Obciążenie L", ParameterUnit = "bar", TestId = 9 },
                        new TestParameter { ParameterDescription = "Obciążenie T", ParameterUnit = "bar", TestId = 9 },
                        new TestParameter { ParameterDescription = "Moment", ParameterUnit = "Nm", TestId = 9 },
                        new TestParameter { ParameterDescription = "Czas", ParameterUnit = "Godziny", TestId = 9 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 10 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 10 },
                        new TestParameter { ParameterDescription = "Częstotliwość", ParameterUnit = "Hz", TestId = 10 },
                        new TestParameter { ParameterDescription = "Ilość cykli", ParameterUnit = "Cykle", TestId = 10 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 11 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 11 },
                        new TestParameter { ParameterDescription = "Back Pressure", ParameterUnit = "bar", TestId = 11 },
                        new TestParameter { ParameterDescription = "Prędkość obrotowa", ParameterUnit = "Obr / min", TestId = 12 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 12 },
                        new TestParameter { ParameterDescription = "Back Pressure", ParameterUnit = "bar", TestId = 12 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 13 },
                        new TestParameter { ParameterDescription = "Kąt obrotu", ParameterUnit = "Stopnie", TestId = 13 },
                        new TestParameter { ParameterDescription = "Prędkość obrotowa", ParameterUnit = "Obr / min", TestId = 14 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 15 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 16 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 17 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 17 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 18 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 18 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 19 },
                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 19 },
                        new TestParameter { ParameterDescription = "Przepływ", ParameterUnit = "L/min", TestId = 20 },


                        new TestParameter { ParameterDescription = "Ciśnienie", ParameterUnit = "bar", TestId = 20 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 21 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 21 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 21 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 21 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 21 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 21 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 21 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 21 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 21 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 21 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 21 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 22 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 22 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 22 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 22 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 22 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 22 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 22 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 22 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 22 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 22 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 22 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 23 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 23 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 23 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 23 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 23 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 23 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 23 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 23 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 23 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 23 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 23 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 24 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 24 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 24 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 24 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 24 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 24 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 24 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 24 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 24 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 24 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 24 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 25 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 25 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 25 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 25 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 25 },



                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 25 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 25 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 25 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 25 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 25 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 25 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 26 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 26 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 26 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 26 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 26 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 26 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 26 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 26 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 26 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 26 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 26 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 27 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 27 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 27 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 27 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 27 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 27 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 27 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 27 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 27 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 27 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 27 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 28 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 28 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 28 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 28 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 28 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 28 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 28 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 28 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 28 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 28 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 28 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 29 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 29 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 29 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 29 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 29 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 29 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 29 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 29 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 29 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 29 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 29 },


                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 30 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 30 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 30 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 30 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 30 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 30 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 30 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 30 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 30 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 30 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 30 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 31 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 31 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 31 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 31 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 31 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 31 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 31 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 31 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 31 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 31 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 31 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 32 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 32 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 32 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 32 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 32 },

                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 32 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 32 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 32 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 32 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 32 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 32 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 33 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 33 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 33 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 33 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 33 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 33 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 33 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 33 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 33 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 33 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 33 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 34 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 34 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 34 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 34 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 34 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 34 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 34 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 34 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 34 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 34 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 34 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 35 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 35 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 35 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 35 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 35 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 35 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 35 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 35 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 35 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 35 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 35 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 36 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 36 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 36 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 36 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 36 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 36 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 36 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 36 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 36 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 36 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 36 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 37 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 37 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 37 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 37 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 37 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 37 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 37 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 37 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 37 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 37 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 37 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 38 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 38 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 38 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 38 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 38 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 38 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 38 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 38 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 38 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 38 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 38 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 39 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 39 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 39 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 39 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 39 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 39 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 39 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 39 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 39 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 39 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 39 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 40 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 40 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 40 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 40 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 40 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 40 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 40 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 40 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 40 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 40 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 40 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 41 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 41 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 41 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 41 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 41 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 41 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 41 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 41 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 41 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 41 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 41 },
                        new TestParameter { ParameterDescription = "Flow", ParameterUnit = "GPM", TestId = 42 },
                        new TestParameter { ParameterDescription = "Pressure", ParameterUnit = "PSI", TestId = 42 },
                        new TestParameter { ParameterDescription = "Back pressure", ParameterUnit = "PSI", TestId = 42 },
                        new TestParameter { ParameterDescription = "Speed", ParameterUnit = "RPM", TestId = 42 },
                        new TestParameter { ParameterDescription = "Torque", ParameterUnit = "LB-IN", TestId = 42 },
                        new TestParameter { ParameterDescription = "Number of cycles", ParameterUnit = "Count", TestId = 42 },
                        new TestParameter { ParameterDescription = "Side load", ParameterUnit = "PSI", TestId = 42 },
                        new TestParameter { ParameterDescription = "Load distance", ParameterUnit = "INCH", TestId = 42 },
                        new TestParameter { ParameterDescription = "Cycle time", ParameterUnit = "SEC", TestId = 42 },
                        new TestParameter { ParameterDescription = "Duration", ParameterUnit = "H", TestId = 42 },
                        new TestParameter { ParameterDescription = "Port to pressurize", ParameterUnit = "PSI", TestId = 42 }

                    };

                    await _dbContext.TestParameters.AddRangeAsync(testParameters);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    System.Console.WriteLine("TestParameters data exist - no need to seed.");
                }


            }
        }

    }
}