using System;
using NUnit.Framework;
using NKingime.Validate.Tests.Entity;

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
            var simpleValid = new SimpleValid<User>();
            simpleValid.StringType(s => s.Email).Required().MinLength(10)/*.MaxLength(20)*//*.Range(10, 20)*/.Matchs(RegexTypeOption.Email).Custom((value, root) =>
            {
                return new ValidMessageResult(true);
            });
            simpleValid.ValueType(s => s.Grade)/*.MinValue(1)*//*.MaxValue(10)*/.Range(2, 5).Custom((value, root) =>
            {
                return new ValidMessageResult(true);
            });
            var validResults = simpleValid.Validate(new User()
            {
                Email = "12345678910@163.com",
                Grade = 4,
            });

            //var currentCulture = Thread.CurrentThread.CurrentCulture;

            //var resourceManager = new ResourceManager("NKingime.Validate.Tests.Properties.EN", this.GetType().Assembly);
            //string value = resourceManager.GetString("RequiredError");

            //var stringTypeValid = new StringTypeValid().Required().LengthRange(10, 20).Matchs(RegexTypeOption.Email);
            //stringTypeValid.Validate(null);

            //var validResource = new ValidResource();
            //string value= validResource.GetString("RequiredError");

            //decimal d = 90000m;
            //decimal rate = 0.05m;
            //for (int i = 1; i <= 40; i++)
            //{
            //    d = (1 + rate) * d;
            //}
            //string result = d.ToString();
        }
    }
}
