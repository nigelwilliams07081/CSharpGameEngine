using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlayerTest
{
    [TestFixture]
    public class TestPlayer
    {
        [Test]
        public void BasicTest()
        {
            Assert.That(true);
        }

        [Test]
        public void StartLifeSmall()
        {
            Player player = new Player();
            Assert.False(player.IsEnlarged());
        }
    }

    class Player
    {
        bool m_Enlarged = false;
        internal bool IsEnlarged()
        {
            return m_Enlarged;
        }

        internal void Eat(string thingToEat)
        {
            if (thingToEat == "mushroom")
            {
                m_Enlarged = true;
            }
        }
    }
}
