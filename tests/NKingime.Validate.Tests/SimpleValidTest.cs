using System;
using NUnit.Framework;
using NKingime.Utility.General;
using NKingime.Validate.Tests.Entity;
using NKingime.Validate;

namespace NKingime.Validate.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class SimpleValidTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Test()
        {
            //var simpleValid = new SimpleValid<User>();
            //simpleValid.StringType(s => s.Email).Required().MinLength(10)/*.MaxLength(20)*//*.Range(10, 20)*/.Matchs(RegexTypeOption.Email).Custom((value, root) =>
            //{
            //    return new BooleanResult(true);
            //});
            //simpleValid.ValueType(s => s.Grade)/*.MinValue(1)*//*.MaxValue(10)*/.Range(2, 5).Custom((value, root) =>
            //{
            //    return new BooleanResult(true);
            //});
            //simpleValid.NullableType(s => s.Birthday).Required()/*.MinValue(new DateTime(1992, 01, 01))*//*.MaxValue(new DateTime(1990, 01, 01))*/.Range(new DateTime(1995, 01, 01), new DateTime(1996, 01, 01)).Custom((value, root) =>
            //{
            //    return new BooleanResult(true);
            //});
            //simpleValid.StringType(s => s.Mobile).Matchs(RegexTypeOption.Cellphone);
            //var validResults = simpleValid.Validate(new User()
            //{
            //    Email = "12345678910@163.com",
            //    Grade = 4,
            //    Birthday = new DateTime(1995, 04, 05),
            //});

            //var currentCulture = Thread.CurrentThread.CurrentCulture;

            //var resourceManager = new ResourceManager("NKingime.Validate.Tests.Properties.EN", this.GetType().Assembly);
            //string value = resourceManager.GetString("RequiredError");

            //var stringTypeValid = new StringTypeValid().Required().LengthRange(10, 20).Matchs(RegexTypeOption.Email);
            //stringTypeValid.Validate(null);

            //var validResource = new ValidResource();
            //string value= validResource.GetString("RequiredError");

            var compoundValid = new CompoundValid<User>();
            compoundValid.StringType(s => s.Username).Required();

            var addresseeValid = new CompoundValid<AddresseeInfo>();
            addresseeValid.StringType(s => s.Name).Required();

            var createrValid = new SimpleValid<Creater>();
            createrValid.StringType(s => s.CreaterId).Required();

            addresseeValid.EntityType(s => s.Creater, createrValid).Required();

            compoundValid.EntityType(s => s.Addressee, addresseeValid).Required();

            var addressee2Valid = new SimpleValid<Addressee2Info>();
            addressee2Valid.StringType(s => s.Name).Required();

            compoundValid.EntityType(s => s.Addressee2, addressee2Valid).Required();

            var validResults = compoundValid.Validate(new User()
            {
                Email = "12345678910@163.com",
                Grade = 4,
                Birthday = new DateTime(1995, 04, 05),
                Addressee = new AddresseeInfo
                {
                    Name = "Tam",
                    Creater = new Creater
                    {

                    },
                },
                Addressee2 = new Addressee2Info
                {

                },
            });
        }
    }
}
