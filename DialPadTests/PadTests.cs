namespace Application.Tests
{
    [TestClass()]
    public class PadTests
    {
        [TestMethod()]
        public void OldPhonePadTest()
        {
            Assert.AreEqual(Pad.OldPhonePad("8 88777444666*664#"), "turing");
        }
    }
}