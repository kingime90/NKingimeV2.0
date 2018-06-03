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
            //var simpleValid = new SimpleValid<User>();
            //simpleValid.StringType(s => s.Email).Required().Range(10, 20).Match(RegexTypeOption.Email).Custom((sd, s) =>
            //{
            //    return null;
            //});
            //var validResults = simpleValid.Validate(new User()
            //{
            //    Email = "1",
            //});

            var stringTypeValid = new StringTypeValid().Required().Range(10, 20).Match(RegexTypeOption.Email);
            stringTypeValid.Validate(null);
        }
    }
}
