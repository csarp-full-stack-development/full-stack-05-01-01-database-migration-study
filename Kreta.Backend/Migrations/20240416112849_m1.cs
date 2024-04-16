using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kreta.Backend.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    StudentEducationLevel = table.Column<string>(type: "longtext", nullable: false),
                    DurationOfEducation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    GradeValue = table.Column<int>(type: "int", nullable: false),
                    GradeText = table.Column<string>(type: "longtext", nullable: false),
                    TimeOfGrade = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TypeOfGrade = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    IsWoman = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StudentOfParentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "longtext", nullable: false),
                    MathersName = table.Column<string>(type: "longtext", nullable: false),
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicSpaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    NameOfPublicSpace = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSpaces", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    SubjectTypeId = table.Column<Guid>(type: "char(36)", nullable: true),
                    SubjectName = table.Column<string>(type: "longtext", nullable: false),
                    ShortName = table.Column<string>(type: "longtext", nullable: false),
                    OptionalExaminationSubject = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CompulsoryExaminationSubject = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubjectTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    SubjectTypeName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTypes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "longtext", nullable: false),
                    IsWoman = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHeadTeacher = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HeadTeacherForShoolClassId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MathersName = table.Column<string>(type: "longtext", nullable: false),
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeOfEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    EducationName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfEducations", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    SchoolClassType = table.Column<int>(type: "int", nullable: false),
                    TypeOfEducationId = table.Column<Guid>(type: "char(36)", nullable: true),
                    HeadTeacherId = table.Column<Guid>(type: "char(36)", nullable: true),
                    YearOfEnrolment = table.Column<int>(type: "int", nullable: false),
                    IsArchived = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClasses_Teachers_HeadTeacherId",
                        column: x => x.HeadTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolClasses_TypeOfEducations_TypeOfEducationId",
                        column: x => x.TypeOfEducationId,
                        principalTable: "TypeOfEducations",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolClassSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    SchoolClassId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SubjectId = table.Column<Guid>(type: "char(36)", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: false),
                    IsTheHoursInOne = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClassSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClassSubjects_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolClassSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "char(36)", nullable: true),
                    SchoolClassID = table.Column<Guid>(type: "char(36)", nullable: true),
                    MotherId = table.Column<Guid>(type: "char(36)", nullable: true),
                    MatherId = table.Column<Guid>(type: "char(36)", nullable: true),
                    FatherId = table.Column<Guid>(type: "char(36)", nullable: true),
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: true),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "longtext", nullable: false),
                    IsWoman = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsSchoolClassSecretary = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Parents_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Parents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Parents_MatherId",
                        column: x => x.MatherId,
                        principalTable: "Parents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_SchoolClasses_SchoolClassID",
                        column: x => x.SchoolClassID,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeacherTeachInSchoolClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SchoolClassId = table.Column<Guid>(type: "char(36)", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: false),
                    IsTheHoursInOne = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTeachInSchoolClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherTeachInSchoolClass_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeacherTeachInSchoolClass_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    PublicScapeID = table.Column<Guid>(type: "char(36)", nullable: true),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    PublicSpaceName = table.Column<string>(type: "longtext", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Door = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StudentId1 = table.Column<Guid>(type: "char(36)", nullable: true),
                    TeacherId1 = table.Column<Guid>(type: "char(36)", nullable: true),
                    ParentId1 = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresss_Parents_ParentId1",
                        column: x => x.ParentId1,
                        principalTable: "Parents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresss_Students_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresss_Teachers_TeacherId1",
                        column: x => x.TeacherId1,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolClassStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    SchoolClassId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StudnetId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: true),
                    DateOfEnrolment = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClassStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClassStudents_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClassStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Addresss",
                columns: new[] { "Id", "City", "Door", "Floor", "House", "ParentId", "ParentId1", "PostalCode", "PublicScapeID", "PublicSpaceName", "StudentId", "StudentId1", "TeacherId", "TeacherId1" },
                values: new object[,]
                {
                    { new Guid("1f9170a0-c95c-42d2-ad53-3fc8486ec06c"), "Szeged", -1, -1, 85, new Guid("00000000-0000-0000-0000-000000000000"), null, 6724, new Guid("8d457062-193e-4275-8167-9682b497674c"), "Kossuth Lajos", new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("5b79f4b7-c499-4aa7-b336-2c998552bd60"), "Szeged", -1, -1, 10, new Guid("00000000-0000-0000-0000-000000000000"), null, 6722, new Guid("ed433722-96e7-4b44-9a63-1387afb88651"), "Szentháromság", new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("5e984183-7237-413f-a06d-5b4b2ed8669e"), "Szeged", -1, -1, 45, new Guid("00000000-0000-0000-0000-000000000000"), null, 6722, new Guid("ed433722-96e7-4b44-9a63-1387afb88651"), "Bokor", new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("c6521dc3-67bb-4bb0-91e8-287b37837d74"), "Szeged", -1, -1, 56, new Guid("00000000-0000-0000-0000-000000000000"), null, 6722, new Guid("ed433722-96e7-4b44-9a63-1387afb88651"), "Zászló", new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("c6889ac1-6a30-4456-8df3-8f6be9d4f418"), "Szeged", -1, -1, 22, new Guid("00000000-0000-0000-0000-000000000000"), null, 6722, new Guid("8d457062-193e-4275-8167-9682b497674c"), "Boldogasszony", new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("ffaea56a-5cfd-4da4-96db-c0f5a93d1865"), "Szeged", -1, -1, 2, new Guid("00000000-0000-0000-0000-000000000000"), null, 6724, new Guid("8d457062-193e-4275-8167-9682b497674c"), "Kossuth Lajos", new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "DurationOfEducation", "StudentEducationLevel" },
                values: new object[,]
                {
                    { new Guid("280cd533-b4ab-4f4f-9dee-1f57228e0dfd"), 4, "érettségi" },
                    { new Guid("aa29fb68-6f50-4681-8696-f0b6f1332c87"), 2, "szakképzés" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "AddressId", "BirthDay", "FirstName", "IsWoman", "LastName", "MathersName", "PlaceOfBirth", "StudentOfParentId" },
                values: new object[,]
                {
                    { new Guid("3d35167e-164c-4408-8dd3-c3577ae9f4fe"), new Guid("5b79f4b7-c499-4aa7-b336-2c998552bd60"), new DateTime(1998, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virág", true, "Vas", "Érc Kitti", "Szeged", new Guid("a39a2bf5-a123-4612-9bc2-26dd77e94cf8") },
                    { new Guid("67e1cf26-e384-41e9-bd43-a5259ec6890c"), null, new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petra", true, "Pénzes", "Szegény Szandi", "Kistelek", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8e9e03c3-b161-4b6f-ab1d-eb51423f289f"), null, new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hedvig", true, "Hosszú", "Alacsony Anikó", "Szeged", new Guid("31dcc48f-3e6b-45dc-bc1a-0a9dccf808eb") },
                    { new Guid("a71ef195-4ca5-44ae-9f42-1f33f0ab897c"), null, new DateTime(1994, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fruzsi", true, "Fukar", "Adó Anna", "Makó", new Guid("954bd97a-b13b-4505-9755-9132c0ed4490") },
                    { new Guid("b8b867e7-81f5-4aab-9193-dbeac9bf5a44"), null, new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milán", false, "Magas", "Alacsony Anikó", "Deszk", new Guid("31dcc48f-3e6b-45dc-bc1a-0a9dccf808eb") },
                    { new Guid("bec98695-0f4c-4894-b7ed-41e3e06df0e1"), new Guid("1f9170a0-c95c-42d2-ad53-3fc8486ec06c"), new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ferenc", false, "Fukar", "Adakozó Andor", "Szeged", new Guid("a39a2bf5-a123-4612-9bc2-26dd77e94cf8") }
                });

            migrationBuilder.InsertData(
                table: "PublicSpaces",
                columns: new[] { "Id", "NameOfPublicSpace" },
                values: new object[,]
                {
                    { new Guid("61bacf9e-4341-4438-a1d3-a156aa743c26"), "tér" },
                    { new Guid("8d457062-193e-4275-8167-9682b497674c"), "sugárút" },
                    { new Guid("ed433722-96e7-4b44-9a63-1387afb88651"), "utca" }
                });

            migrationBuilder.InsertData(
                table: "SubjectTypes",
                columns: new[] { "Id", "SubjectTypeName" },
                values: new object[,]
                {
                    { new Guid("3ac5d784-7081-4ddd-a65d-fa68048ddcc6"), "Közgazdaságtan" },
                    { new Guid("3c15c176-7329-4605-8eab-229ebd71b440"), "Idegen nyelv" },
                    { new Guid("545d2e5a-6280-4c14-876c-0ce748ca2454"), "Természettudomány" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CompulsoryExaminationSubject", "OptionalExaminationSubject", "ShortName", "SubjectName", "SubjectTypeId" },
                values: new object[,]
                {
                    { new Guid("7f4a6c22-239f-4196-9f86-bc922b9e13eb"), false, true, "Föci", "Földrajz", new Guid("545d2e5a-6280-4c14-876c-0ce748ca2454") },
                    { new Guid("931e1a73-e161-41fb-a9a7-e3a11e4c61fe"), true, false, "Angol", "Angol", new Guid("3c15c176-7329-4605-8eab-229ebd71b440") },
                    { new Guid("e64ca130-b0a9-41c4-8f80-a002bbff3949"), false, false, "Market", "Marketing", new Guid("3ac5d784-7081-4ddd-a65d-fa68048ddcc6") }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AddressId", "BirthDay", "FirstName", "HeadTeacherForShoolClassId", "IsHeadTeacher", "IsWoman", "LastName", "MathersName", "PlaceOfBirth" },
                values: new object[,]
                {
                    { new Guid("2026851c-b5e6-40fc-bf3c-d7ed6248be1b"), null, new DateTime(2000, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mirjam", new Guid("3940133d-8201-4077-a2e0-4076653baa1f"), true, true, "Metek", "Egri Etelka", "Eger" },
                    { new Guid("2052b6e7-eda2-4e2b-b30a-6eed5fb9e141"), new Guid("ffaea56a-5cfd-4da4-96db-c0f5a93d1865"), new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feri", new Guid("ef0b44cf-feb8-4593-b9c1-eaeda99d2f9b"), true, false, "Földrajz", "Szabadkai Szabina", "Szabadka" },
                    { new Guid("b13f76ad-7692-4903-99db-73b7d0886e00"), null, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin", new Guid("5fd266b6-441f-47a7-8d5f-85ac9955a840"), true, false, "Magyar", "Miskolci Mária", "Miskolc" },
                    { new Guid("d9687290-9896-4435-bff6-886f41fd6071"), new Guid("5e984183-7237-413f-a06d-5b4b2ed8669e"), new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adorján", new Guid("00000000-0000-0000-0000-000000000000"), false, false, "Angol", "Kecskeméti Kati", "Kecskemét" },
                    { new Guid("da14389a-acaf-4195-8404-34079d4ebfef"), null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Éva", new Guid("00000000-0000-0000-0000-000000000000"), false, true, "Ének", "Bajai Betti", "Baja" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfEducations",
                columns: new[] { "Id", "EducationName" },
                values: new object[,]
                {
                    { new Guid("225a1206-e126-4d00-ad8c-f73bf2f7b345"), "Vállalkozási ügyviteli ügyintéző" },
                    { new Guid("2f0cb119-3ca8-4210-b793-7496e4aef9ec"), "Szoftverfejlesztő és -tesztelő" },
                    { new Guid("b5f805e3-f709-4511-84fa-1f85cc87739f"), "Idegen nyelvű ipari és kereskedelmi technikus" }
                });

            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "Id", "HeadTeacherId", "IsArchived", "SchoolClassType", "SchoolYear", "TypeOfEducationId", "YearOfEnrolment" },
                values: new object[,]
                {
                    { new Guid("3940133d-8201-4077-a2e0-4076653baa1f"), new Guid("2026851c-b5e6-40fc-bf3c-d7ed6248be1b"), false, 1, 10, new Guid("b5f805e3-f709-4511-84fa-1f85cc87739f"), 2024 },
                    { new Guid("5fd266b6-441f-47a7-8d5f-85ac9955a840"), new Guid("b13f76ad-7692-4903-99db-73b7d0886e00"), false, 0, 9, new Guid("2f0cb119-3ca8-4210-b793-7496e4aef9ec"), 2025 },
                    { new Guid("ef0b44cf-feb8-4593-b9c1-eaeda99d2f9b"), new Guid("2052b6e7-eda2-4e2b-b30a-6eed5fb9e141"), false, 1, 14, new Guid("225a1206-e126-4d00-ad8c-f73bf2f7b345"), 2024 }
                });

            migrationBuilder.InsertData(
                table: "SchoolClassSubjects",
                columns: new[] { "Id", "IsTheHoursInOne", "NumberOfHours", "SchoolClassId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("13423e8b-494b-4687-a254-d307ae84265a"), false, 3, new Guid("5fd266b6-441f-47a7-8d5f-85ac9955a840"), new Guid("7f4a6c22-239f-4196-9f86-bc922b9e13eb") },
                    { new Guid("3c3a911e-84cb-4d5a-9186-7d183b2a5b98"), true, 1, new Guid("5fd266b6-441f-47a7-8d5f-85ac9955a840"), new Guid("e64ca130-b0a9-41c4-8f80-a002bbff3949") },
                    { new Guid("6a1c277e-a204-48d6-9486-3ff3d098440d"), true, 2, new Guid("ef0b44cf-feb8-4593-b9c1-eaeda99d2f9b"), new Guid("931e1a73-e161-41fb-a9a7-e3a11e4c61fe") },
                    { new Guid("af44e7ff-c1fe-41ad-a446-425a085c4f5a"), false, 2, new Guid("3940133d-8201-4077-a2e0-4076653baa1f"), new Guid("931e1a73-e161-41fb-a9a7-e3a11e4c61fe") },
                    { new Guid("b06fce01-16ad-440a-9486-c6a301343ea8"), false, 4, new Guid("ef0b44cf-feb8-4593-b9c1-eaeda99d2f9b"), new Guid("e64ca130-b0a9-41c4-8f80-a002bbff3949") },
                    { new Guid("e932a713-770e-4e08-96f3-a79d0decf4d4"), false, 2, new Guid("ef0b44cf-feb8-4593-b9c1-eaeda99d2f9b"), new Guid("7f4a6c22-239f-4196-9f86-bc922b9e13eb") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AddressId", "BirthDay", "EducationLevelId", "FatherId", "FirstName", "IsSchoolClassSecretary", "IsWoman", "LastName", "MatherId", "MotherId", "PlaceOfBirth", "SchoolClassID" },
                values: new object[,]
                {
                    { new Guid("31dcc48f-3e6b-45dc-bc1a-0a9dccf808eb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b8b867e7-81f5-4aab-9193-dbeac9bf5a44"), "Kinga", false, false, "Kilógó", null, new Guid("8e9e03c3-b161-4b6f-ab1d-eb51423f289f"), "Miskolc", new Guid("ef0b44cf-feb8-4593-b9c1-eaeda99d2f9b") },
                    { new Guid("4614b167-c52a-4cc8-8411-e67193c60744"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa29fb68-6f50-4681-8696-f0b6f1332c87"), null, "Fruzsina", false, false, "Fukar", null, null, "Miskolc", new Guid("3940133d-8201-4077-a2e0-4076653baa1f") },
                    { new Guid("954bd97a-b13b-4505-9755-9132c0ed4490"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("280cd533-b4ab-4f4f-9dee-1f57228e0dfd"), null, "Márta", false, true, "Kis", null, new Guid("a71ef195-4ca5-44ae-9f42-1f33f0ab897c"), "Szabadka", new Guid("3940133d-8201-4077-a2e0-4076653baa1f") },
                    { new Guid("a39a2bf5-a123-4612-9bc2-26dd77e94cf8"), new Guid("5b79f4b7-c499-4aa7-b336-2c998552bd60"), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("280cd533-b4ab-4f4f-9dee-1f57228e0dfd"), new Guid("bec98695-0f4c-4894-b7ed-41e3e06df0e1"), "János", false, false, "Jegy", null, new Guid("3d35167e-164c-4408-8dd3-c3577ae9f4fe"), "Szeged", new Guid("5fd266b6-441f-47a7-8d5f-85ac9955a840") },
                    { new Guid("ce943ac9-6fb9-43d7-8362-093c8981b251"), new Guid("c6889ac1-6a30-4456-8df3-8f6be9d4f418"), new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa29fb68-6f50-4681-8696-f0b6f1332c87"), null, "Nóra", false, true, "Nagy", null, null, "Kiskunhalas", new Guid("5fd266b6-441f-47a7-8d5f-85ac9955a840") },
                    { new Guid("d6b65aa2-d848-4fcf-990a-1c23e7f976d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("280cd533-b4ab-4f4f-9dee-1f57228e0dfd"), null, "Valér", false, false, "Vas", null, null, "Makó", new Guid("5fd266b6-441f-47a7-8d5f-85ac9955a840") },
                    { new Guid("e459faf3-e556-467d-98f3-2c2a1b5fbeb3"), new Guid("c6521dc3-67bb-4bb0-91e8-287b37837d74"), new DateTime(2017, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aa29fb68-6f50-4681-8696-f0b6f1332c87"), null, "Milán", false, false, "Magas", null, new Guid("3d35167e-164c-4408-8dd3-c3577ae9f4fe"), "Apátfalva", new Guid("3940133d-8201-4077-a2e0-4076653baa1f") }
                });

            migrationBuilder.InsertData(
                table: "TeacherTeachInSchoolClass",
                columns: new[] { "Id", "IsTheHoursInOne", "NumberOfHours", "SchoolClassId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("790f2278-13bb-421c-bef1-0722e78448d4"), true, 3, new Guid("3940133d-8201-4077-a2e0-4076653baa1f"), new Guid("da14389a-acaf-4195-8404-34079d4ebfef") },
                    { new Guid("e4fd4cdb-31d3-4d26-9c96-6aa8b6eb0e23"), false, 3, new Guid("3940133d-8201-4077-a2e0-4076653baa1f"), new Guid("d9687290-9896-4435-bff6-886f41fd6071") },
                    { new Guid("f30e5ab7-3e93-4a66-8794-caaea005ffa9"), false, 2, new Guid("5fd266b6-441f-47a7-8d5f-85ac9955a840"), new Guid("d9687290-9896-4435-bff6-886f41fd6071") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_ParentId1",
                table: "Addresss",
                column: "ParentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_StudentId1",
                table: "Addresss",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_TeacherId1",
                table: "Addresss",
                column: "TeacherId1");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_HeadTeacherId",
                table: "SchoolClasses",
                column: "HeadTeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_TypeOfEducationId",
                table: "SchoolClasses",
                column: "TypeOfEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassStudents_SchoolClassId",
                table: "SchoolClassStudents",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassStudents_StudentId",
                table: "SchoolClassStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassSubjects_SchoolClassId",
                table: "SchoolClassSubjects",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassSubjects_SubjectId",
                table: "SchoolClassSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationLevelId",
                table: "Students",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FatherId",
                table: "Students",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MatherId",
                table: "Students",
                column: "MatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolClassID",
                table: "Students",
                column: "SchoolClassID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTeachInSchoolClass_SchoolClassId",
                table: "TeacherTeachInSchoolClass",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTeachInSchoolClass_TeacherId",
                table: "TeacherTeachInSchoolClass",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "PublicSpaces");

            migrationBuilder.DropTable(
                name: "SchoolClassStudents");

            migrationBuilder.DropTable(
                name: "SchoolClassSubjects");

            migrationBuilder.DropTable(
                name: "SubjectTypes");

            migrationBuilder.DropTable(
                name: "TeacherTeachInSchoolClass");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "SchoolClasses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "TypeOfEducations");
        }
    }
}
