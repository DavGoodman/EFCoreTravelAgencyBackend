using NSubstitute;
using NUnit.Framework;
using System;
using System.Text;
using static VatVerifier;

namespace EFCoreTravelAgency.Utils
{
    [TestFixture]
    public class UnitTests
    {
  

        [Test]
        public void Log_PrefixesInputWithDateTime()
        {
            // Arrange
            var dateTime = new DateTime(2022, 1, 1, 12, 0, 0);
            var expectedLogMessage = $"[{dateTime:dd.MM.yy HH:mm:ss}] Logger initialized\r\n" +
                                     $"[{dateTime:dd.MM.yy HH:mm:ss}] Test message\r\n";

            var dateTimeProvider = Substitute.For<IDateTimeProvider>();
            dateTimeProvider.Now.Returns(dateTime);

            var memoryStream = new MemoryStream();
            var streamWriterProvider = Substitute.For<IStreamWriterProvider>();
            streamWriterProvider.CreateStreamWriter(Arg.Any<string>()).ReturnsForAnyArgs(new StreamWriter(memoryStream));

            Logger logger = new Logger("testPath", dateTimeProvider, streamWriterProvider);


            // Act
            logger.Log("Test message");

            // Assert

            string actualLogMessage = Encoding.UTF8.GetString(memoryStream.ToArray());
            Assert.AreEqual(expectedLogMessage, actualLogMessage);

            // StreamWriter was created with the expected path
            streamWriterProvider.Received().CreateStreamWriter("testPath");
        }


        [Test]
        public async Task Verify_ValidVat_ReturnsValid()
        {
            // Arrange
            string countryCode = "DE";
            string vatId = "118856456";

            // Act
            var result = await VerifyAsync(countryCode, vatId);

            // Assert
            Assert.AreEqual(VerificationStatus.Valid, result);
        }

        [Test]
        public async Task Verify_InvalidVat_ReturnsInvalid()
        {
            // Arrange
            string countryCode = "DE";
            string vatId = "123456789";

            // Act
            var result = await VerifyAsync(countryCode, vatId);

            // Assert
            Assert.AreEqual(VerificationStatus.Invalid, result);
        }
    }
}
