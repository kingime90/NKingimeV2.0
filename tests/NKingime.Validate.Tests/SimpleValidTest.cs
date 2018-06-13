using System;
using NUnit.Framework;
using NKingime.Validate.Tests.Entity;
using System.Threading;
using System.Resources;
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
            var simpleValid = new SimpleValid<User>();
            simpleValid.StringType(s => s.Email).Required().Range(10, 20).Matchs(RegexTypeOption.Email).Custom((sd, s) =>
            {
                return null;
            });
            var validResults = simpleValid.Validate(new User()
            {
                Email = "1",
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
