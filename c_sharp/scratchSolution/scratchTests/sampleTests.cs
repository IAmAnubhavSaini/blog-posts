using Microsoft.VisualStudio.TestTools.UnitTesting;
using scratchAttributes;
using System.Reflection;

namespace scratchTests
{
    [TestClass]
    public class When_I_Am_Being_An_Obnoxious_Long_Function_Name_Writer
    {
        [TestMethod]
        public void then_please_kick_my_arse_and_then_kick_my_ass_too_because_i_like_international_kicking_hope_you_got_the_point()
        {
        }

        [TestDescription("then please kick my arse and then kick my ass too because i like international kicking hope you got the point")]
        [TestMethod]
        public void KickMeInternationally()
        {
            var currentMethod = MethodBase.GetCurrentMethod();
            var attr =
                currentMethod.GetCustomAttribute(typeof (TestDescriptionAttribute)) as TestDescriptionAttribute;
            var value = attr.Description;
        }
    }
}
